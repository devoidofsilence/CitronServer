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
        public List<Stakeholder> CreateStakeholder(List<Stakeholder> stakeholders)
        {
            foreach (var stakeholder in stakeholders)
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
            }
            return stakeholders;
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

        public List<Stakeholder> UpdateStakeholder(List<Stakeholder> stakeholders)
        {
            foreach (var stakeholder in stakeholders)
            {
                var foundStakeholder = _stakeholderPersistenceManager.Find(stakeholder.Code);
                if (!string.IsNullOrEmpty(foundStakeholder.Code))
                {
                    _stakeholderPersistenceManager.Update(stakeholder);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return stakeholders;
        }
    }
}
