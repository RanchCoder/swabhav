using EmployeeLoginServiceApp.DatabaseContext;
using EmployeeLoginServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLoginServiceApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _dbContext;

        public EmployeeRepository(EmployeeDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddUserCredential(UserCredential userCredential)
        {
            _dbContext.UserCrendtials.Add(userCredential);
        }
      
        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
        }

        public bool IsAuthenticUser(string username, string password)
        {
            UserCredential user = _dbContext.UserCrendtials.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            
            if(user != null)
            {
                return true;
            }
            return false;
        }

        public Employee GetEmployeeData(string username,string password)
        {
            UserCredential user = _dbContext.UserCrendtials.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            Employee employee = _dbContext.Employees.Where(emp => emp.Id == user.Employee.Id).FirstOrDefault();
            return employee;
        }
       
        public List<Employee> GetEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.Where(emp => emp.Id == id).FirstOrDefault();
        }

        public bool InitializeTables()
        {
            Employee emp1 = new Employee() { FirstName = "Vishal", LastName = "Singh", Designation = "Manager", Salary = 15000, Department = "IT" };
            UserCredential userCred1 = new UserCredential() { UserName = "vishalS", Password = "vishal1234" };
            userCred1.Employee = emp1;
            emp1.UserCredential = userCred1;
            _dbContext.Employees.Add(emp1);
            _dbContext.UserCrendtials.Add(userCred1);
            int recordUpdated = _dbContext.SaveChanges();
            if(recordUpdated > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}