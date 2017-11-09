using Portal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Portal.Core
{
    /// <summary>
    /// Domain Entity for Company information
    /// </summary>
    public class Company : Entity<int>
    {
        /// <summary>
        /// Name of the company
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Legal Name of the company
        /// </summary>
        [MaxLength(255)]
        public string LegalName { get; set; }

    }
}
