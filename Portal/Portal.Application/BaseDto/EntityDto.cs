using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.BaseDto
{
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModificationTime { get; set; }

        public string ModifiedBy { get; set; }
    }
}
