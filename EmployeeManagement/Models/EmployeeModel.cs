using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Address { get; set; }

        [Range(18, 100, ErrorMessage = "Employee's age must be 18+")]
        public int Age { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        public bool IsNew { get; set; } = true;
    }
}