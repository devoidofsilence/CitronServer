using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class Allowance : IDomainEntity
    {
        public string AllowanceCode { get; set; }
        public string AllowanceName { get; set; }
    }
}
