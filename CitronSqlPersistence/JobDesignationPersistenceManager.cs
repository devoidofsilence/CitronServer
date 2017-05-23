using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class JobDesignationPersistenceManager : IJobDesignationPersistenceManager
    {
        public Designation Create(Designation domainEntity)
        {
            throw new NotImplementedException();
        }

        public Designation Update(Designation domainEntity)
        {
            throw new NotImplementedException();
        }

        public Designation Delete(Designation domainEntity)
        {
            throw new NotImplementedException();
        }

        public Designation Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Designation> FindAll(Func<Designation, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Designation Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
