using System;
using System.Threading;
using System.Threading.Tasks;

public class Worker
{
    //private bool _shouldStop;
    private volatile bool _shouldStop;

    public void DoWork()
    {
        int a = 0;
        int b = 1;
        // 注意：这里会被编译器优化为 while(true)
        while (!_shouldStop)
        {
            b = a; // do sth.
        }
        Console.WriteLine("工作线程：正在终止...");
    }

    public void RequestStop()
    {
        _shouldStop = true;
    }
}

public class Program
{
    public static void Main()
    {
        var worker = new Worker();

        Console.WriteLine("主线程：启动工作线程...");
        var workerTask = Task.Run(worker.DoWork);

        // 等待 500 毫秒以确保工作线程已在执行
        Thread.Sleep(500);

        Console.WriteLine("主线程：请求终止工作线程...");
        worker.RequestStop();

        // 待待工作线程执行结束
        workerTask.Wait();
        //workerThread.Join();

        Console.WriteLine("主线程：工作线程已终止");
    }
}