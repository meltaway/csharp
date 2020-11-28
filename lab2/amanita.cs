using lab2;
using System;

public class Amanita : Fungus {
    private const string _purpose = "insecticide";

    public Amanita(string type = "inedible") : base(1, type) {}

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Purpose: {_purpose}\n");
    }
}