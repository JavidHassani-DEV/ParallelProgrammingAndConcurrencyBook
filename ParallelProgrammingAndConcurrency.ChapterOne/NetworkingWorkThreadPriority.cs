using System.Net.NetworkInformation;

namespace ParallelProgrammingAndConcurrency.ChapterOne;

public class NetworkingWorkThreadPriority
{
    public void Main()
    {

        var bgThread1 = new Thread(CheckNetworkStatus);

        var bgThread2 = new Thread(CheckNetworkStatus);

        var bgThread3 = new Thread(CheckNetworkStatus);

        var bgThread4 = new Thread(CheckNetworkStatus);

        bgThread1.Priority = ThreadPriority.Lowest;
        bgThread2.Priority = ThreadPriority.BelowNormal;
        bgThread3.Priority = ThreadPriority.Normal;
        bgThread4.Priority = ThreadPriority.Highest;

        bgThread1.Start("Lowest");
        bgThread2.Start("BelowNormal");
        bgThread3.Start("Normal");
        bgThread4.Start("Highest");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Main thread is working");
        }
        Console.WriteLine("done");
        Console.ReadKey();
    }
    public void CheckNetworkStatus(object obj)
    {
        var threadPriority = (string)obj;

        for (int i = 0; i < 12; i++)
        {
            bool isNetWorkUp = NetworkInterface.GetIsNetworkAvailable();
            Console.WriteLine($"Thread Priority {threadPriority} Is Network available? {isNetWorkUp}");
        }
    }
}
