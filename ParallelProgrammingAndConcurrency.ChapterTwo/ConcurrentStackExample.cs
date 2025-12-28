using System.Collections.Concurrent;

namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class ConcurrentStackExample
{
    public void Main()
    {
        var stack = new ConcurrentStack<int>();
        Parallel.For(1, 10, stack.Push);
        Parallel.ForEach(stack, (i) =>
        {
            stack.TryPop(out int result);
            Console.WriteLine($"Reading {result} from thread {Environment.CurrentManagedThreadId}");
        });
    }
}
