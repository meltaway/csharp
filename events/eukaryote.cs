using System;
using lab2;

public abstract class Eukaryote : IBasicNeeds {
    protected static int _population;
    protected string _species;
    public int Population {get; private set;}

    static Eukaryote() => _population = 0;
    protected void IncrementPopulation() => _population++;

    public abstract void Reproduce();
    public abstract void Eat();

    public virtual void ShowInfo() {
        Console.WriteLine($"Species: {_species}\n");
    }
}
