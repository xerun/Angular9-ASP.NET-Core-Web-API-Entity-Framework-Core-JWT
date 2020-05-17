using HRManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Models
{
    public class HRManagementContext:DbContext, IDepartmentDataSource, IJobDataSource
    {
        public HRManagementContext(DbContextOptions<HRManagementContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employees; }
        }
        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }

        IQueryable<Employee> IJobDataSource.Employees
        {
            get { return Employees; }
        }
        IQueryable<Job> IJobDataSource.Jobs
        {
            get { return Jobs; }
        }
    }
}
