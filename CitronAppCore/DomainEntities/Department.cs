using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class Department : IDomainEntity
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
