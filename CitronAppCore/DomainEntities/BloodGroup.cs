using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class BloodGroup : IDomainEntity
    {
        public string BloodGroupCode { get; set; }
        public string BloodGroupName { get; set; }
    }
}
