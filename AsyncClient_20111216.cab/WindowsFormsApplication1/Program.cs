using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication1
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

	}




	public delegate string MyFunc(int num, DateTime dt);





	//public interface IAsyncResult
	//{
	//    // 获取用户定义的对象，它限定或包含关于异步操作的信息。
	//    // 通常在调用BeginXXXX方法时传入对象，供回调方法时恢复之前的状态。
	//    object AsyncState { get; }

	//    // 获取用于等待异步操作完成的 System.Threading.WaitHandle。
	//    // 我们可以调用它的WaitOne()方法等待调用完成。
	//    WaitHandle AsyncWaitHandle { get; }

	//    // 获取异步操作是否同步完成的指示。
	//    // 如果异步操作同步完成，则为 true；否则为 false。
	//    bool CompletedSynchronously { get; }

	//    // 获取异步操作是否已完成的指示。
	//    // 如果操作完成则为 true，否则为 false。
	//    bool IsCompleted { get; }
	//}



	////  公开以文件为主的 System.IO.Stream，既支持同步读写操作，也支持异步读写操作。
	//public class FileStream : Stream
	//{
	//    // 使用指定的路径、创建模式、读/写和共享权限、
	//    // 缓冲区大小和同步或异步状态初始化 System.IO.FileStream 类的新实例。
	//    public FileStream(string path, FileMode mode, FileAccess access, FileShare share, 
	//                        int bufferSize, bool useAsync);

	//    // 获取一个值，该值指示 FileStream 是异步还是同步打开的。
	//    // 如果 FileStream 是异步打开的，则为 true，否则为 false。
	//    public virtual bool IsAsync { get; }

	//    // 开始异步读。
	//    public override IAsyncResult BeginRead(byte[] array, int offset, int numBytes, 
	//                        AsyncCallback userCallback, object stateObject);

	//    // 开始异步写。
	//    public override IAsyncResult BeginWrite(byte[] array, int offset, int numBytes, 
	//                        AsyncCallback userCallback, object stateObject);

	//    // 等待挂起的异步读取完成。
	//    public override int EndRead(IAsyncResult asyncResult);

	//    // 结束异步写入，在 I/O 操作完成之前一直阻止。
	//    public override void EndWrite(IAsyncResult asyncResult);
	//}

}
