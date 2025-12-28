namespace ParallelProgrammingAndConcurrency.ChapterTwo;

public class ParallelExamples
{
    public void Main()
    {
        ParallelForEachExample(["1asdf", "2asdf", "fasdf", "3asdfasdf", "fadf", "fasdf4"]);
    }
    public void ParallelForEachExample(List<string> inputs)
    {
        Parallel.ForEach(inputs, input =>
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            bool containsNumber = HasDigit(input);
            if (containsNumber)
            {
                Console.WriteLine($"has digit : {input}, ThreadId: {threadId}");
            }
            else
            {
                Console.WriteLine($"doesn't have digit : {input}, ThreadId: {threadId}");
            }
        });
    }
    public bool HasDigit(string input)
    {
        List<char> digits = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];

        return input.Any(i => digits.Any(d => d == i));
    }
}
