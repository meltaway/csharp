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

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
All rights reserved.