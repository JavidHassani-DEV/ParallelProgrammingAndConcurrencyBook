# Best Practices of Managed Threading

## Handling static objects in managed threads
when you call an static class properties or methods, the compiler first calls it's static constructor and then execute the method.

## Locking
using locking like other features in a language is a double-edged sword, if you use it properly it can help you but if you use it improperly it can cause serious issues like
dead lock.

## Dead lock
when two or multiple threads trying to access a locked resource by other thread while they locked a resource needed by other thread.
e.g thread 1 locked resource A and need resource B which is locked resource B and need resource A. in this scenario they cannot continue their work 
since both are locked for infinity.

in some scenarios assign time out for the lock can be helpful to avoid dead lock.
also in scenarios that you only need to lock the write operation you can use ReaderWriterLockSlim class to allow multiple threads to read the resource simultaneously while only one thread can write to it.

## Race condition
A race condition occurs when multiple threads or processes concurrently read and write the same resource and the correct outcome depends on the timing or order of those operations.
For example, on an e-commerce site two users might attempt to purchase the last available item at the same time; without proper coordination the item could be sold twice.