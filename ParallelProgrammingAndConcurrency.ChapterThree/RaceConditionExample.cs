namespace ParallelProgrammingAndConcurrency.ChapterThree;

public class RaceConditionExample
{
    private int _totalValue = 5;

    public void Main()
    {
        WithOrder().Wait();
        //WithoutOrder();
    }

    private async Task WithOrder()
    {
        await AddValue().ContinueWith(_ => MultiplyValue()).Unwrap();
        Console.WriteLine(_totalValue);
    }

    private void WithoutOrder()
    {
        Parallel.Invoke(() =>
        {
            AddValue().Wait();
        },
        () =>
        {
            MultiplyValue().Wait();
        });
        Console.WriteLine(_totalValue);
    }

    private async Task AddValue()
    {
        await Task.Delay(100);
        Console.WriteLine("base value is " + _totalValue);
        _totalValue += 10;
    }

    private async Task MultiplyValue()
    {
        await Task.Delay(100);
        Console.WriteLine("base value is " + _totalValue);
        _totalValue *= 2;
    }
}
