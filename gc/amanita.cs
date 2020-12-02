
using System;

public class Amanita : Fungus {
    private const string purpose = "insecticide";
    
    public Amanita(string type = "inedible") : base(1, type) {}
    
    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Purpose: {purpose}");
    }
}