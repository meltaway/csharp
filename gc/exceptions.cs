using System;

public class TooManyLimbsException : Exception {
    public TooManyLimbsException(Animal animal, int number) : base($"{number} is too may limbs to cut off from this {animal.GetType().Name}!") {}
    public TooManyLimbsException(string message) : base(message) {}
    public TooManyLimbsException(string message, Exception inner) : base(message, inner) {}
}

public class KillTheDeadException : Exception {
    public KillTheDeadException(Animal animal) : base($"You monster! This {animal.GetType().Name} is already dead!") {}
    public KillTheDeadException(string message) : base(message) {}
    public KillTheDeadException(string message, Exception inner) : base(message, inner) {}
}

public static class ExceptionHandler {
    public static void onError(Exception exception, Animal animal) {
        Console.WriteLine($"Oh no! {animal.GetType().Name} has encountered an exception: {exception.Message}");
    }
}