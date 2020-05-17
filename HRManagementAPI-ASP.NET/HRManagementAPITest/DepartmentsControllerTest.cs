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
    public class DepartmentsControllerTest
    {
        [Fact]
        public async void TestGetDepartments()
        {
            // Arrange
            var expectedDepartments = Enumerable.Range(1, 10)
                .Select(i => new Department { DepartmentId = i, DepartmentName = $"SampleDepartment{i}", ManagerId = i });
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestGetDepartments));
            var controller = new DepartmentsController(dbContext);
            // Act
            var actionResult = await controller.GetDepartments();
            var realResult = actionResult?.Value as IEnumerable<Department>;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedDepartments.Count(), realResult.Count());
        }

        [Fact]
        public async void TestGetDepartmentById()
        {
            // Arrange
            string expectedName = "SampleDepartment2";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestGetDepartmentById));
            var controller = new DepartmentsController(dbContext);
            var id = 2;
            // Act
            var actionResult = await controller.GetDepartment(id);
            var realResult = actionResult?.Value as Department;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedName, realResult?.DepartmentName);
        }

        [Fact]
        public async void TestPostDepartment()
        {
            // Arrange
            string expectedName = "SampleDepartment11";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestPostDepartment));
            var controller = new DepartmentsController(dbContext);
            var department = new Department 
            { 
                DepartmentId = 11, 
                DepartmentName = "SampleDepartment11", 
                ManagerId = null 
            };
            // Act
            var actionResult = await controller.PostDepartment(department);
            var ojbResult = actionResult.Result as ObjectResult;
            var realResult = ojbResult.Value as Department;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedName, realResult?.DepartmentName);
        }

        [Fact]
        public async void TestPutDepartment()
        {
            // Arrange
            string expectedStatusCode = "204";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestPutDepartment));
            var controller = new DepartmentsController(dbContext);
            int id = 3;
            // Act
            var DepartmentResult = await controller.GetDepartment(id);
            var Department = DepartmentResult?.Value as Department;
            var actionResult = await controller.PutDepartment(id, Department) as StatusCodeResult;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedStatusCode, actionResult.StatusCode.ToString());
        }

        [Fact]
        public async void TestDeleteDepartment()
        {
            // Arrange
            string expectedTitle = "SampleDepartment3";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestDeleteDepartment));
            var controller = new DepartmentsController(dbContext);
            int id = 3;
            // Act
            var actionResult = await controller.DeleteDepartment(id);
            var realResult = actionResult?.Value as Department;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedTitle, realResult?.DepartmentName);
        }
    }
}
