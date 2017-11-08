using Portal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core.HR
{
    public class Designation : Entity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
