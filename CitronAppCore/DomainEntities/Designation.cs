﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class Designation : IDomainEntity
    {
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
    }
}
