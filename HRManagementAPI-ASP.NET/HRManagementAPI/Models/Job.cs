using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string JobTitle { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
