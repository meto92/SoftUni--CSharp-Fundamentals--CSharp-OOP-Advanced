using System;

public class EmployeeFactory : IEmployeeFactory
{
    private const string UnknownEmployeeType = "Unknown employee type: {0}";

    public IEmployee CreateEmployee(string employeeType, string employeeName)
    {
        Type type = Type.GetType(employeeType);

        if (type == null)
        {
            throw new NotSupportedException(
                string.Format(UnknownEmployeeType, employeeType));
        }

        IEmployee employee = Activator.CreateInstance(type, employeeName) as IEmployee;

        return employee;
    }
}