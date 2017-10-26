using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core.BaseEntity
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModificationTime { get; set; }

        public string ModifiedBy { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }

        public string DeletedBy { get; set; }
    }
}
