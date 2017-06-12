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
    public class ProjectCharterQuestionHeaderManager : IProjectCharterQuestionHeaderManager
    {
        IProjectCharterQuestionHeaderPersistenceManager _projectCharterQuestionHeaderPersistenceManager;
        public ProjectCharterQuestionHeaderManager(IProjectCharterQuestionHeaderPersistenceManager projectCharterQuestionHeaderPersistenceManager)
        {
            _projectCharterQuestionHeaderPersistenceManager = projectCharterQuestionHeaderPersistenceManager;
        }
        public ProjectCharterQuestionHeader CreateProjectCharterQuestionHeader(ProjectCharterQuestionHeader projectCharterQuestionHeader)
        {
            throw new NotImplementedException();
        }

        public ProjectCharterQuestionHeader DeleteProjectCharterQuestionHeader(ProjectCharterQuestionHeader projectCharterQuestionHeader)
        {
            throw new NotImplementedException();
        }

        public IList<ProjectCharterQuestionHeader> GetProjectCharterQuestionHeaders(Func<ProjectCharterQuestionHeader, bool> condition)
        {
            var projectCharterQuestionHeaders = _projectCharterQuestionHeaderPersistenceManager.FindAll(condition);
            return projectCharterQuestionHeaders;
        }

        public ProjectCharterQuestionHeader UpdateProjectCharterQuestionHeader(ProjectCharterQuestionHeader projectCharterQuestionHeader)
        {
            throw new NotImplementedException();
        }
    }
}
