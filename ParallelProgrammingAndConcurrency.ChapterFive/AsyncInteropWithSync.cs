namespace ParallelProgrammingAndConcurrency.ChapterFive;

public class AsyncInteropWithSync
{
    public async Task<object> AsyncToSync()
    {
        try
        {
            await Task.Delay(1000);
            var result = await Task.Run(SyncToAsync);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null!;
    }
    public object SyncToAsync()
    {
        try
        {
            Thread.Sleep(1000);
            var result = AsyncToSync().Result;
            return result;
        }
        // when using .Result or .Wait(), exceptions are wrapped in AggregateException
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }
}