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
    public class ProjectCharterManager : IProjectCharterManager
    {
        IProjectCharterPersistenceManager _projectCharterPersistenceManager;
        public ProjectCharterManager(IProjectCharterPersistenceManager projectCharterPersistenceManager)
        {
            _projectCharterPersistenceManager = projectCharterPersistenceManager;
        }
        public ProjectCharter CreateProjectCharter(ProjectCharter projectCharter)
        {
            var foundProjectCharter = _projectCharterPersistenceManager.Find(projectCharter.ProjectCode);
            if (string.IsNullOrEmpty(foundProjectCharter.ProjectCode))
            {
                _projectCharterPersistenceManager.Create(projectCharter);
            }
            else
            {
                throw new NotImplementedException();
            }
            return projectCharter;
        }

        public ProjectCharter DeleteProjectCharter(ProjectCharter projectCharter)
        {
            _projectCharterPersistenceManager.Delete(projectCharter);
            return projectCharter;
        }

        public IList<ProjectCharter> GetProjectCharters(Func<ProjectCharter, bool> condition)
        {
            IList<ProjectCharter> projectChartersList = new List<ProjectCharter>();
            projectChartersList = _projectCharterPersistenceManager.FindAll(condition);
            return projectChartersList;
        }

        public ProjectCharter GetProjectCharterDetail(string code)
        {
            ProjectCharter projectCharter = new ProjectCharter();
            projectCharter = _projectCharterPersistenceManager.Find(code);
            return projectCharter;
        }

        public ProjectCharter UpdateProjectCharter(ProjectCharter projectCharter)
        {
            var foundProjectCharter = _projectCharterPersistenceManager.Find(projectCharter.ProjectCode);
            if (!string.IsNullOrEmpty(foundProjectCharter.ProjectCode))
            {
                _projectCharterPersistenceManager.Update(projectCharter);
            }
            else
            {
                throw new NotImplementedException();
            }
            return projectCharter;
        }
    }
}
