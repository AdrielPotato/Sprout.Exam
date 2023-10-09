using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Factories.Interfaces
{
    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(EmployeeType type, decimal absentDays, decimal workedDays);
    }
}
