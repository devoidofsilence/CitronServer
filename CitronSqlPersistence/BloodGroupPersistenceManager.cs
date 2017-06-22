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
        SqlDbContext db = new SqlDbContext();
        public BloodGroup Create(BloodGroup domainEntity)
        {
            throw new NotImplementedException();
        }

        public BloodGroup Delete(BloodGroup domainEntity)
        {
            throw new NotImplementedException();
        }

        public BloodGroup Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<BloodGroup> FindAll(Func<BloodGroup, bool> condition)
        {
            IList<BloodGroup> bloodGroups = new List<BloodGroup>();
            var bloodGroupEntities = db.BloodGroupPersistenceEntities;//.Where(condition);
            foreach (var bloodGroup in bloodGroupEntities)
            {
                bloodGroups.Add(new BloodGroup()
                {
                    BloodGroupCode = bloodGroup.Code,
                    BloodGroupName = bloodGroup.Description
                });
            }
            return bloodGroups;
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
