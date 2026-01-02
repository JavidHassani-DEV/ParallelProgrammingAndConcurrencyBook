# Best Practices of Managed Threading

## Handling static objects in managed threads
when you call an static class properties or methods, the compiler first calls it's static constructor and then execute the method.

## Locking
using locking like other features in a language is a double-edged sword, if you use it properly it can help you but if you use it improperly it can cause serious issues like
dead lock.

## Dead lock
A deadlock occurs when each of two threads tries to lock a resource the other has already locked. Neither thread can make any further progress
e.g thread 1 locked resource A and need resource B which is locked resource B and need resource A. in this scenario they cannot continue their work 
since both are locked for infinity.

in some scenarios assign time out for the lock can be helpful to avoid dead lock.
also in scenarios that you only need to lock the write operation you can use ReaderWriterLockSlim class to allow multiple threads to read the resource simultaneously while only one thread can write to it.

## Race condition
A race condition occurs when multiple threads or processes concurrently read and write the same resource and the correct outcome depends on the timing or order of those operations.
For example, on an e-commerce site two users might attempt to purchase the last available item at the same time; without proper coordination the item could be sold twice.

## Using Interlocked over lock 
using `Interlocked` over `lock` in simple scenarios like (mathematical operations) is more efficient, because 

## Limitations
as threading might be a good tool to speed your operations up by using multiple threads in it, there is some limitations besides the deadlocks and race conditions.

### Hardware limitations
as you may like to have countless threads, your hardware doesn't let it become true, you have limited amount of threads assigned to your application by the OS, 
so you should use Parallelism when it's effective and worth the benefit, because if you do it too much, you can face thread starvation. 

#### Thread Starvation
it's a situation when thread pool is empty and all the threads are waiting for a locked resource to use it.

### Avoiding Thread Starvation and enjoying the benefits with threading
When you're writing code that uses multiple threads, think of it like managing traffic: your goal is to keep everything flowing smoothly with as few stoplights (locks) as possible.
The key is to design your code so it rarely needs to lock resources. 
Every lock you add is a potential traffic jam where threads have to wait for each other, slowing everything down. 
Also, be smart about where you use parallelism. For tasks like writing to a file,
the operating system already forces things to happen one at a time to prevent chaos, so using more threads there won't help at all.

For operations that involve waiting—like database calls or network requests—use async/await. 
This frees up your main threads to do other work, making your app feel much more responsive instead of just freezing up. 
In short, don't just throw threads at a problem; use them wisely where they'll actually make a difference.

- locks: minimum the usage of locks to reduce the contention over resources between threads
- async/await: use async await on ASP.NET Core controller methods and on IO/CPU bound operations to reduce the load on foreground threads and make your code more responsive. 
- avoid too much threading.