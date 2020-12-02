using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;

[Serializable]
public class Humanity : IEnumerable, IEnumerator, IDisposable, ISerializable {
    private Human[] humanity;
    [NonSerialized] private int pos = -1;
    private bool disposed = false;

    protected Humanity(SerializationInfo info, StreamingContext context) {
        humanity = (Human[]) info.GetValue("humanity", typeof(Human[]));
    }

    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand,
        SerializationFormatter = true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context) {
        info.AddValue("humanity", typeof(Human[]));
    }

    public Humanity(int number) {
        humanity = new Human[number];
        Random random = new Random();
        for (int i = 0; i < number; i++)
            humanity[i] = new Human("Human #" + i.ToString(),
                "Country " + i.ToString(), Globals.jobs[random.Next(0, 5)]);
    }

    public Human this[string name] {
        get {
            foreach (Human human in humanity)
                if (human.Name == name)
                    return human;
            return null;
        }
        set => this[name] = value;
    }

    public IEnumerator GetEnumerator() {
        this.Reset();
        return (IEnumerator) this;
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
    public void Sort() => Array.Sort(this.humanity);
    
    private void CleanDispose() {
        if (this.disposed == false)
            foreach (Human human in humanity)
                human.Dispose();
        disposed = true;
    }
    private void CleanDestructor() => disposed = true;
    public void Dispose() {
        CleanDispose();
        GC.SuppressFinalize(this);
    }
    ~Humanity() => CleanDestructor();
}

public static class HumanityExtension {
    public static int CurrentJobCount(this Humanity list, string job) {
        int counter = 0;
        foreach (Human human in list) 
            if (human.Job == job)
                counter++;
        return counter;
    }

    public static int HistoryJobCount(this Humanity list, string job) {
        int counter = 0;
        foreach (Human human in list) 
            if (human.FindJobInHistory(job))
                counter++;
        return counter;
    }
}