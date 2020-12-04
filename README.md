# Overview
The repo contains some code with added OOP features.

## Hierarchy
A simple class hierarchy to show inheritance. Classes contain different access modifiers and fields.
Constructors: redefined (overridden) default constructor (for child classes), private constructor, static constructor.

## Events
The existing class hierarchy is expanded by adding a Singleton class and an abstract class. Interfaces are implemented using implicit implementation. Events and delegates are used with a handler. A system of creating and handling exceptions in added.

## Serialization
Also contains a rework of the Events code using anonymous functions, lambda expressions and Action/Func types. Collections are added as fields and created, expanded by using extension methods. For sorting, some interfaces are implemented:
```csharp
IComparable, IEnumerable, IEnumerator
```
The code also contains an example of collection serialization (binary) and object serialization (JSON, Data Contract).

## GC
The code is refactored using the rules of clean code (Robert Martin, 2009). You should also read up on refactoring methods (Martin Fowler, 2018). Destructors and Dispose methods were added to some classes to showcase GC methods in Main. You can get more info on them in the official [docs](https://docs.microsoft.com/en-us/dotnet/api/system.gc?view=net-5.0). Garbage collection is also shown by implementing a cache with [WeakReference](https://docs.microsoft.com/en-us/dotnet/api/system.weakreference?view=net-5.0) access.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
All rights reserved.
