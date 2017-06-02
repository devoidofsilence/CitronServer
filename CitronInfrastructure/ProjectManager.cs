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
        IProjectAssignedEmployeesPersistenceManager _projectAssignedEmployeesPersistenceManager;
        public ProjectManager(IProjectPersistenceManager projectPersistenceManager, IProjectAssignedEmployeesPersistenceManager projectAssignedEmployeesPersistenceManager)
        {
            _projectPersistenceManager = projectPersistenceManager;
            _projectAssignedEmployeesPersistenceManager = projectAssignedEmployeesPersistenceManager;
        }

        public Project AddProject(Project project)
        {
            var foundProject = _projectPersistenceManager.Find(project.Code);
            if (string.IsNullOrEmpty(foundProject.Code))
            {
                _projectPersistenceManager.Create(project);
                _projectAssignedEmployeesPersistenceManager.Create(project);
            }
            else
            {
                throw new NotImplementedException();
            }
            return project;
        }

        public Project DeleteProject(Project project)
        {
            _projectAssignedEmployeesPersistenceManager.Delete(project);
            _projectPersistenceManager.Delete(project);
            return project;
        }

        public IList<Project> GetProjects(Func<Project, bool> condition)
        {
            IList<Project> projectsList = new List<Project>();
            projectsList = _projectPersistenceManager.FindAll(condition);
            return projectsList;
        }

        public Project UpdateProject(Project project)
        {
            var foundProject = _projectPersistenceManager.Find(project.Code);
            if (!string.IsNullOrEmpty(foundProject.Code))
            {
                _projectPersistenceManager.Update(project);
                _projectAssignedEmployeesPersistenceManager.Create(project);
            }
            else
            {
                throw new NotImplementedException();
            }
            return project;
        }

        public Project GetProjectDetail(string projectCode)
        {
            Project project = new Project();
            if (!string.IsNullOrEmpty(projectCode))
            {
                project = _projectPersistenceManager.Find(projectCode);
            }

            return project;
        }
    }
}
