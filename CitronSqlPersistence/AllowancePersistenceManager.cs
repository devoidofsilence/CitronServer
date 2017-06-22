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
        SqlDbContext db = new SqlDbContext();
        public Allowance Create(Allowance domainEntity)
        {
            throw new NotImplementedException();
        }

        public Allowance Delete(Allowance domainEntity)
        {
            throw new NotImplementedException();
        }

        public Allowance Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<Allowance> FindAll(Func<Allowance, bool> condition)
        {
            IList<Allowance> allowances = new List<Allowance>();
            var allowanceEntities = db.AllowancePersistenceEntities;//.Where(condition);
            foreach (var allowance in allowanceEntities)
            {
                allowances.Add(new Allowance()
                {
                    AllowanceCode = allowance.Code,
                    AllowanceName = allowance.Description
                });
            }
            return allowances;
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
