using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

[DataContract]
public class Dolphin : Animal, ISwimmable {
    [DataMember]
    private string bodyOfWater;
    public void Migrate(string bodyOfWater) => bodyOfWater = bodyOfWater;

    public Dolphin(string bodyOfWater, string species, string mood) : base(3) {
        bodyOfWater = bodyOfWater;
        species = species;
        OldAge = 20;
    }

    public Dolphin() : this("ocean", "common dolphin", "happy") {}

    void ISwimmable.Move() => Console.WriteLine("Just keep swimming...");
    
    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Habitat: {bodyOfWater}");
    }
}