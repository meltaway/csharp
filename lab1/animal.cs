using lab1;
using System;

public abstract class Animal : Eukaryote {
    protected readonly DateTime _birthday;
    private int _nOfLimbs;
    public int Limbs {get; private set;}

    private Animal(DateTime bday) {
        _birthday = bday;
        base.IncrementPopulation();
    }

    public Animal(int n = 4) : this(DateTime.Now) { //calls private constructor + sets limbs
        _nOfLimbs = n;
    }

    //public Animal() : this(4) {} //calls limb constructor

    public override void Reproduce() {
        Console.WriteLine("Mating...");
    }

    public override void Eat() {
        Console.WriteLine("Consuming food...");
    }

    public override void Move(){
        Console.WriteLine("Moving limbs...");
    }

    public void LoseLimbs(int n) {
        if (_nOfLimbs > 0) {
            Console.WriteLine($"Losing {n} of my {_nOfLimbs} limbs!");
            _nOfLimbs -= n;
        }
        else {
            Console.WriteLine("Can't handle so much damage...");
        }
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Birthday: {_birthday}\nLimbs: {_nOfLimbs}\n");
    }
}