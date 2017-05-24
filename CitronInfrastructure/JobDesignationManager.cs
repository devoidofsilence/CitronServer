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
    public class JobDesignationManager : IJobDesignationManager
    {
        IJobDesignationPersistenceManager _jobDesignationPersistenceManager;
        public JobDesignationManager(IJobDesignationPersistenceManager jobDesignationPersistenceManager)
        {
            _jobDesignationPersistenceManager = jobDesignationPersistenceManager;
        }
        public Designation CreateDesignation(Designation designation)
        {
            throw new NotImplementedException();
        }

        public Designation DeleteDesignation(Designation designation)
        {
            throw new NotImplementedException();
        }

        public IList<Designation> GetDesignations(Func<Designation, bool> condition)
        {
            var jobDesignations = _jobDesignationPersistenceManager.FindAll(condition);
            return jobDesignations;
        }

        public Designation UpdateDesignation(Designation designation)
        {
            throw new NotImplementedException();
        }
    }
}
