using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;
using CitronWeb.Utils;

namespace CitronSqlPersistence
{
    public class StakeholderPersistenceManager : IStakeholderPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();

        public Stakeholder Create(Stakeholder stakeholder)
        {
            var dh = new TempDataHolder();
            var stakeholderPersistenceEntity = new StakeholderPersistenceEntity()
            {
                Code = stakeholder.Code.NullIfEmptyString(),
                Name = stakeholder.Name.NullIfEmptyString(),
                Address = stakeholder.Address.NullIfEmptyString(),
                Email = stakeholder.Email.NullIfEmptyString(),
                Phone = stakeholder.Phone.NullIfEmptyString(),
                OrganizationName = stakeholder.OrganizationName.NullIfEmptyString(),
                JobPosition = stakeholder.JobPosition.NullIfEmptyString()
            };

            db.StakeholderPersistenceEntities.Add(stakeholderPersistenceEntity);
            db.SaveChanges();
            return stakeholder;
        }

        public Stakeholder Delete(Stakeholder stakeholder)
        {
            var stakeholderPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == stakeholder.Code);
            db.StakeholderPersistenceEntities.Remove(stakeholderPersistenceEntity);

            db.SaveChanges();
            return stakeholder;
        }

        public Stakeholder Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Stakeholder> FindAll(Func<Stakeholder, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Stakeholder Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public Stakeholder Update(Stakeholder stakeholder)
        {
            var dh = new TempDataHolder();
            var stakeholderPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == stakeholder.Code);
            stakeholderPersistenceEntity.Code = stakeholder.Code.NullIfEmptyString();
            stakeholderPersistenceEntity.Name = stakeholder.Name.NullIfEmptyString();
            stakeholderPersistenceEntity.Address = stakeholder.Address.NullIfEmptyString();
            stakeholderPersistenceEntity.Email = stakeholder.Email.NullIfEmptyString();
            stakeholderPersistenceEntity.Phone = stakeholder.Phone.NullIfEmptyString();
            stakeholderPersistenceEntity.OrganizationName = stakeholder.OrganizationName.NullIfEmptyString();
            stakeholderPersistenceEntity.JobPosition = stakeholder.JobPosition.NullIfEmptyString();

            db.SaveChanges();
            return stakeholder;
        }
    }
}
