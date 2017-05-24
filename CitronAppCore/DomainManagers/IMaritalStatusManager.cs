using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IMaritalStatusManager
    {
        MaritalStatus CreateMaritalStatus(MaritalStatus maritalStatus);

        MaritalStatus UpdateMaritalStatus(MaritalStatus maritalStatus);

        MaritalStatus DeleteMaritalStatus(MaritalStatus maritalStatus);

        IList<MaritalStatus> GetMaritalStatuses(Func<MaritalStatus, bool> condition);
    }
}
