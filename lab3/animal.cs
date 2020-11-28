using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

[DataContract]
public abstract class Animal : Eukaryote {
    public event Action<Animal, DateTime> Death;
    [DataMember]
    protected readonly DateTime _birthday;
    [DataMember]
    protected int OldAge;
    [DataMember]
    private int _nOfLimbs;
    [DataMember]
    private bool _alive = true;
    
    public DateTime BDay => _birthday;
    public int Limbs {get => _nOfLimbs; private set => _nOfLimbs = value;}
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
        base.IncrementPopulation();
    }

    public Animal(int n = 4) : this(DateTime.Now) => _nOfLimbs = n;

    public override void Reproduce() => Console.WriteLine("Mating...");
    
    public void Live(DateTime time) {
        if (Globals.calcAge(this, time) == OldAge) 
            Death?.Invoke(this, time);
    }

    public void LoseLimbs(int n, DateTime time) {
        if (_nOfLimbs > 0 && n < _nOfLimbs) {
            Console.WriteLine($"Losing {n} of my {_nOfLimbs} limbs!");
            _nOfLimbs -= n;
        }
        else if (_nOfLimbs == n)
            Death?.Invoke(this, time);
        else 
            throw new TooManyLimbsException(this, n);
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Birthday: {_birthday}\nLimbs: {_nOfLimbs}");
    }
}
