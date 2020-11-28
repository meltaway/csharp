using System;

public class Globals {
    public static Func<Animal, DateTime, int> calcAge = (a, time) => time.Year - a.BDay.Year;

    public static Action<Animal, DateTime> animalDeathLogger = (a, time) => {
        a.Life = false;
        Console.WriteLine($"{a.GetType().Name} aged {calcAge(a, time)} died at {time} :(");
    };

    public static string[] jobs = { "cook", "frontend dev", "backend dev", "unemployed", "wizard" };
}
