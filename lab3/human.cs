using System.Collections.Generic;
using System;
using System.Collections;
using System.Runtime.Serialization;

[Serializable]
public class Human : Animal, IMovable, ISwimmable, IComparable, IDisposable, ISerializable {
    private string _firstName;
    private string _lastName;
    public string Name => $"{_firstName} {_lastName}";
    private string _curjob;
    public string Job => _curjob;
    private string _country;

    private List<string> _jobs = new List<string>();

    public void GetEmploymentHistory() {
        Console.WriteLine($"{this.Name}'s Employment History:");
        for (int i = 0; i < _jobs.Count; i++)
            Console.WriteLine($"[{i + 1}] {_jobs[i]}");
    }

    public bool FindJobInHistory(string job) => _jobs.Contains(job);

    public void DeleteJobEntry(string job) {
        if (_jobs.Contains(job))
            _jobs.Remove(job);
    }
    
    protected Human(SerializationInfo info, StreamingContext context) {
        _firstName = info.GetString("first");
        _lastName = info.GetString("last");
        _country = info.GetString("country");
        _curjob = info.GetString("job");
        _jobs = (List<string>)info.GetValue("jobhistory", typeof(List<string>));
        _species = info.GetString("Homo Sapiens");
        OldAge = 80;
    }
    
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter =true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context) {
        info.AddValue("first", _firstName);
        info.AddValue("last", _lastName);
        info.AddValue("country", _country);
        info.AddValue("job", _curjob);
        info.AddValue("jobhistory", _jobs);
        info.AddValue("Homo Sapiens", _species);
    }
    
    public Human(string first, string last, string country, string job) : base(4) {
        _firstName = first;
        _lastName = last;
        _country = country;
        _jobs.Add(_curjob = job);
        _species = "Homo Sapiens";
        OldAge = 80;
    }

    public Human() : this("John", "Doe", "USA", "unemployed") {}

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Human other = obj as Human;
        if (other != null)
            return this.Name.CompareTo(other.Name);
        else
            throw new ArgumentException("Object is not an Human");
    }
    
    public void Dispose() {
        GC.SuppressFinalize(this);
    }
    
    public void ChangeName(string first, string last){
        _firstName = first;
        _lastName = last;
    }

    public void ChangeJob(string newJob) => _jobs.Add(_curjob = newJob);
    public void MoveAway(string newCountry) => _country = newCountry;

    public override void Eat() => Console.WriteLine("Eating McDonald's...");
    void IMovable.Move() => Console.WriteLine("Crawling, walking, running...");
    void ISwimmable.Move() => Console.WriteLine("Swimming...");
    
    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Name: {Name}\nCountry: {_country}\nJob: {_curjob}");
    }
}

