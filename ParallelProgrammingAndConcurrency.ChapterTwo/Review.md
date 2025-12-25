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
read till end of page 39
