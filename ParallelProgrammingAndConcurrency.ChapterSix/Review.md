# Getting Started with TPL (Task Parallel Library)

## IO-Bound operations 
in IO-Bound operations like database transaction, writing or reading on files, http request to other services etc...
its usually recommended to use normal async/await methods to keep the simplicity and take advantage of asynchronous programming
but if you are sure that Parallelism doesn't brake anything and worth it, you can try that as well. 
a good practice is to reduce the calls to IO resources are much as possible, like instead of doing a IO-Bound operation in a loop
gather all that data and do it as a single request, this reduces the overhead and improve the performance 

## CPU-Bound operations
in CPU-Bound operations like serialization, deserialization, processing files, images etc... 
its a good practice to use Parallel loops to speed up the process if you should do a bunch of them, but you have to make sure that the each unit of process is heavy enough 
because if you put light operations in Parallel loops your code will eventually slower, so it will be better if you mind that and maybe put some Benchmarks on them.

## Parallel.For
same as for loop but parallel. it gives you a lambda expression and for doing things like `continue` or `break`
you should use `Break()` and `Stop()` methods
we also have async variation of For, which is ForAsync and you can use it if you need to run your loop asynchronously

## Parallel.ForEach
same as foreach loop but parallel, it works almost like `Parallel.For` but it is well suited if you have a `IEnumerable` of objects needed to iterated on


### Manage risks 
using parallel loops may give you performance but make sure that you aware of possible concurrency problems and encounter them with appropriate synchronization mechanisms.

## Parallel.Invoke
in simple terms this method under the hood turns your input functions to Tasks and run them in a `Task.WaitAll()` function. 
the better option is to use `Task.WhenAll()` if possible because it doesn't block the current thread, but if it's not possible using the Invoke is a cleaner way to 
call those functions in parallel rather than creating Tasks by yourself.

read till 131