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
    public class AssignStakeholderManager : IAssignStakeholderManager
    {
        IAssignStakeholderPersistenceManager _assignStakeholderPersistenceManager;
        public AssignStakeholderManager(IAssignStakeholderPersistenceManager assignStakeholderPersistenceManager)
        {
            _assignStakeholderPersistenceManager = assignStakeholderPersistenceManager;
        }
        public AssignStakeholder[] AssignStakeholder(AssignStakeholder[] stakeholders)
        {
            foreach (var stakeholder in stakeholders)
            {
                List<string> lstIDS = new List<string>();
                string[] ids = { stakeholder.ProjectCode, stakeholder.StakeholderCode };
                lstIDS.AddRange(ids);
                var foundStakeholder = _assignStakeholderPersistenceManager.Find(lstIDS);
                if (string.IsNullOrEmpty(foundStakeholder.ProjectCode))
                {
                    _assignStakeholderPersistenceManager.Create(stakeholder);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return stakeholders;
        }

        public AssignStakeholder DeleteAssignedStakeholder(AssignStakeholder stakeholder)
        {
            _assignStakeholderPersistenceManager.Delete(stakeholder);
            return stakeholder;
        }

        public IList<AssignStakeholder> GetAssignedStakeholders(Func<AssignStakeholder, bool> condition)
        {
            IList<AssignStakeholder> stakeholdersList = new List<AssignStakeholder>();
            stakeholdersList = _assignStakeholderPersistenceManager.FindAll(condition);
            return stakeholdersList;
        }

        public AssignStakeholder[] UpdateAssignedStakeholder(AssignStakeholder[] stakeholders)
        {
            foreach (var stakeholder in stakeholders)
            {
                List<string> lstIDS = new List<string>();
                string[] ids = { stakeholder.ProjectCode, stakeholder.StakeholderCode };
                lstIDS.AddRange(ids);
                var foundStakeholder = _assignStakeholderPersistenceManager.Find(lstIDS);
                if (!string.IsNullOrEmpty(foundStakeholder.ProjectCode))
                {
                    _assignStakeholderPersistenceManager.Create(stakeholder);
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
