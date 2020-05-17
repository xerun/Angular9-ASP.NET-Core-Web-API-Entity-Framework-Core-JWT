using HRManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagementAPITest
{
    class DbContextMocker
    {
        public static HRManagementContext GetHRManagementContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<HRManagementContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new HRManagementContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
