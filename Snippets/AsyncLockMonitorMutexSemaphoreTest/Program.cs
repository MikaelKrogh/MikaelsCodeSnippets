using System.Threading;


public class Program
{
    private static object _locker = new object();
    static ManualResetEvent _manuelReset = new ManualResetEvent(false);
    static void Main(string[] args)
    {
        new Thread(Write).Start();
        for (int i = 0; i < 5; i++)
        {
            new Thread(Read).Start();
        }

        //for (int i = 0; i < 5; i++){
        //    //new Thread(DoWorkLock).Start();
        //    //new Thread(DoWorkMonitor).Start();
        //}
    }

    public static void DoWorkLock()
    {
        try
        {
            lock(_locker) { }
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
            Thread.Sleep(2000);
            throw new Exception();
        }
        catch (Exception){}
        finally {}
    }
    public static void DoWorkMonitor()
    {
        try
        {
            Monitor.Enter(_locker);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
            Thread.Sleep(2000);
            throw new Exception();
        }
        catch (Exception){}
        finally { Monitor.Exit(_locker); }
    }

    public static void Write()
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing");
        _manuelReset.Reset();
        Thread.Sleep(5000);
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed");
        _manuelReset.Set();
    }
    public static void Read()
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting");
        _manuelReset.WaitOne();
        //Thread.Sleep(2000);
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} reading reading");
    }
}

