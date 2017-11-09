using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Application.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Legal name is mandatory")]
        public string LegalName { get; set; }
    }
}
