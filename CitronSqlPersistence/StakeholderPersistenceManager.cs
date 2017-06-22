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
                OrganizationName = stakeholder.Organization.NullIfEmptyString(),
                JobPosition = stakeholder.JobPosition.NullIfEmptyString(),
                Mobile = stakeholder.Mobile.NullIfEmptyString(),
                Fax = stakeholder.Fax.NullIfEmptyString()
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

        public Stakeholder Find(object id)
        {
            var stakeholdersPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == (string)id);
            Stakeholder stakeholder = new Stakeholder();
            if (stakeholdersPersistenceEntity != null)
            {
                stakeholder.Code = stakeholdersPersistenceEntity.Code;
                stakeholder.Name = stakeholdersPersistenceEntity.Name;
                stakeholder.Address = stakeholdersPersistenceEntity.Address;
                stakeholder.Email = stakeholdersPersistenceEntity.Email;
                stakeholder.Fax = stakeholdersPersistenceEntity.Fax;
                stakeholder.JobPosition = stakeholdersPersistenceEntity.JobPosition;
                stakeholder.Organization = stakeholdersPersistenceEntity.OrganizationName;
                stakeholder.Phone = stakeholdersPersistenceEntity.Phone;
            }
            return stakeholder;
        }

        public IList<Stakeholder> FindAll(Func<Stakeholder, bool> condition)
        {
            IList<Stakeholder> stakeholders = new List<Stakeholder>();
            var stakeholderPersistenceEntities = db.StakeholderPersistenceEntities;
            if (stakeholderPersistenceEntities != null)
            {
                foreach (var item in stakeholderPersistenceEntities)
                {
                    stakeholders.Add(new Stakeholder
                    {
                        Code = item.Code,
                        Name = item.Name,
                        Organization = item.OrganizationName,
                        JobPosition = item.JobPosition,
                        Address = item.Address,
                        Mobile = item.Mobile,
                        Email = item.Email,
                        Fax = item.Fax,
                        Phone = item.Phone
                    });
                }
            }
            return stakeholders;
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
            stakeholderPersistenceEntity.OrganizationName = stakeholder.Organization.NullIfEmptyString();
            stakeholderPersistenceEntity.Mobile = stakeholder.Mobile.NullIfEmptyString();
            stakeholderPersistenceEntity.Fax = stakeholder.Fax.NullIfEmptyString();
            stakeholderPersistenceEntity.JobPosition = stakeholder.JobPosition.NullIfEmptyString();

            db.SaveChanges();
            return stakeholder;
        }
    }
}
