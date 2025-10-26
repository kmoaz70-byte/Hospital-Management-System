using HospitalManagementSystemweb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = ("Department Name"))]
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public IEnumerable<Doctor> Doctors { get; set; }


    }
}
