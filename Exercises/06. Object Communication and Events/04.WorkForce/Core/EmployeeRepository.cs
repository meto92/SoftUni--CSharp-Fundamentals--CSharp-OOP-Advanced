using System;
using System.Collections.Generic;

public class EmployeeRepository : IEmployeeRepository
{
    private const string EmployeeNotFoundMessage = "Employee not found.";

    private Dictionary<string, IEmployee> employeeByName;

    public EmployeeRepository()
    {
        this.employeeByName = new Dictionary<string, IEmployee>();
    }

    public void AddEmployee(IEmployee employee)
    {
        this.employeeByName[employee.Name] = employee;
    }

    public IEmployee GetEmployeeByName(string employeeName)
    {
        if (!this.employeeByName.TryGetValue(employeeName, out IEmployee employee))
        {
            throw new InvalidOperationException(EmployeeNotFoundMessage);
        }

        return employee;
    }
}