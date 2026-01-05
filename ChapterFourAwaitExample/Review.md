## Background threads
threads are created with `IsBackground = false` by default, but you can change it and make it a background thread,

### Difference between background and foreground threads
background threads are kind of less important that foreground threads, 
if application suddenly stops, it first waits for all foreground threads to finish their current work and then stops the program, 
but application doesn't care about background threads in this case. 

### When to use background threads and when not
as everything is a trade off in our world. using background thread is logical when the operation that you doing with it is not critical 
like database transactions, saving application state or etc. but for times when you do things which you think the performance gain is more than the risk
use background threads and enjoy.

## Benefits of async/await programming
using async await may not show it self in a backend application, but it's surprisingly good in the front-end applications, 
in front-end application, when main thread does something synchronously, UI gets blocked, but if you do it asynchronously, the UI stays responstive during the time the awaited process is being done, 


### Using Task.WhenAll
`Task.WhenAll` helps you run multiple async operation with same return type, it looks like the `Parallel.Invoke` but for Tasks
