using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.BaseDto
{
    /// <summary>
    /// Base class for Dto classes
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
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
    }
}
