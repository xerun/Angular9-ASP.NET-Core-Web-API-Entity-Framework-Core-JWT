using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }
        [Required]
        public double Salary { get; set; }
        public double CommissionPCT { get; set; }
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public int? DepartmentId { get; set; }
        public int JobId { get; set; }
        //public Department Department { get; set; }
    }
}
