using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IProjectCharterQuestionManager
    {
        ProjectCharterQuestion CreateProjectCharterQuestion(ProjectCharterQuestion projectCharterQuestion);

        ProjectCharterQuestion UpdateProjectCharterQuestion(ProjectCharterQuestion projectCharterQuestion);

        ProjectCharterQuestion DeleteProjectCharterQuestion(ProjectCharterQuestion projectCharterQuestion);

        IList<ProjectCharterQuestion> GetProjectCharterQuestions(Func<ProjectCharterQuestion, bool> condition);
    }
}
