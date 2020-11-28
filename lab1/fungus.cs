using lab1;
using System;

public abstract class Fungus : Eukaryote {
    protected int _mycelliumArea;
    protected readonly string _type;
    public int MycelliumArea {get; private set;}

    public Fungus(int a, string type) {
        _mycelliumArea = a;
        _type = type;
        base.IncrementPopulation();
    }

    public Fungus() : this(1, "edible") {}

    public void Reproduce(bool sexual) {
        base.Reproduce();
        if (sexual)
            Console.WriteLine("...sexually!");
        else 
            Console.WriteLine("...using spores!");
    }

    public override void Eat() {
        Console.WriteLine("Consuming nutrients from the ground...");
    }

    public override void Move(){
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