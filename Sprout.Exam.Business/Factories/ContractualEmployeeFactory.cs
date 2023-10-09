using Sprout.Exam.Business.Factories.Interfaces;

namespace Sprout.Exam.Business.Factories
{
    public class ContractualEmployeeFactory : IEmployee
    {
        private decimal _daysWorked;
        private decimal _dailyRate;

        public decimal DaysWorked
        {
            get { return _daysWorked; }
            set { _daysWorked = value; }
        }

        public decimal DailyRate
        {
            get { return _dailyRate; }
            set { _dailyRate = value; }
        }

        public ContractualEmployeeFactory()
        {
            _dailyRate = 500.00m;
        }

        public ContractualEmployeeFactory(decimal daysWorked) : this()
        {
            _daysWorked = daysWorked;
        }
        public decimal GetSalary()
        {
            return decimal.Round(_dailyRate * _daysWorked, 2, System.MidpointRounding.AwayFromZero);
        }
    }
}
