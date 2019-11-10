public interface IEmployeeRepository
{
    void AddEmployee(IEmployee employee);

    IEmployee GetEmployeeByName(string employeeName);
}