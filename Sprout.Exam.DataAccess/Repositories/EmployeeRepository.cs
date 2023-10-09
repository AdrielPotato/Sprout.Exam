using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.DataAccess.Data.Application;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _appDbContext.Employees.Where(x=>x.IsDeleted != true).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _appDbContext.Employees.SingleOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);
        }

        public async Task<bool> CreateAsync(Employee employee)
        {
            _appDbContext.Add(employee);
            return (await _appDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _appDbContext.Update(employee);
            return (await _appDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            employee.IsDeleted = true;

            _appDbContext.Employees.Update(employee);
            return (await _appDbContext.SaveChangesAsync() > 0);
        }
    }
}
