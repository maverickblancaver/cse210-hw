using System;
using System.Collections.Generic;

namespace ResumeProgram
{
    // Job class
    public class Job
    {
        private string _jobTitle;
        private string _company;
        private int _startYear;
        private int _endYear;

        // Constructor
        public Job(string jobTitle, string company, int startYear, int endYear)
        {
            _jobTitle = jobTitle;
            _company = company;
            _startYear = startYear;
            _endYear = endYear;
        }

        // Display method
        public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }

    // Resume class
    public class Resume
    {
        private string _personName;
        private List<Job> _jobs;

        // Constructor
        public Resume(string personName)
        {
            _personName = personName;
            _jobs = new List<Job>();
        }

        // AddJob method
        public void AddJob(Job job)
        {
            _jobs.Add(job);
        }

        // Display method
        public void Display()
        {
            Console.WriteLine($"Name: {_personName}");
            Console.WriteLine("Jobs:");
            foreach (var job in _jobs)
            {
                job.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating Job instances
            Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
            Job job2 = new Job("Manager", "Apple", 2022, 2023);

            // Testing Job Display method
            job1.Display();
            job2.Display();
            Console.WriteLine();

            // Creating Resume instance
            Resume myResume = new Resume("Maverick Blancaver");

            // Adding jobs to the resume
            myResume.AddJob(job1);
            myResume.AddJob(job2);

            // Testing Resume Display method
            myResume.Display();
        }
    }
}
