using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class AssignStakeholder: IDomainEntity
    {
        //public string AssignStakeholderCode { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string StakeholderCode { get; set; }
        public string StakeholderName { get; set; }
        public string PowerOnProject { get; set; }
        public string InterestOnProject { get; set; }
        public string AssignAsKey { get; set; }
    }
}
