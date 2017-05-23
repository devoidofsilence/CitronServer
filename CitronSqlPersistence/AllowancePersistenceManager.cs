using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class AllowancePersistenceManager : IAllowancePersistenceManager
    {
        public Allowance Create(Allowance domainEntity)
        {
            throw new NotImplementedException();
        }

        public Allowance Delete(Allowance domainEntity)
        {
            throw new NotImplementedException();
        }

        public Allowance Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Allowance> FindAll(Func<Allowance, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Allowance Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public Allowance Update(Allowance domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
