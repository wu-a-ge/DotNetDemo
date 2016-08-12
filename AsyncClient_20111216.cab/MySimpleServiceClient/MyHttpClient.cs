using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace MySimpleServiceClient
{
	/// <summary>
	/// 【调用我的服务框架的工具类】
	/// 对异步发送HTTP请求全过程的包装类，
	/// 按IAsyncResult接口要求提供BeginSendHttpRequest/EndSendHttpRequest方法（一次回调）
	/// </summary>
	/// <typeparam name="TIn"></typeparam>
	/// <typeparam name="TOut"></typeparam>
	public class MyHttpClient<TIn, TOut>
	{
		/// <summary>
		/// 用于保存额外的用户数据。
		/// </summary>
		public object UserData;

		/// <summary>
		/// 开始【异步】调用一个服务方法。获取结果需要调用EndSendHttpRequest方法。
		/// </summary>
		/// <param name="url"></param>
		/// <param name="input"></param>
		/// <param name="cb"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public IAsyncResult BeginSendHttpRequest(string url, TIn input, AsyncCallback cb, object state)
		{
			// 准备返回值
			MyHttpAsyncResult ar = new MyHttpAsyncResult(cb, state);

			// 开始异步调用
			HttpWebRequestHelper<TIn, TOut>.SendHttpRequestAsync(url, input, SendHttpRequestCallback, ar);
			return ar;
		}

		private void SendHttpRequestCallback(TIn input, TOut result, Exception ex, object state)
		{
			// 进入这个方法表示异步调用已完成
			MyHttpAsyncResult ar = (MyHttpAsyncResult)state;

			// 设置完成状态，并发出完成通知。
			ar.SetCompleted(ex, result);
		}
		
		/// <summary>
		/// 结束【异步】调用，返回服务方法的结果。
		/// 如果有异常发生，也会在这个方法中重新抛出。
		/// </summary>
		/// <param name="ar"></param>
		/// <returns></returns>
		public TOut EndSendHttpRequest(IAsyncResult ar)
		{
			if( ar == null )
				throw new ArgumentNullException("ar");

			// 说明：我并没有检查ar对象是不是与之匹配的BeginSendHttpRequest实例方法返回的，
			// 虽然这是不规范的，但我还是希望示例代码能更简单。
			// 我想应该极少有人会乱传递这个参数。

			MyHttpAsyncResult myResult = ar as MyHttpAsyncResult;
			if( myResult == null )
				throw new ArgumentException("无效的IAsyncResult参数，类型不是MyHttpAsyncResult。");

			if( myResult.EndCalled )
				throw new InvalidOperationException("不能重复调用EndSendHttpRequest方法。");

			myResult.EndCalled = true;
			myResult.WaitForCompletion();

			return (TOut)myResult.Result;
		}
	}
    internal class Test : IAsyncResult
    {

        #region IAsyncResult 成员

        public object AsyncState
        {
            get { throw new NotImplementedException(); }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCompleted
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
	internal class MyHttpAsyncResult : IAsyncResult
	{
		internal MyHttpAsyncResult(AsyncCallback callBack, object state)
		{
			_state = state;
			_asyncCallback = callBack;
		}

		internal object Result { get; private set; }
		internal bool EndCalled;

		private object _state;
		private volatile bool _isCompleted;
		private ManualResetEvent _event;
		private Exception _exception;
		private AsyncCallback _asyncCallback;


		public object AsyncState
		{
			get { return _state; }
		}
		public bool CompletedSynchronously
		{
			get { return false; } // 其实是不支持这个属性
		}
		public bool IsCompleted
		{
			get { return _isCompleted; }
		}
		public WaitHandle AsyncWaitHandle
		{
			get {
				if( _isCompleted )
					return null;	// 注意这里并不返回WaitHandle对象。

				if( _event == null ) 	// 注意这里的延迟创建模式。
					_event = new ManualResetEvent(false);
				return _event;
			}
		}
        /// <summary>
        /// 这个方法肯定会被回调线程中的SendHttpRequestCallback方法调用，
        /// 以来通知调用线程回调结束。因为异步调用结束必须得调用SendHttpRequestCallback方法
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="result"></param>
		internal void SetCompleted(Exception ex, object result)
		{
			this.Result = result;
			this._exception = ex;

			this._isCompleted = true;
			ManualResetEvent waitEvent = Interlocked.CompareExchange(ref _event, null, null);

			if( waitEvent != null )
				waitEvent.Set();		// 通知 EndSendHttpRequest() 的调用者

			if( _asyncCallback != null )
				_asyncCallback(this);	// 调用 BeginSendHttpRequest()指定的回调委托
		}
        /// <summary>
        /// 加入这个方法是为了防止调用线程在调用BeginXXX方法后立即调用EndXXX方法
        /// 以阻塞调用线程的运行，如果异步没有完成
        /// </summary>
		internal void WaitForCompletion()
		{
			if( _isCompleted == false ) {
				WaitHandle waitEvent = this.AsyncWaitHandle;
				if( waitEvent != null )
					waitEvent.WaitOne();	// 使用者直接(非回调方式)调用了EndSendHttpRequest()方法。
			}

			if( _exception != null )
				throw _exception;	// 将异步调用阶段捕获的异常重新抛出。
		}

		// 注意有二种线程竞争情况：
		//  1. 在回调线程中调用SetCompleted时，原线程访问AsyncWaitHandle
		//  2. 在回调线程中调用SetCompleted时，原线程调用WaitForCompletion

		// 说明：在回调线程中，会先调用SetCompleted，再调用WaitForCompletion
	}
}
