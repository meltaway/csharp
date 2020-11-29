using lab2;
using System;

public class LastUnicorn : Animal, IMovable, ISwimmable {
    private static LastUnicorn _instance = null;
    private string _magic;

    private LastUnicorn() {
        _magic = "life";
        _species = "equus monoceros";
    }

    public void Magic() {
        Console.WriteLine($"Performing {_magic} magic!");
    }

    public void LearnMagic(string magic) {
        _magic = magic;
        Console.WriteLine($"Learned new type of magic: {magic}");
    }

    public static LastUnicorn Instance {
        get {
            if (_instance == null) {
                _instance = new LastUnicorn();
                return _instance;
            }
            else 
                return _instance;
        }
    }

    public override void Eat() {
        Console.WriteLine("Eating sunlight...");
    }

    void IMovable.Move() {
        Console.WriteLine("Running with the wind...");
    }

    void ISwimmable.Move() {
        Console.WriteLine("Gliding through the water...");
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Magic: {_magic}\n");
    }
}