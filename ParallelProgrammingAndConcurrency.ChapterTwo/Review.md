## Chapter two review
for now we only have had .NET and .NET Framework history about the evolution of Threading and Parallelism
mostly introducing feature times, 

## Task and ValueTask 
`Task` is being used when you want to execute a method asynchronously, but some times when CLR prefer to do it synchronously instead, in those cases 
you still pay the overhead computation and time to create the returned `Task` instance, but if you don't want that to happen, 
you can use `ValueTask` it does the same as `Task` but it doesn't have the overhead if the job being handled synchronously.

## Managed Thread pool
its a group of worker threads which all of them are background by default, and they are responsible to handle the tasks being awaited.

after we get to start parallelism starting with `Parallel.Invoke()` method 
which can run multiple actions without order but simultaneously.
the code would be something like this: 
```
Parallel.Invoke(new Action(() => { // do the work here}), and more you can pass here);
```
## Parallel.ForEach and Parallel.For
they preserve the functionality of `for` And `foreach` but in parallel, in the case of use, make sure that you use them in a place that they don't change the shared state,
and if they does, make sure you handle the concurrency with concurrent collections or locking mechanisms.

## Concurrent Collections

### ConcurrentBag<T> 
- un ordered
- null allowed if T is null
- Excellent Thread-safe replacement for Array and List.

specifications: it stores a linked list of items for each thread. and when a thread wants to get items the order of receiving items is based on that thread input, 
e.g. if thread 1 puts 1,2 and 3 into the bag and thread 2 puts 4,5 and 6, when thread 2 wants to read, the items which it self put inside the bag will come out first which would be 4,5 and 6

### ConcurrentQueue<T> 
- follows first in first out (FIFO) like the normal `Queue<T>` but thread safe

### ConcurrentStack<T> 
- follows last in first out (LIFO) like the normal `Stack<T>` but thread safe.

### ConcurrentDictionary<TKey, TValue>
- follows the normal dictionary rules with some added methods like 
- TryAdd() 
- TryUpdate() 
- AddOrUpdate() adds if doesn't exist, update if exists
- GetOrAdd() adds if doesn't exist, get if exists

## Meaning of async await
if you mark a method as async, it means that we can await a function call in this method and this method can be awaited as well.
using `await` ensures us that no code after this line will be executed until the result of awaited method comes back, but till then the active thread can go and do other things

