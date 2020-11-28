
using System;

public abstract class Fungus : Eukaryote, IMovable, IComparable {
    protected int _mycelliumArea;
    protected readonly string _type;
    public int MycelliumArea {get; private set;}

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Fungus other = obj as Fungus;
        if (other != null)
            return this._mycelliumArea.CompareTo(other._mycelliumArea);
        else
            throw new ArgumentException("Object is not a Fungus");
    }
    
    public Fungus(int a, string type) {
        _mycelliumArea = a;
        _type = type;
        base.IncrementPopulation();
    }

    public Fungus() : this(1, "edible") {}

    public override void Reproduce() => Console.WriteLine("Reproducing using spores!");
    public override void Eat() => Console.WriteLine("Consuming nutrients from the ground...");
    void IMovable.Move() => Console.WriteLine("Moving hyphae...");
    
    public void Spread() {
        Console.WriteLine("Spreading the mycellium...");
        _mycelliumArea++;
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Type: {_type}\nMycellium Area: {_mycelliumArea}");
    }
}