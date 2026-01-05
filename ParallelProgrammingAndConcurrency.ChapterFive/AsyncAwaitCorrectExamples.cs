namespace ParallelProgrammingAndConcurrency.ChapterFive;

public class AsyncAwaitCorrectExamples
{
    public async Task Start()
    {
        await FirstAsync();
        await SecondAsync();
    }

    public async Task FirstAsync()
    {
        Console.WriteLine("first method called");
        await Task.Delay(500);
        await InsideFirstAsync();
        Console.WriteLine("first method finished");
    }
    public async Task SecondAsync()
    {
        Console.WriteLine("second method called");
        await Task.Delay(500);
        Console.WriteLine("second method finished");
    }

    public async Task InsideFirstAsync()
    {
        Console.WriteLine("inside first method called");
        await Task.Delay(500);
        Console.WriteLine("inside first method finished");
    }
}