using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IStakeholderManager
    {
        Stakeholder CreateStakeholder(Stakeholder stakeholder);

        Stakeholder UpdateStakeholder(Stakeholder stakeholder);

        Stakeholder DeleteStakeholder(Stakeholder stakeholder);

        IList<Stakeholder> GetStakeholders(Func<Stakeholder, bool> condition);
    }
}
