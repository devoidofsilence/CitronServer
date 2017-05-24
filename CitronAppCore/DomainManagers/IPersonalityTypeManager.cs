using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IPersonalityTypeManager
    {
        PersonalityType CreatePersonalityType(PersonalityType personalityType);

        PersonalityType UpdatePersonalityType(PersonalityType personalityType);

        PersonalityType DeletePersonalityType(PersonalityType personalityType);

        IList<PersonalityType> GetPersonalityTypes(Func<PersonalityType, bool> condition);
    }
}
