using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class PersonalityTypePersistenceManager : IPersonalityTypePersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public PersonalityType Create(PersonalityType domainEntity)
        {
            throw new NotImplementedException();
        }

        public PersonalityType Delete(PersonalityType domainEntity)
        {
            throw new NotImplementedException();
        }

        public PersonalityType Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<PersonalityType> FindAll(Func<PersonalityType, bool> condition)
        {
            IList<PersonalityType> personalityTypes = new List<PersonalityType>();
            var personalityTypeEntities = db.PersonalityTypePersistenceEntities;//.Where(condition);
            foreach (var personalityType in personalityTypeEntities)
            {
                personalityTypes.Add(new PersonalityType() {
                    PersonalityTypeCode = personalityType.Code,
                    PersonalityTypeName = personalityType.Description
                });
            }
            return personalityTypes;
        }

        public PersonalityType Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public PersonalityType Update(PersonalityType domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
