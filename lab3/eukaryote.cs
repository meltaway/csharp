using System;
using System.Runtime.Serialization;

[DataContract]
public abstract class Eukaryote : IBasicNeeds {
    [DataMember]
    protected static int _population;
    [DataMember]
    protected string _species;
    [DataMember]
    public int Population {get; private set;}

    static Eukaryote() => _population = 0;
    protected void IncrementPopulation() => _population++;

    public abstract void Reproduce();
    public abstract void Eat();

    public virtual void ShowInfo() => Console.WriteLine($"Species: {_species}");
    
}
