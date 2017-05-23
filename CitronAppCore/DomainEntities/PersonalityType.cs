using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class PersonalityType: IDomainEntity
    {
        public string PersonalityTypeCode { get; set; }
        public string PersonalityTypeName { get; set; }
    }
}
