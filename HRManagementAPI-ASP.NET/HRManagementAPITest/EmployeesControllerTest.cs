using HRManagement.Controllers;
using HRManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HRManagementAPITest
{
    public class EmployeesControllerTest
    {
        [Fact]
        public async void TestGetEmployees()
        {
            // Arrange
            var expectedEmployees = Enumerable.Range(1, 10)
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
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestGetEmployees));
            var controller = new EmployeesController(dbContext);
            // Act
            var actionResult = await controller.GetEmployees();
            var realResult = actionResult?.Value as IEnumerable<Employee>;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedEmployees.Count(), realResult.Count());
        }

        [Fact]
        public async void TestGetEmployeeById()
        {
            // Arrange
            string expectedName = "SampleFirst2";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestGetEmployeeById));
            var controller = new EmployeesController(dbContext);
            var id = 2;
            // Act
            var actionResult = await controller.GetEmployee(id);
            var realResult = actionResult?.Value as Employee;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedName, realResult?.FirstName);
        }

        [Fact]
        public async void TestPostEmployee()
        {
            // Arrange
            string expectedName = "SampleFirst11";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestPostEmployee));
            var controller = new EmployeesController(dbContext);
            var employee = new Employee 
            {
                EmployeeId = 11,
                FirstName = "SampleFirst11",
                LastName = "SampleLast11",
                Email = "SampleEmail11@domain.com",
                PhoneNumber = "PhoneNumber11",
                HireDate = new DateTime(2020 - 02 - 01),
                JobId = 1,
                Salary = 1200,
                CommissionPCT = 0.00,
                ManagerId = 1,
                DepartmentId = 1
            };
            // Act
            var actionResult = await controller.PostEmployee(employee);
            var ojbResult = actionResult.Result as ObjectResult;
            var realResult = ojbResult.Value as Employee;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedName, realResult?.FirstName);
        }

        [Fact]
        public async void TestPutEmployee()
        {
            // Arrange
            string expectedStatusCode = "204";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestPutEmployee));
            var controller = new EmployeesController(dbContext);
            int id = 3;
            // Act
            var EmployeeResult = await controller.GetEmployee(id);
            var Employee = EmployeeResult?.Value as Employee;
            var actionResult = await controller.PutEmployee(id, Employee) as StatusCodeResult;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedStatusCode, actionResult.StatusCode.ToString());
        }

        [Fact]
        public async void TestDeleteEmployee()
        {
            // Arrange
            string expectedTitle = "SampleLast3";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestDeleteEmployee));
            var controller = new EmployeesController(dbContext);
            int id = 3;
            // Act
            var actionResult = await controller.DeleteEmployee(id);
            var realResult = actionResult?.Value as Employee;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedTitle, realResult?.LastName);
        }
    }
}
