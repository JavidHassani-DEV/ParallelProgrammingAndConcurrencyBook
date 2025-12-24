using System.Net.NetworkInformation;

namespace ParallelProgrammingAndConcurrency.ChapterOne;

public class NetworkingWork
{
    public void CheckNetworkStatus(object obj)
    {
        for (int i = 0; i < 12; i++)
        {
            bool isNetWorkUp = NetworkInterface.GetIsNetworkAvailable();
            Console.WriteLine($"Thread priority: {(string)obj}; Is Network available? {isNetWorkUp}");
        }
    }
}
