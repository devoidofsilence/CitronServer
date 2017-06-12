using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IProjectCharterManager
    {
        ProjectCharter CreateProjectCharter(ProjectCharter projectCharter);

        ProjectCharter UpdateProjectCharter(ProjectCharter projectCharter);

        ProjectCharter DeleteProjectCharter(ProjectCharter projectCharter);

        IList<ProjectCharter> GetProjectCharters(Func<ProjectCharter, bool> condition);
        ProjectCharter GetProjectCharterDetail(string code);
    }
}
