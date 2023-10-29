//Public class for CRUD operations on Employee Table

using Microsoft.EntityFrameworkCore;
using ConsoleApp.PostgreSQL;

namespace HotCorner.Model
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        

        //CRUD METHODS
        public async Task AddEmployeeAsync(Employee newEmployee)
        {
            try
            {
                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                
                Console.WriteLine(err.Message);
            }
        }

        public async Task<bool> UpdateEmployeeAsync(
            int employeeId, 
            string name = null,
            string email = null,
            string department = null,
            string position = null,
            decimal? salary = null,
            string status = null
        )
        {
            try
            {
                Employee employeeToUpdate = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                if(employeeToUpdate == null)
                {
                    return false;
                }

                if(name != null)
                {
                    employeeToUpdate.EmployeeName = name;
                }
                if(email != null)
                {
                    employeeToUpdate.EmployeeEmail = email;
                }
                if(department != null)
                {
                    employeeToUpdate.Department = department;
                }
                if(position != null)
                {
                    employeeToUpdate.Position = position;
                }
                if(salary != null)
                {
                    employeeToUpdate.Salary = (decimal)salary;
                }
                if(status != null)
                {
                    employeeToUpdate.Status = status;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            try
            {
                Employee employeeToGet = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                return employeeToGet;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                Employee employeeToRemove = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                if(employeeToRemove == null)
                {
                    Console.WriteLine("Employee not found...");
                    return false;
                }
                else
                {
                    _context.Remove(employeeToRemove);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Employee record removed...");
                    return true;
                }

            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }

    }
}