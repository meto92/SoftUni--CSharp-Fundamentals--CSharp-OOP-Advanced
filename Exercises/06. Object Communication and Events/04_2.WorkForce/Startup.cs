using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    public delegate void WeekPassedEventHandler(object sender, WeekPassedEventArgs args);
    public delegate void JobDoneEventHandler(object sender, JobDoneEventArgs args);

    private static IJob CreateJob(string[] jobParams, Dictionary<string, IEmployee> employeeByName)
    {
        string jobName = jobParams[0];
        int workHoursRequired = int.Parse(jobParams[1]);
        string employeeName = jobParams[2];

        IEmployee employee = employeeByName[employeeName];

        IJob job = new Job(jobName, workHoursRequired, employee);

        return job;
    }

    public static void Main()
    {
        Handler handler = new Handler();
        JobRepository jobRepository = new JobRepository(handler);
        Dictionary<string, IEmployee> employeeByName = new Dictionary<string, IEmployee>();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputParams = input.Split();

            switch (inputParams[0])
            {
                case "Job":
                    IJob job = CreateJob(inputParams.Skip(1).ToArray(), employeeByName);

                    jobRepository.AddJob(job);
                    break;
                case "StandardEmployee":
                    StandardEmployee standardEmployee = new StandardEmployee(inputParams[1]);

                    employeeByName[standardEmployee.Name] = standardEmployee;
                    break;
                case "PartTimeEmployee":
                    PartTimeEmployee partTimeEmployee = new PartTimeEmployee(inputParams[1]);

                    employeeByName[partTimeEmployee.Name] = partTimeEmployee;
                    break;
                case "Pass":
                    jobRepository.PassWeek();
                    break;
                case "Status":
                    jobRepository.PrintJobsStatus();
                    break;
                case "End":
                    return;
            }
        }
    }
}