namespace ParallelProgrammingAndConcurrency.ChapterThree;

public class RaceConditionExample
{
    private long _totalValue = 5;

    public void Main()
    {
        //WithOrder().Wait();
        //WithoutOrder();
        WithInterLock();
        Console.WriteLine("running total is " + _totalValue);
    }

    private async Task WithOrder()
    {
        await AddValue().ContinueWith(_ => MultiplyValue()).Unwrap();
        Console.WriteLine(_totalValue);
    }

    private void WithInterLock()
    {
        Parallel.Invoke(() =>
        {
            AddValueWithInterlockAsync().Wait();
        },
        () =>
        {
            MultiplyValueWithInterlock().Wait();
        });
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

    private async Task AddValueWithInterlockAsync()
    {
        await Task.Delay(100);
        Interlocked.Add(ref _totalValue, 10);
        Console.WriteLine("base value after add is " + _totalValue);
    }

    private async Task MultiplyValueWithInterlock()
    {
        await Task.Delay(100);
        var currentTotal = Interlocked.Read(ref _totalValue);
        Interlocked.Exchange(ref _totalValue, currentTotal * 2);
        Console.WriteLine("base value after multiplication is " + _totalValue);
    }
}
