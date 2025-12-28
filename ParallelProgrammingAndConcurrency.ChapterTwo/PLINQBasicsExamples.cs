namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class PLINQBasicsExamples
{
    public void Main()
    {
        FindEvenNumbers([1, 2, 4, 56, 7, 8, 9, 12, 53453, 32, 2, 1, 25, 7, 4, 7, 5]);
    }
    public void FindEvenNumbers(List<int> numbers)
    {
        var evenNumbers = numbers.AsParallel().Where(i => IsEven(i));
        Console.WriteLine($"even numbers: {string.Join(',', evenNumbers)}");
    }
    private bool IsEven(in int number)
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        if (number % 2 == 0)
        {
            Console.WriteLine($"its even, ThreadId: {threadId}");
            return true;
        }
        else
        {
            Console.WriteLine($"its not, ThreadId: {threadId}");
            return false;
        }
    }
}
