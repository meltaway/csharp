using System;

public class UnicornSingleton : Animal, IMovable, ISwimmable {
    private static UnicornSingleton instance = null;
    public static UnicornSingleton Instance {
        get {
            if (instance == null) {
                instance = new UnicornSingleton();
                return instance;
            }
            return instance;
        }
        //set => instance = value;
    }
    
    private string magic;
    public void Magic() => Console.WriteLine($"Performing {magic} magic!");
    public void LearnMagic(string magic) {
        magic = magic;
        Console.WriteLine($"Learned new type of magic: {magic}");
    }
    
    //private bool hasFinalized = false;
    
    private UnicornSingleton() {
        magic = "life";
        species = "equus monoceros";
        OldAge = 100;
    }

    void IMovable.Move() => Console.WriteLine("Running with the wind...");
    void ISwimmable.Move() => Console.WriteLine("Gliding through the water...");

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Magic: {magic}");
    }

    // ~LastUnicorn() {
    //     if(hasFinalized == false) {
    //         Console.WriteLine("First finalization");
    //         LastUnicorn._instance = this;
    //         hasFinalized = true;
    //         GC.ReRegisterForFinalize(this);
    //     }
    //     else
    //         Console.WriteLine("Second finalization");
    // }
}