using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class ProjectCharterQuestion : IDomainEntity
    {
        public string HeaderCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
