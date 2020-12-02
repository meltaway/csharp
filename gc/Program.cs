using System;

class Program {
    static void Main(string[] args) {
        // works
        // Program.MakeSomeGarbage();
        // Console.WriteLine("Memory used before collection:       {0:N0}",
        //     GC.GetTotalMemory(false));
        // GC.Collect();
        // Console.WriteLine("Memory used after full collection:   {0:N0}",
        //     GC.GetTotalMemory(true));
        // doesn't work, microsoft lied to me
        // LastUnicorn u = LastUnicorn.Instance;
        // u = null;
        // GC.Collect();
        // LastUnicorn.Instance = null;
        // GC.Collect();
        // works
        // Humanity h = new Humanity(maxGarbage);
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

    }

    static Humanity MakeSomeGarbage() {
        Human h;
        Humanity c = new Humanity(Globals.maxGarbage);
        for (int i = 0; i < Globals.maxGarbage; i++) 
            h = new Human();
        return c;
    }
}
