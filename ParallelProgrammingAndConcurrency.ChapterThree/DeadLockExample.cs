namespace ParallelProgrammingAndConcurrency.ChapterThree;

public class DeadLockExample
{
    private readonly object _lockA = new();
    private readonly object _lockB = new();

    // Simple entry point for running the example.
    public void Main()
    {
        var example = new DeadLockExample();
        //example.RunDeadlock();
        example.AvoidDeadlock();
    }

    public void RunDeadlock()
    {
        var thread1 = new Thread(() =>
        {
            Console.WriteLine("Thread1: attempting to acquire lockA");
            lock (_lockA)
            {
                Console.WriteLine("Thread1: acquired lockA");
                Thread.Sleep(200); // give other thread time to run and acquire lockB
                Console.WriteLine("Thread1: attempting to acquire lockB");
                lock (_lockB)
                {
                    Console.WriteLine("Thread1: acquired lockB");
                }
                Console.WriteLine("Thread1: released lockB");
            }
            Console.WriteLine("Thread1: released lockA and finished");
        });

        var thread2 = new Thread(() =>
        {
            Console.WriteLine("Thread2: attempting to acquire lockB");
            lock (_lockB)
            {
                Console.WriteLine("Thread2: acquired lockB");
                Thread.Sleep(200); // give other thread time to run and acquire lockA
                Console.WriteLine("Thread2: attempting to acquire lockA");
                lock (_lockA)
                {
                    Console.WriteLine("Thread2: acquired lockA");
                }
                Console.WriteLine("Thread2: released lockA");
            }
            Console.WriteLine("Thread2: released lockB and finished");
        });

        thread1.Start();
        thread2.Start();

        // The program will block here because of the deadlock.
        thread1.Join();
        thread2.Join();

        Console.WriteLine("Both threads finished (this line will not be reached due to deadlock)");
    }

    private void AvoidDeadlock()
    {
        var thread1 = new Thread(() =>
        {
            Console.WriteLine("Thread1: attempting to acquire lockA");
            lock (_lockA)
            {
                Console.WriteLine("Thread1: acquired lockA");
                Thread.Sleep(200); // give other thread time to run and acquire lockB
                Console.WriteLine("Thread1: attempting to acquire lockB");
                if (Monitor.TryEnter(_lockB, 1000))
                {
                    try
                    {
                        Console.WriteLine("Thread1: acquired lockB");
                    }
                    finally
                    {
                        Monitor.Exit(_lockB);
                    }
                }
                else
                {
                    Console.WriteLine("Thread1: could not acquire lockB ");
                }
                Console.WriteLine("Thread1: released lockB");
            }
            Console.WriteLine("Thread1: released lockA and finished");
        });

        var thread2 = new Thread(() =>
        {
            Console.WriteLine("Thread2: attempting to acquire lockB");
            lock (_lockB)
            {
                Console.WriteLine("Thread2: acquired lockB");
                Thread.Sleep(200); // give other thread time to run and acquire lockA
                Console.WriteLine("Thread2: attempting to acquire lockA");
                if (Monitor.TryEnter(_lockA, 1000))
                {
                    try
                    {
                        Console.WriteLine("Thread2: acquired lockA");
                    }
                    finally
                    {
                        Monitor.Exit(_lockA);
                    }
                }
                else
                {
                    Console.WriteLine("Thread2: could not acquire lockA");
                }
                Console.WriteLine("Thread2: released lockA");
            }
            Console.WriteLine("Thread2: released lockB and finished");
        });

        thread1.Start();
        thread2.Start();

        // The program will block here because of the deadlock.
        thread1.Join();
        thread2.Join();

        Console.WriteLine("Both threads finished (this line will not be reached due to deadlock)");
    }
}
