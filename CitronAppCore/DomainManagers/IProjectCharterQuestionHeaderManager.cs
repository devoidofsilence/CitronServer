using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IProjectCharterQuestionHeaderManager
    {
        ProjectCharterQuestionHeader CreateProjectCharterQuestionHeader(ProjectCharterQuestionHeader projectCharterQuestionHeader);

        ProjectCharterQuestionHeader UpdateProjectCharterQuestionHeader(ProjectCharterQuestionHeader projectCharterQuestionHeader);

        ProjectCharterQuestionHeader DeleteProjectCharterQuestionHeader(ProjectCharterQuestionHeader projectCharterQuestionHeader);

        IList<ProjectCharterQuestionHeader> GetProjectCharterQuestionHeaders(Func<ProjectCharterQuestionHeader, bool> condition);
    }
}
