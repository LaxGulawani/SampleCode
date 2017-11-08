using Portal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core.HR
{
    public class ProfilePhoto : Entity<int>
    {
        public int EmployeeId { get; set; }
        
        public string ImageURL { get; set; }
    }
}
