using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;

[Serializable]
public class Humanity: IEnumerable, IEnumerator, IDisposable, ISerializable {
    private Human[] humanity;
    [NonSerialized]
    private int pos = -1;
    
    protected Humanity(SerializationInfo info, StreamingContext context) {
        humanity = (Human[])info.GetValue("humanity", typeof(Human[]));
    }
    
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter =true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context) {
        info.AddValue("humanity", typeof(Human[]));
    }

    public Humanity(int n) {
        humanity = new Human[n];
        Random random = new Random();
        for (int i = 0; i < n; i++) 
            humanity[i] = new Human("Human #", i.ToString(),
                "Country " + i.ToString(), Globals.jobs[random.Next(0, 5)]);
    }
    
    public Human this[string name] {
        get {
            foreach(Human h in humanity)
                if (h.Name == name)
                    return h;
            return null;
        }
        set => this[name] = value;
    }

    public IEnumerator GetEnumerator() {
        this.Reset();
        return (IEnumerator)this; 
    }
    
    public bool MoveNext() {
        if (pos < humanity.Length - 1) {
            pos++;
            return true;
        }
        return false;
    }
    public void Reset() => pos = -1;
    public object Current => humanity[pos]; 
    public void Sort() {
        Array.Sort(this.humanity);
    }
    
    public void Dispose() {
        foreach (Human h in humanity)
            h.Dispose();
    }
    ~Humanity() => Dispose();
}

public static class HumanityExtension {
    public static int CurrentJobCount(this Humanity list, string job) {
        int counter = 0;
        foreach (Human h in list) 
            if (h.Job == job)
                counter++;
        return counter;
    }

    public static int HistoryJobCount(this Humanity list, string job) {
        int counter = 0;
        foreach (Human h in list) 
            if (h.FindJobInHistory(job))
                counter++;
        return counter;
    }
}