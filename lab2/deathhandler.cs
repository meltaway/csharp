using System;
using lab2;

class DeathHandler {
    private static DeathHandler _instance = null;

    private DeathHandler() {}

    public static DeathHandler GetDeath {
        get {
            if (_instance == null) {
                _instance = new DeathHandler();
                return _instance;
            }
            else 
                return _instance;
        }
    }

    public void Kill(Animal a) {
        a.Life = false;
        Console.WriteLine($"RIP this {a.GetType().Name} who was born at {a.bDay}");
    }
}

