using System.Net.NetworkInformation;

namespace ParallelProgrammingAndConcurrency.ChapterOne;

public class NetworkingWorkCancellation
{
    public void Main()
    {
        var bgThread1 = new Thread(CheckNetworkStatus);

        var source = new CancellationTokenSource();

        bgThread1.Start(source.Token);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Main thread is working");
            Thread.Sleep(100);
        }
        source.Cancel();
        bgThread1.Join();
        source.Dispose();

        Console.WriteLine("done");
        Console.ReadKey();
    }
    public void CheckNetworkStatus(object obj)
    {
        var cancellationToken = (CancellationToken)obj;
        bool finished = false;
        cancellationToken.Register(() =>
        {
            finished = true;
        });
        while (!finished)
        {
            bool isNetWorkUp = NetworkInterface.GetIsNetworkAvailable();
            Console.WriteLine($"Is Network available? {isNetWorkUp}");
        }
    }
}
