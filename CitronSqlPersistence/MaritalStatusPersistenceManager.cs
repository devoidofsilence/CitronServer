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
        SqlDbContext db = new SqlDbContext();
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
            IList<MaritalStatus> maritalStatuses = new List<MaritalStatus>();
            var maritalStatusEntities = db.MaritalStatusPersistenceEntities;//.Where(condition);
            foreach (var maritalStatus in maritalStatusEntities)
            {
                maritalStatuses.Add(new MaritalStatus()
                {
                    MaritalStatusCode = maritalStatus.Code,
                    MaritalStatusName = maritalStatus.Description
                });
            }
            return maritalStatuses;
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
