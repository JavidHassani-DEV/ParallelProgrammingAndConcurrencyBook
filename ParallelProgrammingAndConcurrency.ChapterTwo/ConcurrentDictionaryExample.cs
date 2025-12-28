using System.Collections.Concurrent;

namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class ConcurrentDictionaryExample
{
    public void Main()
    {
        var dic = new ConcurrentDictionary<int, int>();
        var dic2 = new Dictionary<int, int>();
        Parallel.For(1, 10, (i) =>
        {
            bool threadSafeResult = dic.TryAdd(1, i);
            Console.WriteLine($"ThreadSafe: adding item succeeded {threadSafeResult}, from thread {Environment.CurrentManagedThreadId}, collection item count: {dic.Count}");
        });

        Parallel.For(1, 10, (i) =>
        {
            bool threadUnSafeResult = dic2.TryAdd(1, i);
            Console.WriteLine($"Non-ThreadSafe: adding item succeeded {threadUnSafeResult}, from thread {Environment.CurrentManagedThreadId}, collection item count: {dic.Count}");
        });
    }
}
