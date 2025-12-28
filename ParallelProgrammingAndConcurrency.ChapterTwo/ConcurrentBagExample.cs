using System.Collections.Concurrent;

namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class ConcurrentBagExample
{
    public void Main()
    {
        var concurrentBag = new ConcurrentBag<int>();
        Parallel.For(1, 10, (i) =>
        {
            AddAndReadFromCollection(concurrentBag, i);
        });
    }

    private void AddAndReadFromCollection(ConcurrentBag<int> input, int value)
    {
        input.Add(value);
        input.TryPeek(out int result);
        Console.WriteLine($"Value is {value}, Result is {result} in thread {Thread.CurrentThread.ManagedThreadId}");
    }
}
