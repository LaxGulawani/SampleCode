using Portal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Core.HR
{
    public class Employee : Entity<int>
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfJoining { get; set; }

        public DateTime? DateofLeaving { get; set; }

        public int UserId { get; set; }

        public int? ProfilePhotoId { get; set; }

        [ForeignKey("ProfilePhotoId")]
        public virtual List<ProfilePhoto> ProfilePhotos { get; set; }
                
        public virtual List<EmployeeDesignation> EmployeeDesignations { get; set; }
    }
}
