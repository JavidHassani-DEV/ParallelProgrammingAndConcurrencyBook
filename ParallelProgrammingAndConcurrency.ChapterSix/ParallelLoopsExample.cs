namespace ParallelProgrammingAndConcurrency.ChapterSix;

public class ParallelLoopsExample
{
    public void ParallelFor()
    {
        Parallel.For(0, 10,
            (index, state) =>
            {
                Console.WriteLine($"doing heavy stuff from thread {Environment.CurrentManagedThreadId}");
                Thread.Sleep(1000);
                Console.WriteLine($"finished heavy stuff from thread {Environment.CurrentManagedThreadId}");
                state.Stop(); // stops current iteration and goes for the next one
                state.Break(); // finish all the iterations from now on.

            });
    }

    public async Task ParallelForEach(CancellationToken ct)
    {
        Parallel.ForEach([1, 2, 4, 5, 6, 7, 8,],
            (item, state) =>
            {
                Console.WriteLine($"doing heavy stuff from thread {Environment.CurrentManagedThreadId}");
                Thread.Sleep(1000);

                state.Stop(); // stops current iteration and goes for the next one
                state.Break(); // finish all the iterations from now on.

                Console.WriteLine($"finished heavy stuff from thread {Environment.CurrentManagedThreadId}");
            });

        await Parallel.ForEachAsync([1, 2, 4, 5, 6, 7, 8,], ct,
            async (item, ct) =>
            {
                Console.WriteLine($"doing heavy stuff from thread {Environment.CurrentManagedThreadId}");

                Thread.Sleep(1000);
                Console.WriteLine($"finished heavy stuff from thread {Environment.CurrentManagedThreadId}");
            });
    }
}
