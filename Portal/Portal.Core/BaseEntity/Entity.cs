using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core.BaseEntity
{
    /// <summary>
    /// Base Entity classes for all entity classes to derive from it
    /// </summary>
    /// <typeparam name="TPrimaryKey">DataType of Primary Key Id column </typeparam>
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Default Primary Key column with provided data type
        /// </summary>
        public TPrimaryKey Id { get; set; }

        /// <summary>
        /// Create Datetime of entity record
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Creator User Id
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Modification Datetime of entity record
        /// </summary>
        public DateTime? ModificationTime { get; set; }

        /// <summary>
        /// Entity modifier User Id
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Provision for record soft delete
        /// </summary>
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// Record deletion DateTime
        /// </summary>
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// User Id of record deleter 
        /// </summary>
        public string DeletedBy { get; set; }
    }
}
