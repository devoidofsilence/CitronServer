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
        public int PowerOnProject { get; set; }
        public int InterestOnProject { get; set; }
        public bool AssignAsKey { get; set; }
    }
}
