using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.BaseDto
{
    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
