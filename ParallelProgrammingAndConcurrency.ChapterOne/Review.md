# Chapter 1 Review

## what is a process
in simple terms a running application is a process, for example a .exe file when its running is a process.

## what is a thread? 
thread is a single unit of execution with in a process

## what is a Managed thread? 
managed thread is a thread that is created and controlled by CLR(common language runtime)

## diff between background and foreground threads
if all foreground thread stop, application will be stopped to, but background threads are not like that.

## How does .NET handle scheduling managed threads?
by their Priority property which is an enumeration

## How can you pass data to a method in a new thread? 
by delegates like this 
```
// the method should accept object 
var thread = new Thread(Method);

thread.Start(pass the data in here);
```

## How do you register a call back to be invoked when a cancellation is requested?
``` 
cancellationToken.Register(() => 
{
 // do the job here
})
```

## Summary of what is discussed in this chapter. 
this chapter was all about thread management, how to create pause or destroy a thread, 
after that there is data synchronization among threads which is basically locking mechanisms, 
in this chapter they talked about `Monitor` class, then `lock` object, which says that it is an implementation of `Monitor` class as an keyword
after we have `Mutex` which is another construct we have for thread synchronization

### different between lock and mutex
lock is being used within a single process and in a single service, outside of that process lock is unknown, 
but mutex is designed to coordinate work between processes, it can handle the synchronization between multiple processes, 
and useful when in a scenario you need to have access to some data shared between multiple processes.

next we get to `ReaderWriterLockSlim` class, which in simple terms, allows only one writer but multiple reader at a time, 
when a thread tries to write, it blocks all the threads to wait for the new data, but when everyone is reading, there is no limitation.

then we talked about `Thread Scheduling` which in simple terms talks about which thread has the priority over other ones, 
and in .NET thread objects have a `Priority` property which can be modified in order to change the execution priority. 

after that we learn that we cannot destroy threads in .NET, we only allowed to cancel them via cancellation token
you can pass the cancellation token as a parameter to the method you are executing and after that you just need to cancel it outside of the thread space, 
it automatically stops the execution of the thread if it's properly configured.
