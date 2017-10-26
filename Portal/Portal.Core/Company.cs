using Portal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core
{
    public class Company : Entity<int>
    {
        public string Name { get; set; }

        public string LegalName { get; set; }

    }
}
