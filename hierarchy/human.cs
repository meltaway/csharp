using lab1;
using System;

public class Human : Animal {
    private string _firstName;
    private string _lastName;
    //public const string species = "Homo Sapiens";
    public string Name => $"{_firstName} {_lastName}";

    private string _job;
    private string _country;
    
    public Human(string first, string last, string country, string job) : base(4) {
        _firstName = first;
        _lastName = last;
        _country = country;
        _job = job;
        _species = "Homo Sapiens";
    }

    public Human() : this("John", "Doe", "USA", "Unemployed") {
        // _species = "Homo Sapiens";
    }

    public void ChangeName(string first, string last){
        _firstName = first;
        _lastName = last;
    }

    public void ChangeJob(string newJob) => _job = newJob;
    public void MoveAway(string newCountry) => _country = newCountry;

    public override void Eat() {
        Console.WriteLine("Eating McDonald's...");
    }

    public override void Move(){
        Console.WriteLine("Crawling, walking, running...");
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Console.WriteLine($"Name: {Name}\nCountry: {_country}\nJob: {_job}\n");
    }
}