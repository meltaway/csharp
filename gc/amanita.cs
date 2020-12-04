
using System;

public class Amanita : Fungus {
    private const string purpose = "insecticide";
    
    public Amanita(string type = "inedible") : base(1, type) {}
    
    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Purpose: {purpose}");
    }

    public static Amanita instance = null;
    private bool hasFinalized = false;
    ~Amanita() {
        if (hasFinalized == false) {
            Console.WriteLine("Finalizing Amanita 1");
            for (int i = 0; i < Globals.maxGarbage; i++) 
                GC.KeepAlive(i);

            Amanita.instance = this;
            hasFinalized = true;
            GC.ReRegisterForFinalize(this);
        }
        else 
            Console.WriteLine("Finalizing Amanita 2");
    }
}