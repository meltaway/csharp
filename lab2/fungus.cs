using lab2;
using System;

public abstract class Fungus : Eukaryote, IMovable {
    protected int _mycelliumArea;
    protected readonly string _type;
    public int MycelliumArea {get; private set;}

    public Fungus(int a, string type) {
        _mycelliumArea = a;
        _type = type;
        base.IncrementPopulation();
    }

    public Fungus() : this(1, "edible") {}

    public override void Reproduce() {
        Console.WriteLine("Reproducing using spores!");
    }

    public override void Eat() {
        Console.WriteLine("Consuming nutrients from the ground...");
    }

    void IMovable.Move() {
        Console.WriteLine("Moving hyphae...");
    }

    public void Spread() {
        Console.WriteLine("Spreading the mycellium...");
        _mycelliumArea++;
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Type: {_type}\nMycellium Area: {_mycelliumArea}\n");
    }
}