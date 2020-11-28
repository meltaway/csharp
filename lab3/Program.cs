using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

class Program {
    static void Main(string[] args) {
        DateTime worldTime = DateTime.Now;
        List<Animal> animals = new List<Animal>();
        animals.Add(new Dolphin());
        foreach (var animal in animals) {
            animal.Death += Globals.animalDeathLogger;
        }
        
        System.Timers.ElapsedEventHandler onWorldTimeUpdate = delegate (object sender, System.Timers.ElapsedEventArgs e) 
        {
            worldTime = worldTime.AddYears(1);
            animals[0].Live(worldTime);
            Console.WriteLine($"[{worldTime}] Updating...");
        };
        System.Timers.Timer worldTimer = new System.Timers.Timer(1000);
        worldTimer.AutoReset = true;
        worldTimer.Elapsed += onWorldTimeUpdate;
        worldTimer.Start();
        Console.ReadKey();

        Humanity h = new Humanity(5);
        int c = h.CurrentJobCount("dev");

        Human human = new Human();
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream("data.bin", FileMode.Create)) {
            formatter.Serialize(stream, human);
        }
        
        Human dp;
        using (Stream stream = new FileStream("data.bin", FileMode.Open)) {
            dp = (Human) formatter.Deserialize(stream);
        }
        
        dp.ShowInfo();
        
        Dolphin d = new Dolphin();
        using (Stream stream = new FileStream("data.json", FileMode.Create)) {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dolphin));
            ser.WriteObject(stream, d);
            stream.Position = 0;
        }
        
        using (Stream stream = new FileStream("data.json", FileMode.Open)) {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dolphin));
            stream.Position = 0;
            d = (Dolphin)ser.ReadObject(stream);
        }
        
        d.ShowInfo();
        
        Humanity list = new Humanity(5);
        Console.WriteLine(list.CurrentJobCount("cook"));
    }
}

