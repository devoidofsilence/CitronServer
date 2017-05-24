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
    public class MaritalStatusManager : IMaritalStatusManager
    {
        IMaritalStatusPersistenceManager _maritalStatusPersistenceManager;
        public MaritalStatusManager(IMaritalStatusPersistenceManager maritalStatusPersistenceManager)
        {
            _maritalStatusPersistenceManager = maritalStatusPersistenceManager;
        }
        public MaritalStatus CreateMaritalStatus(MaritalStatus maritalStatus)
        {
            throw new NotImplementedException();
        }

        public MaritalStatus DeleteMaritalStatus(MaritalStatus maritalStatus)
        {
            throw new NotImplementedException();
        }

        public IList<MaritalStatus> GetMaritalStatuses(Func<MaritalStatus, bool> condition)
        {
            var maritalStatuses = _maritalStatusPersistenceManager.FindAll(condition);
            return maritalStatuses;
        }

        public MaritalStatus UpdateMaritalStatus(MaritalStatus maritalStatus)
        {
            throw new NotImplementedException();
        }
    }
}
