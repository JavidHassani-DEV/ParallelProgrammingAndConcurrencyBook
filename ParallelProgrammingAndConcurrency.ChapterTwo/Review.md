## Chapter two review
for now we only have had .NET and .NET Framework history about the evolution of Threading and Parallelism
mostly introducing feature times, 
after we get to start parallelism starting with `Parallel.Invoke()` method 
which can run multiple actions without order but simultaneously.
the code would be something like this: 
```
Parallel.Invoke(new Action(() => { // do the work here}), and more you can pass here);
```
read till end of page 39
