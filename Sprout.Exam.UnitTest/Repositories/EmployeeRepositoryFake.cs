using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.UnitTest.Repositories
{
    public class EmployeeRepositoryFake : IEmployeeRepository
    {
        private List<Employee> _employees;

        public EmployeeRepositoryFake()
        {
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FullName = "Harry Potter",
                    Birthdate = new DateTime(1980,07,31),
                    Tin = "123456789",
                    EmployeeTypeId = 1,
                    IsDeleted = false,
                },
                new Employee()
                {
                    Id = 1,
                    FullName = "Hermione Granger",
                    Birthdate = new DateTime(1979,09,19),
                    Tin = "123456789",
                    EmployeeTypeId = 1,
                    IsDeleted = false,
                },
                new Employee()
                {
                    Id = 1,
                    FullName = "Ron Weasley",
                    Birthdate = new DateTime(1980,03,1),
                    Tin = "123456789",
                    EmployeeTypeId = 1,
                    IsDeleted = false,
                },
                new Employee()
                {
                    Id = 1,
                    FullName = "Neville Longbottom",
                    Birthdate = new DateTime(1980,06,30),
                    Tin = "123456789",
                    EmployeeTypeId = 2,
                    IsDeleted = false,
                }
            };
        }


        public async Task<bool> CreateAsync(Employee employee)
        {
            await Task.Delay(0);
            _employees.Add(employee);
            return true;
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            await Task.Delay(0);
            employee.IsDeleted = true;
            return true;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            await Task.Delay(0);
            return _employees.Find(x => x.Id == id);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            await Task.Delay(0);
            return _employees.ToList();
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            await Task.Delay(0);
            return true;
        }
    }
}
