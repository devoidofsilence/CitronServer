using CitronAppCore.DomainManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;

namespace CitronInfrastructure
{
    public class BloodGroupManager : IBloodGroupManager
    {
        IBloodGroupPersistenceManager _bloodGroupPersistenceManager;
        public BloodGroupManager(IBloodGroupPersistenceManager bloodGroupPersistenceManager)
        {
            _bloodGroupPersistenceManager = bloodGroupPersistenceManager;
        }
        public BloodGroup CreateBloodGroup(BloodGroup BloodGroup)
        {
            throw new NotImplementedException();
        }

        public BloodGroup DeleteBloodGroup(BloodGroup BloodGroup)
        {
            throw new NotImplementedException();
        }

        public IList<BloodGroup> GetBloodGroups(Func<BloodGroup, bool> condition)
        {
            var bloodGroups = _bloodGroupPersistenceManager.FindAll(condition);
            return bloodGroups;
        }

        public BloodGroup UpdateBloodGroup(BloodGroup BloodGroup)
        {
            throw new NotImplementedException();
        }
    }
}
