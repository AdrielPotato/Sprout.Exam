using Sprout.Exam.Business.Factories.Interfaces;

namespace Sprout.Exam.Business.Factories
{
    public class RegularEmployeeFactory : IEmployee
    {
        private readonly decimal _absentDays;
        private readonly int _monthlySalary;
        private decimal _tax;

        public decimal Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public RegularEmployeeFactory()
        {
            _tax = .12m;
            _monthlySalary = 20000;
        }
        public RegularEmployeeFactory(decimal absentDays) : this()
        {
            _absentDays = absentDays;
        }

        public decimal GetSalary()
        {
            return decimal.Round(_monthlySalary - AbsentDeduction() - TaxDeduction(), 2, System.MidpointRounding.AwayFromZero);
        }

        private decimal AbsentDeduction()
        {
            return _absentDays * (_monthlySalary / 22m);
        }

        private decimal TaxDeduction()
        {
            return _monthlySalary * _tax;
        }
    }
}
