using System;
using System.Collections.Generic;

class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;
}

class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        foreach (var job in _jobs)
        {
            Console.WriteLine($"{job._jobTitle} at {job._company} ({job._startYear}–{job._endYear})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job
        {
            _jobTitle = "Petrochemical Engineer",
            _company = "Chevron Plc",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job
        {
            _jobTitle = "Programmer",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        Resume myResume = new Resume
        {
            _name = "Mary Joseph"
        };

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
