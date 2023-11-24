using BlazorWasmAppCookieAuth.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmAppCookieAuth.Client.ViewModels
{
    public class VMEditEmployee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name must be provided")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name must be provided")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage ="Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public Department? Department { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public string PhotoPath { get; set; }

        
    }
}
