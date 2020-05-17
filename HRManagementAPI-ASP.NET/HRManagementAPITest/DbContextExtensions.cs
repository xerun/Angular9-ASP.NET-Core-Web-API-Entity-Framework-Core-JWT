using HRManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManagementAPITest
{
    public static class DbContextExtensions
    {
        public static void Seed(this HRManagementContext dbContext)
        {
            var jobs = Enumerable.Range(1, 10)
                .Select(i => new Job { JobId = i, JobTitle = $"SampleJob{i}", MinSalary = 1000, MaxSalary = 4000 });
            dbContext.Jobs.AddRange(jobs);

            var departments = Enumerable.Range(1, 10)
                .Select(i => new Department { DepartmentId = i, DepartmentName = $"SampleDepartment{i}", ManagerId = i });
            dbContext.Departments.AddRange(departments);

            var employees = Enumerable.Range(1, 10)
                .Select(i => new Employee
                {
                    EmployeeId = i,
                    FirstName = $"SampleFirst{i}",
                    LastName = $"SampleLast{i}",
                    Email = $"SampleEmail{i}@domain.com",
                    PhoneNumber = $"PhoneNumber{i}",
                    HireDate = new DateTime(2020 - 02 - i),
                    JobId = i,
                    Salary = 1200,
                    CommissionPCT = 0.00,
                    ManagerId = i,
                    DepartmentId = i
                }
            ); 
            dbContext.Employees.AddRange(employees);

            dbContext.SaveChanges();
        }
    }
}
