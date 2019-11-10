using System.Linq;
using System.Reflection;

public class CommandParser : ICommandParser
{
    private ISubject subject;
    private IEmployeeRepository employeeRepository;
    private IEmployeeFactory employeeFactory;
    private IJobFactory jobFactory;
    private IOutputWriter writer;

    public CommandParser(
        ISubject subject, 
        IEmployeeRepository employeeRepository, 
        IEmployeeFactory employeeFactory, 
        IJobFactory jobFactory, 
        IOutputWriter writer)
    {
        this.subject = subject;
        this.employeeRepository = employeeRepository;
        this.employeeFactory = employeeFactory;
        this.jobFactory = jobFactory;
        this.writer = writer;
    }

    private void InjectFields(ICommand command)
    {
        FieldInfo[] fieldsToInject = command.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fieldsToInject
            .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute))))
        {
            field.SetValue(command,
                this.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(f => f.FieldType == field.FieldType)
                    .GetValue(this));
        }
    }

    public ICommand ParseCommand(string input)
    {
        string[] data = input.Split();

        ICommand command = null;

        switch (data[0])
        {
            case "Job":
                string jobName = data[1];
                int workHoursRequired = int.Parse(data[2]);
                string employeeName = data[3];
                IEmployee employee = this.employeeRepository.GetEmployeeByName(employeeName);

                command = new CreateJobCommand(jobName, workHoursRequired, employee);
                break;
            case nameof(StandardEmployee):
            case nameof(PartTimeEmployee):
                string employeeToCreateName = data[1];

                command = new CreateEmployeeCommand(data[0], employeeToCreateName);
                break;
            case "Pass":
                command = new PassWeekCommand();
                break;
            case "Status":
                command = new StatusCommand();
                break;
            case "End":
                command = new EndCommand();
                break;
        }

        InjectFields(command);

        return command;
    }
}