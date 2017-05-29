using CitronAppCore.DomainManagers;
using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronInfrastructure
{
    public class ProjectManager : IProjectManager
    {
        IProjectPersistenceManager _projectPersistenceManager;
        public ProjectManager(IProjectPersistenceManager projectPersistenceManager)
        {
            _projectPersistenceManager = projectPersistenceManager;
        }

        public Project AddProject(Project project)
        {
            var foundProject = _projectPersistenceManager.Find(project.Code);
            if (string.IsNullOrEmpty(foundProject.Code))
            {
                _projectPersistenceManager.Create(project);
            }
            else
            {
                throw new NotImplementedException();
            }
            return project;
        }

        public Project DeleteProject(Project project)
        {
            _projectPersistenceManager.Delete(project);
            return project;
        }

        public IList<Project> GetProjects(Func<Project, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Project UpdateProject(Project project)
        {
            var foundProject = _projectPersistenceManager.Find(project.Code);
            if (!string.IsNullOrEmpty(foundProject.Code))
            {
                _projectPersistenceManager.Update(project);
            }
            else
            {
                throw new NotImplementedException();
            }
            return project;
        }
    }
}
