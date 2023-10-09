using Sprout.Exam.Business.Factories.Interfaces;
using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployee CreateEmployee(EmployeeType type, decimal absentDays, decimal workedDays)
        {
            IEmployee employeefactory = null;
            switch (type)
            {
                case EmployeeType.Regular:
                    employeefactory = new RegularEmployeeFactory(absentDays);
                    break;
                case EmployeeType.Contractual:
                    employeefactory = new ContractualEmployeeFactory(workedDays);
                    break;
                default:
                    break;
            }

            return employeefactory;
        }
    }
}
