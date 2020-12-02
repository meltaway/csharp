using System;

public class Globals {
    public static Func<Animal, DateTime, int> calcAge = (animal, time) => time.Year - animal.BDay.Year;

    public static Action<Animal, DateTime> animalDeathHandler = (animal, time) => {
        animal.Life = false;
        Console.WriteLine($"{animal.GetType().Name} aged {calcAge(animal, time)} died at {time} :(");
    };

    public static string[] jobs = { "cook", "frontend dev", "backend dev", "unemployed", "wizard" };
    
    public const int maxGarbage = 1000;
}
