using lab2;
using System;

public abstract class Animal : Eukaryote {
    protected readonly DateTime _birthday;
    public DateTime bDay => _birthday;

    private int _nOfLimbs;
    public int Limbs {get; set;}

    private bool _alive = true;
    public bool Life {
        get => _alive; 
        set {
            if (_alive)
                _alive = value;
            else
                throw new KillTheDeadException(this);
        }
    }

    private Animal(DateTime bday) {
        _birthday = bday;
        onCriticalDamage += DeathHandler.GetDeath.Kill;
        base.IncrementPopulation();
    }

    public Animal(int n = 4) : this(DateTime.Now) => _nOfLimbs = n;

    public delegate void DeathMethod(Animal a);
    public event DeathMethod onCriticalDamage;

    public override void Reproduce() {
        Console.WriteLine("Mating...");
    }

    public void LoseLimbs(int n) {
        if (_nOfLimbs > 0 && n < _nOfLimbs) {
            Console.WriteLine($"Losing {n} of my {_nOfLimbs} limbs!");
            _nOfLimbs -= n;
        }
        else if (_nOfLimbs == n)
            onCriticalDamage(this);
        else 
            throw new TooManyLimbsException(this, n);
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Birthday: {_birthday}\nLimbs: {_nOfLimbs}\n");
    }
}