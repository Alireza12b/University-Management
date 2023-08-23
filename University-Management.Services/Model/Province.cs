﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management.Core.Common;

namespace University_Management.Core
{
    public class Province : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
