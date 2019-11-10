public class StandardEmployee : Employee
{
    private const int StandartEmployeeWorkHoursPerWeek = 40;

    public StandardEmployee(string name)
        : base(name, StandartEmployeeWorkHoursPerWeek)
    { }
}