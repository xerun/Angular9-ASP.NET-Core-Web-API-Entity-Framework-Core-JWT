using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Models
{
    interface IJobDataSource
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Job> Jobs { get; }
    }
}
