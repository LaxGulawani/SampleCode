using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Core.BaseEntity
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
