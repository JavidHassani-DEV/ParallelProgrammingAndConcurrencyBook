namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class ParallelInvokeExample
{
    public void DoWorkInParallel()
    {
        Parallel.Invoke(
            DoComplexWork,
            new Action(() =>
            {
                Console.WriteLine($"Hello From Action {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
                Console.WriteLine("Finished Action");
            })
        );
    }

    private void DoComplexWork()
    {
        Console.WriteLine($"Testing Do Complex Work {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(200);
        Console.WriteLine("Do Complex work is done!");
    }
}
