using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestCrudOperationApp.Models
{
    public class Employee
    {
        [Key]
        public Guid EmpNo { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="First name can only be 50 character")]
        public  string Fname{ get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Last name can only be 50 character")]
        public string Lname { get; set; }
        
        [Column(TypeName="Money")]
        [Required]
        public Decimal Salary { get; set; }

    }
}
