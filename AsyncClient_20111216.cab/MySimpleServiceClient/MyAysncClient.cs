using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Runtime.CompilerServices;

namespace MySimpleServiceClient
{
	/// <summary>
	/// 【调用我的服务框架的工具类】
	/// 我的异步调用客户端封装类
	/// </summary>
	/// <typeparam name="TIn"></typeparam>
	/// <typeparam name="TOut"></typeparam>
	public sealed class MyAysncClient<TIn, TOut>
	{
		private string _url;
		private volatile bool _isBusy;
		/// <summary>
		/// 当前客户端是否在异步调用中。
		/// </summary>
		public bool IsBusy { get { return _isBusy; } }

		private int _status;
		private int _timeoutMilliseconds;
		private Timer _timeoutTimer;

		/// <summary>
		/// 用于保存额外的用户数据。
		/// </summary>
		public object UserData;

		/// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="url"></param>
		public MyAysncClient(string url)
		{
			if( string.IsNullOrEmpty(url) )
				throw new ArgumentNullException("url");

			_url = url;
		}

		/// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="url"></param>
		/// <param name="timeoutMilliseconds"></param>
		public MyAysncClient(string url, int timeoutMilliseconds)
			: this(url)
		{
			if( timeoutMilliseconds < 0 )
				throw new ArgumentOutOfRangeException("timeoutMilliseconds必须大于等于零。");

			_timeoutMilliseconds = timeoutMilliseconds;
		}
		
		/// <summary>
		/// 调用完成后的事件参数类。它包含调用的结果，以及异常信息。
		/// </summary>
		public class CallCompletedEventArgs : AsyncCompletedEventArgs
		{
			private TOut _result;

			/// <summary>
			/// 构造方法
			/// </summary>
			/// <param name="result"></param>
			/// <param name="e"></param>
			/// <param name="canceled"></param>
			/// <param name="state"></param>
			public CallCompletedEventArgs(TOut result, Exception e, bool canceled, object state)
				: base(e, canceled, state)
			{
				_result = result;
			}

			/// <summary>
			/// 异步调用的返回结果
			/// </summary>
			public TOut Result
			{
				get
				{
					base.RaiseExceptionIfNecessary();
					return _result;
				}
			}
		}

		/// <summary>
		/// 异步调用完成后的通知事件处理器（委托定义）
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public delegate void CallCompletedEventHandler(object sender, CallCompletedEventArgs e);
		/// <summary>
		/// 异步调用完成后的通知事件
		/// </summary>
		public event CallCompletedEventHandler OnCallCompleted;


		/// <summary>
		/// 开始以【异步】方式调用服务方法。当异步调用完成或者超时，或者发生异常时，将由事件OnCallCompleted通知。
		/// </summary>
		/// <param name="input"></param>
		/// <param name="state"></param>
		public void CallAysnc(TIn input, object state)
		{
			if( input == null )
				throw new ArgumentNullException("input");
			if( _isBusy )
				throw new InvalidOperationException("client is busy.");

			_isBusy = true;
			_status = 0;

			// 准备与同步上下文有关的对象
			// 注意这个调用，这是整个事件模式的核心。
			AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(state);

			//---------------------------------------------------------------------------------
			// 注意：
			//   这个客户端的封装类其实可以算是个辅助类，整个类就是辅助下面的这个调用。
			//   这个类其实只处理二个简单的功能：
			//     1. 引发异步调用完成后的事件。
			//     2. 在合适的同步上下文环境中引发完成事件。
			//   而真正发送请求的过程，在下面这个方法中实现的。

			try {
				// 开始异步调用。这个方法将完成发送请求的过程。第三个参数为回调方法。
				HttpWebRequestHelper<TIn, TOut>.SendHttpRequestAsync(_url, input, CallbackProc, asyncOp);
			}
			catch( Exception ex ) {
				// 由于已开始异步操作，已向AspNetSynchronizationContext做过【登记】过程，
				// 因此必须使用回调方法报告异常，在那里会asyncOp.PostOperationCompleted()做【注销】处理。
				ThreadPool.QueueUserWorkItem((x) => CallbackProc(input, default(TOut), ex, asyncOp));
				return;
			}
			
			if( _timeoutMilliseconds > 0 ) {
				// 准备用于超时处理的数据以及计时器。
				MyAysncClientTimerParam mctp = new MyAysncClientTimerParam {
					AsyncOperation = asyncOp,
					InputData = input
				};
				_timeoutTimer = new Timer(TimeoutCallback, mctp, _timeoutMilliseconds, Timeout.Infinite);
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		private void DisposeTimer()
		{
			if( _timeoutTimer != null ) {
				_timeoutTimer.Dispose();
				_timeoutTimer = null;
			}
		}

		// 超时的回调方法
		private void TimeoutCallback(object state)
		{
			DisposeTimer();

			// 正常调用已经完成，没有必要再执行了。（也可以取消这个判断，不影响最终结果）
			if( Interlocked.CompareExchange(ref _status, 1, 1) == 1 )
				return;

			MyAysncClientTimerParam mctp = (MyAysncClientTimerParam)state;

			TimeoutException exception = new TimeoutException(string.Format("调用服务已超时[{0}]。", _url));

			CallbackProc(mctp.InputData, default(TOut), exception, mctp.AsyncOperation);
		}
		

		// 异步完成的回调方法
		private void CallbackProc(TIn input, TOut result, Exception exception, object state)
		{
			// 进入这个方法表示异步调用已完成。
			// 设置标志变量，确保只调用一次，不管是正常完成的回调还是超时回调。
			if( Interlocked.CompareExchange(ref _status, 1, 0) == 1 )
				return;

			DisposeTimer();

			AsyncOperation asyncOp = (AsyncOperation)state;

			// 创建事件参数
			CallCompletedEventArgs e =
				new CallCompletedEventArgs(result, exception, false /* canceled */, asyncOp.UserSuppliedState);

			// 切换线程调用上下文。注意第一个参数为回调方法。
			asyncOp.PostOperationCompleted(CallCompleted, e);
		}

		// 用于处理完成后同步上下文切换的回调方法
		private void CallCompleted(object args)
		{
			// 运行到这里表示已经切回当初发起调用CallAysnc()时的同步上下文环境。

			CallCompletedEventArgs e = (CallCompletedEventArgs)args;

			// 引发完成事件
			CallCompletedEventHandler handler = OnCallCompleted;
			if( handler != null )
				handler(this, e);

			// 到此，异步调用以及事件的响应全部处理结束。
			_isBusy = false;
		}


		/// <summary>
		/// 用于超时的回调参数
		/// </summary>
		private sealed class MyAysncClientTimerParam
		{
			public AsyncOperation AsyncOperation;
			public TIn InputData;
		}
	}


	
}
