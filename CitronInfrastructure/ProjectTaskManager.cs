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
        IProjectTaskAssignedEmployeesPersistenceManager _projectTaskAssignedEmployeesPersistenceManager;
        public ProjectTaskManager(IProjectTaskPersistenceManager projectTaskPersistenceManager, IProjectTaskAssignedEmployeesPersistenceManager projectTaskAssignedEmployeesPersistenceManager)
        {
            _projectTaskPersistenceManager = projectTaskPersistenceManager;
            _projectTaskAssignedEmployeesPersistenceManager = projectTaskAssignedEmployeesPersistenceManager;
        }

        public ProjectTask[] AddProjectTask(ProjectTask[] projectTasks)
        {
            foreach (var projectTask in projectTasks)
            {
                var foundProjectTask = _projectTaskPersistenceManager.Find(projectTask.Code);
                if (string.IsNullOrEmpty(foundProjectTask.Code))
                {
                    _projectTaskPersistenceManager.Create(projectTask);
                    _projectTaskAssignedEmployeesPersistenceManager.Create(projectTask);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return projectTasks;
        }

        public ProjectTask DeleteProjectTask(ProjectTask projectTask)
        {
            _projectTaskAssignedEmployeesPersistenceManager.Delete(projectTask);
            _projectTaskPersistenceManager.Delete(projectTask);
            return projectTask;
        }

        public IList<ProjectTask> GetProjectTasks(Func<ProjectTask, bool> condition)
        {
            IList<ProjectTask> projectTasksList = new List<ProjectTask>();
            projectTasksList = _projectTaskPersistenceManager.FindAll(condition);
            return projectTasksList;
        }

        public ProjectTask[] UpdateProjectTask(ProjectTask[] projectTasks)
        {
            foreach (var projectTask in projectTasks)
            {
                var foundProjectTask = _projectTaskPersistenceManager.Find(projectTask.Code);
                if (!string.IsNullOrEmpty(foundProjectTask.Code))
                {
                    _projectTaskPersistenceManager.Update(projectTask);
                    _projectTaskAssignedEmployeesPersistenceManager.Create(projectTask);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return projectTasks;
        }

        public ProjectTask GetProjectTaskDetail(string projectTaskCode)
        {
            ProjectTask projectTask = new ProjectTask();
            if (!string.IsNullOrEmpty(projectTaskCode))
            {
                projectTask = _projectTaskPersistenceManager.Find(projectTaskCode);
            }

            return projectTask;
        }
    }
}
