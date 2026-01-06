# More about async await 

## extra benefits 
one of the things that awaiting async method gives you is a predictable order of execution, 
it is like synchronous execution somehow, but it uses threads more efficiently.

### always await async methods and here is why
its a best practice to await async methods unless you have strong reason to not doing so
because not awaiting async methods cause unpredictable behavior here is a some of them

- unexpected order of execution: you know that your method is being executed on a different thread, but you don't have any control over when it starts and when it finishes
- more complex error handling: awaiting async methods by default throw exceptions to the caller, but if you don't await, the exception cannot reach to the caller by default, which left you 
some other options like using the `Task` instance `Exception` property for exception and `IsFaulted` property to see if the task is being failed or not.


### avoid using Wait() method or Result property
in fact it destroys the purpose of using asynchronous programming because using `Wait()` or `Result` blocks the current thread to wait until the execution of the method being done.
using these methods is not recommended and it cause thread pool threads to deplete fast. 

### some extra features from C# multi threading 
- `Task.Run` creates a background thread and execute the function on that.
- `Task.Factory.StartNew` same as `Task.Run` but has `ThreadCreationOptions` which gives you some extra features
- `ContinueWith()` it executes the function you pass on the same thread pool thread which executed the current task 
- `WaitAll` takes a list of functions and blocks the current thread to wait until the execution of all methods passed inside.

### there are some other main suggestions from author which are the following 
- avoid mixing sync and async code,
- avoid using Thread.Sleep in async methods,
- long running async operations should support cancellation 
- don't use async void, use Task or ValueTask for return type
- awaiting method directly is better than creating a Task instance and then await it. 