using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class MaritalStatusPersistenceManager : IMaritalStatusPersistenceManager
    {
        public MaritalStatus Create(MaritalStatus domainEntity)
        {
            throw new NotImplementedException();
        }

        public MaritalStatus Delete(MaritalStatus domainEntity)
        {
            throw new NotImplementedException();
        }

        public MaritalStatus Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<MaritalStatus> FindAll(Func<MaritalStatus, bool> condition)
        {
            throw new NotImplementedException();
        }

        public MaritalStatus Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public MaritalStatus Update(MaritalStatus domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
