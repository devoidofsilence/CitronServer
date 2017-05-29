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
    public class ProjectTaskManager : IProjectTaskManager
    {
        IProjectTaskPersistenceManager _projectTaskPersistenceManager;
        public ProjectTaskManager(IProjectTaskPersistenceManager projectTaskPersistenceManager)
        {
            _projectTaskPersistenceManager = projectTaskPersistenceManager;
        }

        public ProjectTask AddProjectTask(ProjectTask projectTask)
        {
            var foundProjectTask = _projectTaskPersistenceManager.Find(projectTask.Code);
            if (string.IsNullOrEmpty(foundProjectTask.Code))
            {
                _projectTaskPersistenceManager.Create(projectTask);
            }
            else
            {
                throw new NotImplementedException();
            }
            return projectTask;
        }

        public ProjectTask DeleteProjectTask(ProjectTask projectTask)
        {
            _projectTaskPersistenceManager.Delete(projectTask);
            return projectTask;
        }

        public IList<ProjectTask> GetProjectTasks(Func<ProjectTask, bool> condition)
        {
            throw new NotImplementedException();
        }

        public ProjectTask UpdateProjectTask(ProjectTask projectTask)
        {
            var foundProjectTask = _projectTaskPersistenceManager.Find(projectTask.Code);
            if (!string.IsNullOrEmpty(foundProjectTask.Code))
            {
                _projectTaskPersistenceManager.Update(projectTask);
            }
            else
            {
                throw new NotImplementedException();
            }
            return projectTask;
        }
    }
}
