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
    public class JobsControllerTest
    {
        [Fact]
        public async void TestGetJobs()
        {
            // Arrange
            var expectedJobs = Enumerable.Range(1, 10)
                 .Select(i => new Job { JobId = i, JobTitle = $"SampleJob{i}", MinSalary = 1000, MaxSalary = 4000 });
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestGetJobs));
            var controller = new JobsController(dbContext);
            // Act
            var actionResult = await controller.GetJobs();
            var realResult = actionResult?.Value as IEnumerable<Job>;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedJobs.Count(), realResult.Count());
        }

        [Fact]
        public async void TestGetJobById()
        {
            // Arrange
            string expectedTitle = "SampleJob2";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestGetJobById));
            var controller = new JobsController(dbContext);
            var id = 2;
            // Act
            var actionResult = await controller.GetJob(id);
            var realResult = actionResult?.Value as Job;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedTitle, realResult?.JobTitle);
        }

        [Fact]
        public async void TestPostJob()
        {
            // Arrange
            string expectedTitle = "SampleJob11";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestPostJob));
            var controller = new JobsController(dbContext);
            var job = new Job 
            { 
                JobId = 11, 
                JobTitle = "SampleJob11", 
                MinSalary = 1000, 
                MaxSalary = 4000 
            };
            // Act
            var actionResult = await controller.PostJob(job);
            var ojbResult = actionResult.Result as ObjectResult;
            var realResult = ojbResult.Value as Job;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedTitle, realResult?.JobTitle);
        }

        [Fact]
        public async void TestPutJob()
        {
            // Arrange
            string expectedStatusCode = "204";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestPutJob));
            var controller = new JobsController(dbContext);
            int id = 3;
            // Act
            var jobResult = await controller.GetJob(id);
            var job = jobResult?.Value as Job;
            var actionResult = await controller.PutJob(id, job) as StatusCodeResult;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedStatusCode, actionResult.StatusCode.ToString());
        }

        [Fact]
        public async void TestDeleteJob()
        {
            // Arrange
            string expectedTitle = "SampleJob3";
            var dbContext = DbContextMocker.GetHRManagementContext(nameof(TestDeleteJob));
            var controller = new JobsController(dbContext);
            int id = 3;
            // Act
            var actionResult = await controller.DeleteJob(id);
            var realResult = actionResult?.Value as Job;
            dbContext.Dispose();
            // Assert
            Assert.Equal(expectedTitle, realResult?.JobTitle);
        }
    }
}
