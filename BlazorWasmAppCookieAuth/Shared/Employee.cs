using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmAppCookieAuth.Shared
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="First Name must be provided")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name must be provided")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public Department? Department { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
