using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class MaritalStatus : IDomainEntity
    {
        public string MaritalStatusCode { get; set; }
        public string MaritalStatusName { get; set; }
    }
}
