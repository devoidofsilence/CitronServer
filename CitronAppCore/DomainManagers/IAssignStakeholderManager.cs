using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IAssignStakeholderManager
    {
        AssignStakeholder[] AssignStakeholder(AssignStakeholder[] stakeholder);

        AssignStakeholder[] UpdateAssignedStakeholder(AssignStakeholder[] stakeholder);

        AssignStakeholder DeleteAssignedStakeholder(AssignStakeholder stakeholder);

        IList<AssignStakeholder> GetAssignedStakeholders(Func<AssignStakeholder, bool> condition);
    }
}
