using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Application.HR.Dto
{
    public class EmployeeListDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
        
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }        

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [Display(Name = "Date Of Joining")]
        public DateTime DateOfJoining { get; set; }

        [Display(Name = "Date of Leaving")]
        public DateTime? DateofLeaving { get; set; }

        public int UserId { get; set; }

        public int? ProfilePhotoId { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "Designation Start Date")]
        public DateTime DesignationStartDate { get; set; }

        [Display(Name = "Designation End Date")]
        public DateTime DesignationEndDate { get; set; }

        public List<DesignationListDto> DesignationList { get; set; }

        public List<ProfilePhotoListDto> ProfilePhotoList { get; set; }
    }
}
