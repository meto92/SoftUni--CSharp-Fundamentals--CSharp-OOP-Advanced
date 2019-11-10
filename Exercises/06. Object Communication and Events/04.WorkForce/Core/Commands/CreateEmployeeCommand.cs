public class CreateEmployeeCommand : ICommand
{
    [Inject]
    private IEmployeeRepository employeeRepository;
    [Inject]
    private IEmployeeFactory employeeFactory;
    private string employeeType;
    private string employeeName;

    public CreateEmployeeCommand(string employeeType, string standardEmployeeName)
    {
        this.employeeType = employeeType;
        this.employeeName = standardEmployeeName;
    }

    public void Execute()
    {
        IEmployee employee = 
            this.employeeFactory.CreateEmployee(this.employeeType, this.employeeName);

        this.employeeRepository.AddEmployee(employee);
    }
}