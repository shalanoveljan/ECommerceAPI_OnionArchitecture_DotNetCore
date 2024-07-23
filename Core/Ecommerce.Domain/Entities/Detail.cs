﻿using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Detail:EntityBase
    {
        public   string Title { get; set; }
        public   string Description { get; set; }
        public int CategoryId{ get; set; }
        public Category Category { get; set; }
    }
}
