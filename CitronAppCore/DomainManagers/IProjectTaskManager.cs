using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IProjectTaskManager
    {
        ProjectTask AddProjectTask(ProjectTask project);
        ProjectTask UpdateProjectTask(ProjectTask project);
        ProjectTask DeleteProjectTask(ProjectTask project);
        ProjectTask GetProjectTaskDetail(string code);
        IList<ProjectTask> GetProjectTasks(Func<ProjectTask, bool> condition);
    }
}
