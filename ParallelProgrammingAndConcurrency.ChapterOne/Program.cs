using ParallelProgrammingAndConcurrency.ChapterOne;

var networkingWork = new NetworkingWork();

var bgThread1 = new Thread(networkingWork.CheckNetworkStatus);

var bgThread2 = new Thread(networkingWork.CheckNetworkStatus);

var bgThread3 = new Thread(networkingWork.CheckNetworkStatus);

var bgThread4 = new Thread(networkingWork.CheckNetworkStatus);

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