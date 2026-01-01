using System.Net.NetworkInformation;

namespace ParallelProgrammingAndConcurrency.ChapterThree;

internal class NetworkState
{
    internal static string Name { get; set; }
    internal static string IP { get; set; }
    internal static bool IsConnected { get; set; }

    static NetworkState()
    {
        Console.WriteLine("Constructor called");
        IP = GetIpAddress();
        Name = "Testing";
        IsConnected = IsNetworkConnected();
        Thread.Sleep(2000);
    }
    private static string GetIpAddress()
    {
        return "1.1.1.1";
    }
    internal static bool IsNetworkConnected()
    {
        return NetworkInterface.GetIsNetworkAvailable();
    }
}
internal class NetworkHelper
{
    public async Task Main()
    {
        Console.WriteLine($"Current time {DateTime.UtcNow}");
        await GetNetWorkAvailability();
        Console.WriteLine($"Network avaialability {NetworkState.IsConnected}, {NetworkState.IP}, {NetworkState.Name}");
    }
    internal async Task<bool> GetNetWorkAvailability()
    {
        await Task.Delay(100);
        NetworkState.IsConnected = NetworkState.IsNetworkConnected();
        Console.WriteLine($"Network state updated at {DateTime.UtcNow}");
        return NetworkState.IsConnected;
    }
}
