using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Application.HR.Dto
{
    public class EmployeeInputDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee number is mandatory")]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Required(ErrorMessage = "First name is mandatory")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
                
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is mandatory")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date Of Birth is mandatory")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is mandatory")]
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Gender is mandatory")]
        [Display(Name = "Date Of Joining")]
        public DateTime DateOfJoining { get; set; }

        [Display(Name = "Date of Leaving")]
        public DateTime? DateofLeaving { get; set; }

        public int UserId { get; set; }

        public int? ProfilePhotoId { get; set; }

        [Required(ErrorMessage = "Profile Image is mandatory")]
        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        [Required]     
        public string DesignationId { get; set; }

        [Required(ErrorMessage = "Designation is mandatory")]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "DesignationStartDate")]
        public DateTime DesignationStartDate { get; set; }

        [Display(Name = "DesignationEndDate")]
        public DateTime DesignationEndDate { get; set; }
    }
}
