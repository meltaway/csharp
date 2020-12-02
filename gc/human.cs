using System.Collections.Generic;
using System;
using System.Collections;
using System.Runtime.Serialization;

[Serializable]
public class Human : Animal, IMovable, ISwimmable, IComparable, IDisposable, ISerializable {
    private string name;
    public string Name => name;
    public void ChangeName(string name) => name = name;
    
    private string curjob;
    public string Job => curjob;
    public void ChangeJob(string newJob) => jobs.Add(curjob = newJob);
    
    private List<string> jobs = new List<string>();
    public void GetEmploymentHistory() {
        Console.WriteLine($"{this.Name}'s Employment History:");
        for (int i = 0; i < jobs.Count; i++)
            Console.WriteLine($"[{i + 1}] {jobs[i]}");
    }
    public bool FindJobInHistory(string job) => jobs.Contains(job);
    public void DeleteJobEntry(string job) {
        if (jobs.Contains(job))
            jobs.Remove(job);
    }
    
    private string country;
    public void MoveAway(string newCountry) => country = newCountry;
    
    private bool disposed = false;
    private void CleanDispose() {
        if (this.disposed == false)
            jobs.Clear();
        disposed = true;
    }
    private void CleanDestructor() => disposed = true;
    public void Dispose() {
        CleanDispose();
        GC.SuppressFinalize(this);
    }
    ~Human() => CleanDestructor();
    
    protected Human(SerializationInfo info, StreamingContext context) {
        name = info.GetString("name");
        country = info.GetString("country");
        curjob = info.GetString("job");
        jobs = (List<string>)info.GetValue("jobhistory", typeof(List<string>));
        species = info.GetString("Homo Sapiens");
        OldAge = 80;
    }
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter =true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context) {
        info.AddValue("name", name);
        info.AddValue("country", country);
        info.AddValue("job", curjob);
        info.AddValue("jobhistory", jobs);
        info.AddValue("Homo Sapiens", species);
    }
    
    public Human(string name, string country, string job) : base(4) {
        name = name;
        country = country;
        jobs.Add(curjob = job);
        species = "Homo Sapiens";
        OldAge = 80;
    }
    public Human() : this("John Doe", "USA", "unemployed") {}

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Human other = obj as Human;
        if (other != null)
            return this.Name.CompareTo(other.Name);
        else
            throw new ArgumentException("Object is not an Human");
    }

    void IMovable.Move() => Console.WriteLine("Crawling, walking, running...");
    void ISwimmable.Move() => Console.WriteLine("Swimming...");
    
    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Name: {Name}\nCountry: {country}\nJob: {curjob}");
    }
}

