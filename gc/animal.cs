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
    protected readonly DateTime birthday;
    public DateTime BDay => birthday;
    [DataMember]
    protected int OldAge;
    
    [DataMember]
    private bool alive = true;
    public bool Life {
        get => alive; 
        set {
            if (alive)
                alive = value;
            else
                throw new KillTheDeadException(this);
        }
    }
    public void Live(DateTime time) {
        if (Globals.calcAge(this, time) == OldAge) 
            Death?.Invoke(this, time);
    }

    [DataMember]
    private int numberOfLimbs;
    public int Limbs {get => numberOfLimbs; private set => numberOfLimbs = value;}
    public void LoseLimbs(int number, DateTime time) {
        if (numberOfLimbs > 0 && number < numberOfLimbs) {
            Console.WriteLine($"Losing {number} of my {numberOfLimbs} limbs!");
            numberOfLimbs -= number;
        }
        else if (numberOfLimbs == number)
            Death?.Invoke(this, time);
        else 
            throw new TooManyLimbsException(this, number);
    }
    
    private Animal(DateTime bday) {
        birthday = bday;
        base.IncrementPopulation();
    }
    public Animal(int number = 4) : this(DateTime.Now) => numberOfLimbs = number;
    
    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Birthday: {birthday}\nLimbs: {numberOfLimbs}");
    }
}
