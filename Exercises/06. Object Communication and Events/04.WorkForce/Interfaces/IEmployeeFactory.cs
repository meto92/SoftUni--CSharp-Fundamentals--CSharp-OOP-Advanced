public interface IEmployeeFactory
{
    IEmployee CreateEmployee(string employeeType, string employeeName);
}