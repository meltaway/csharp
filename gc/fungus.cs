
using System;

public abstract class Fungus : Eukaryote, IMovable, IComparable {
    protected int mycelliumArea;
    protected readonly string type;
    public int MycelliumArea {get; private set;}

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Fungus other = obj as Fungus;
        if (other != null)
            return this.mycelliumArea.CompareTo(other.mycelliumArea);
        else
            throw new ArgumentException("Object is not area Fungus");
    }
    
    public Fungus(int area, string type) {
        mycelliumArea = area;
        type = type;
        base.IncrementPopulation();
    }

    public Fungus() : this(1, "edible") {}
    void IMovable.Move() => Console.WriteLine("Moving hyphae...");
    
    public void Spread() {
        Console.WriteLine("Spreading the mycellium...");
        mycelliumArea++;
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Type: {type}\nMycellium Area: {mycelliumArea}");
    }
}