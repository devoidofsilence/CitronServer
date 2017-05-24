using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IBloodGroupManager
    {
        BloodGroup CreateBloodGroup(BloodGroup BloodGroup);

        BloodGroup UpdateBloodGroup(BloodGroup BloodGroup);

        BloodGroup DeleteBloodGroup(BloodGroup BloodGroup);

        IList<BloodGroup> GetBloodGroups(Func<BloodGroup, bool> condition);
    }
}
