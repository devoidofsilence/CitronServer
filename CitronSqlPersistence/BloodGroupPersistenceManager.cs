using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class BloodGroupPersistenceManager : IBloodGroupPersistenceManager
    {
        public BloodGroup Create(BloodGroup domainEntity)
        {
            throw new NotImplementedException();
        }

        public BloodGroup Delete(BloodGroup domainEntity)
        {
            throw new NotImplementedException();
        }

        public BloodGroup Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<BloodGroup> FindAll(Func<BloodGroup, bool> condition)
        {
            throw new NotImplementedException();
        }

        public BloodGroup Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public BloodGroup Update(BloodGroup domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
