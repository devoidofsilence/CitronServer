using CitronAppCore.DomainManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;

namespace CitronInfrastructure
{
    public class PersonalityTypeManager : IPersonalityTypeManager
    {
        IPersonalityTypePersistenceManager _personalityTypePersistenceManager;
        public PersonalityTypeManager(IPersonalityTypePersistenceManager personalityTypePersistenceManager)
        {
            _personalityTypePersistenceManager = personalityTypePersistenceManager;
        }
        public PersonalityType CreatePersonalityType(PersonalityType personalityType)
        {
            throw new NotImplementedException();
        }

        public PersonalityType UpdatePersonalityType(PersonalityType personalityType)
        {
            throw new NotImplementedException();
        }

        public PersonalityType DeletePersonalityType(PersonalityType personalityType)
        {
            throw new NotImplementedException();
        }

        public IList<PersonalityType> GetPersonalityTypes(Func<PersonalityType, bool> condition)
        {
            var personalityTypes = _personalityTypePersistenceManager.FindAll(condition);
            return personalityTypes;
        }
    }
}
