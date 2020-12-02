using System;
using System.Runtime.Serialization;

[DataContract]
public abstract class Eukaryote /*: IBasicNeeds*/ {
    [DataMember]
    protected static int population;
    [DataMember]
    public int Population {get; private set;}
    protected void IncrementPopulation() => population++;
    
    [DataMember]
    protected string species;
    
    static Eukaryote() => population = 0;
    
    public virtual void ShowInfo() => Console.WriteLine($"Species: {species}");
}
