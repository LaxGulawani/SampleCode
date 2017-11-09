using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.BaseDto
{
    /// <summary>
    /// Base Interface of Data transfer object
    /// </summary>
    /// <typeparam name="TPrimaryKey">DataType of Dto class</typeparam>
    public interface IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// Primary Key Id
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
