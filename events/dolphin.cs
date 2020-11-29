using lab2;
using System;

public class Dolphin : Animal, ISwimmable {
    private string _bodyOfWater;
    private string _mood;

    public Dolphin(string bow, string species, string mood) : base(3) {
        _bodyOfWater = bow;
        _species = species;
        _mood = mood;
    }

    public Dolphin() : this("ocean", "common dolphin", "happy") {}
    
    public void Migrate(string newBow) => _bodyOfWater = newBow;

    public void Offend() {
        Console.WriteLine("Oh no! The dolphin is sad!");
        _mood = "sad";
    }

    public void Please() {
        Console.WriteLine("Yay! The dolphin is happy!");
        _mood = "happy";
    }

    public void Anger() {
        Console.WriteLine("Oh no! The dolphin is angry!");
        _mood = "angry";
    }

    public override void Eat() {
        Console.WriteLine("Chomping fish...");
    }

    void ISwimmable.Move(){
        Console.WriteLine("Just keep swimming...");
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Habitat: {_bodyOfWater}\nMood: {_mood}\n");
    }
}