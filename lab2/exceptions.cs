using System.Diagnostics.Contracts;
using System.Data;
using System;
using lab2;

public class TooManyLimbsException : Exception {
    public TooManyLimbsException(Animal a, int n) : base($"{n} is too may limbs to cut off from this {a.GetType().Name}!") {}
    public TooManyLimbsException(string message) : base(message) {}
    public TooManyLimbsException(string message, Exception inner) : base(message, inner) {}
}

public class KillTheDeadException : Exception {
    public KillTheDeadException(Animal a) : base($"You monster! This {a.GetType().Name} is already dead!") {}
    public KillTheDeadException(string message) : base(message) {}
    public KillTheDeadException(string message, Exception inner) : base(message, inner) {}
}

public static class ExceptionHandler {
    public static void onError(Exception e, Animal a) {
        Console.WriteLine($"Oh no! {a.GetType().Name} has encountered an exception: {e.Message}");
    }
}