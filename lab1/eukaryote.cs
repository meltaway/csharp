using lab1;
using System;

namespace lab1 {
    public abstract class Eukaryote {
        protected static int _population;
        protected string _species;
        public int Population {get; private set;}

        static Eukaryote() {
            _population = 0;
        }

        protected void IncrementPopulation() {
            _population++;
        }

        public virtual void Reproduce() {
            Console.WriteLine("Reproducing...");
        }

        public virtual void Eat() {
            Console.WriteLine("Consuming nutrients...");
        }

        public virtual void Move() {
            Console.WriteLine("Contracting body...");
        }

        public virtual void ShowInfo() {
            Console.WriteLine($"Species: {_species}\n");
        }
    }
}