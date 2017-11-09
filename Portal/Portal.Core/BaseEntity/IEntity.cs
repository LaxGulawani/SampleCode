using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core.BaseEntity
{
    /// <summary>
    /// Base entity Interface for Base Entity abstract class
    /// </summary>
    /// <typeparam name="TPrimaryKey">DataType for the Primary Key Id column</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Default Prrimary Key column
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
