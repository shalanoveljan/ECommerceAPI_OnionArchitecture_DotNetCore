﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Common
{
    public abstract class EntityBase:IEntityBase
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } =DateTime.Now;
        public DateTime UpdatedDate { get; set; }

        public int IsDeleted { get; set; }
    }
}
