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
    public class StakeholderManager : IStakeholderManager
    {
        IStakeholderPersistenceManager _stakeholderPersistenceManager;
        public StakeholderManager(IStakeholderPersistenceManager stakeholderPersistenceManager)
        {
            _stakeholderPersistenceManager = stakeholderPersistenceManager;
        }
        public Stakeholder CreateStakeholder(Stakeholder stakeholder)
        {
            var foundStakeholder = _stakeholderPersistenceManager.Find(stakeholder.Code);
            if (string.IsNullOrEmpty(foundStakeholder.Code))
            {
                _stakeholderPersistenceManager.Create(stakeholder);
            }
            else
            {
                throw new NotImplementedException();
            }
            return stakeholder;
        }

        public Stakeholder DeleteStakeholder(Stakeholder stakeholder)
        {
            _stakeholderPersistenceManager.Delete(stakeholder);
            return stakeholder;
        }

        public IList<Stakeholder> GetStakeholders(Func<Stakeholder, bool> condition)
        {
            IList<Stakeholder> stakeholdersList = new List<Stakeholder>();
            stakeholdersList = _stakeholderPersistenceManager.FindAll(condition);
            return stakeholdersList;
        }

        public Stakeholder UpdateStakeholder(Stakeholder stakeholder)
        {
            var foundStakeholder = _stakeholderPersistenceManager.Find(stakeholder.Code);
            if (!string.IsNullOrEmpty(foundStakeholder.Code))
            {
                _stakeholderPersistenceManager.Create(stakeholder);
            }
            else
            {
                throw new NotImplementedException();
            }
            return stakeholder;
        }
    }
}
