using System.Collections.Concurrent;

namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class ConcurrentQueueExample
{
    public void Main()
    {
        var queue = new ConcurrentQueue<int>();
        for (int i = 0; i < 10; i++)
        {
            queue.Enqueue(i);
        }
        Parallel.For(1, 10, (i) =>
        {
            Console.WriteLine($"{i} being added to queue from thread {Thread.CurrentThread.ManagedThreadId}");
            queue.Enqueue(i);
        });

        Parallel.ForEach(queue, (i) =>
        {
            Console.WriteLine($"reading items concurrently {i}, from thread {Thread.CurrentThread.ManagedThreadId}");
        });
    }
}
