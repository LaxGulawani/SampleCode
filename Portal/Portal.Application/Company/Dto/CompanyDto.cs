using Portal.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Application.Dto
{
    /// <summary>
    /// Company Dto class
    /// </summary>
    public class CompanyDto : EntityDto<int>
    {        
        /// <summary>
        /// Company Name
        /// </summary>
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        /// <summary>
        /// Company Legal Name
        /// </summary>
        [Required(ErrorMessage ="Legal name is mandatory")]
        public string LegalName { get; set; }
    }
}
