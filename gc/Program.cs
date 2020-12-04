using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        // works
        // MakeSomeGarbage();
        // Console.WriteLine("Memory used before collection:       {0:N0}", 
        //     GC.GetTotalMemory(false));
        // GC.Collect();
        // Console.WriteLine("Memory used after full collection:   {0:N0}", 
        //     GC.GetTotalMemory(true));

        // works
        // Humanity h = new Humanity(Globals.maxGarbage);
        // Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);
        // h = MakeSomeGarbage();
        //
        // Console.WriteLine("Generation: {0}", GC.GetGeneration(h));
        // Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
        //
        // GC.Collect(0);
        //
        // Console.WriteLine("Generation: {0}", GC.GetGeneration(h));
        // Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
        //
        // GC.Collect(2);
        //
        // Console.WriteLine("Generation: {0}", GC.GetGeneration(h));
        // Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

        //works
        // Amanita a = null;
        // for (int i = 0; i < Globals.maxGarbage; i++)
        //     a = new Amanita();
        //
        // a = null;
        // GC.Collect();
        // GC.WaitForPendingFinalizers();
        //
        // for(int i = 0; i < Globals.maxGarbage; i++)
        //     Console.WriteLine("After finalization");
        
        //works
        // Amanita a = new Amanita();
        // a = null;
        // GC.Collect();
        // Amanita.instance = null;
        // GC.Collect();
        
        // works
        // int cacheSize = 50;
        // Random r = new Random();
        // Cache c = new Cache(cacheSize);
        //
        // string DataName = "";
        // GC.Collect(0);
        //
        // for (int i = 0; i < c.Count; i++) {
        //     int index = r.Next(c.Count);
        //     DataName = c[index].Name;
        // }
        //
        // double regenPercent = c.RegenerationCount/(double)c.Count;
        // Console.WriteLine("Cache size: {0}, Regenerated: {1:P2}", c.Count, regenPercent);
    }
    
    public class Cache {
        static Dictionary<int, WeakReference> _cache;
        int regenCount = 0;

        public Cache(int count) {
            _cache = new Dictionary<int, WeakReference>();
            // Add objects with a short weak reference to the cache.
            for (int i = 0; i < count; i++)
                _cache.Add(i, new WeakReference(new Human("Human #" + i.ToString(), "USA", "Unemployed"), false));
        }
        
        public int Count => _cache.Count;
        public int RegenerationCount => regenCount; 
        
        public Human this[int index] {
            get {
                Human h = _cache[index].Target as Human;
                if (h == null) {
                    // If the object was reclaimed, generate a new one.
                    Console.WriteLine("Regenerate object at {0}: Yes", index);
                    h = new Human("Human #" + index.ToString(), "USA", "Unemployed");
                    _cache[index].Target = h;
                    regenCount++;
                }
                else {
                    // Object was obtained with the weak reference.
                    Console.WriteLine("Regenerate object at {0}: No", index);
                }

                return h;
            }
        }
    }

    static Humanity MakeSomeGarbage() {
        Human h;
        Humanity c = new Humanity(Globals.maxGarbage);
        for (int i = 0; i < Globals.maxGarbage; i++) 
            h = new Human();
        return c;
    }
}
