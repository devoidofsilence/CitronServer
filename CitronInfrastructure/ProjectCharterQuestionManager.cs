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
    public class ProjectCharterQuestionManager : IProjectCharterQuestionManager
    {
        IProjectCharterQuestionPersistenceManager _projectCharterQuestionPersistenceManager;
        public ProjectCharterQuestionManager(IProjectCharterQuestionPersistenceManager projectCharterQuestionPersistenceManager)
        {
            _projectCharterQuestionPersistenceManager = projectCharterQuestionPersistenceManager;
        }
        public ProjectCharterQuestion CreateProjectCharterQuestion(ProjectCharterQuestion projectCharterQuestion)
        {
            throw new NotImplementedException();
        }

        public ProjectCharterQuestion DeleteProjectCharterQuestion(ProjectCharterQuestion projectCharterQuestion)
        {
            throw new NotImplementedException();
        }

        public IList<ProjectCharterQuestion> GetProjectCharterQuestions(Func<ProjectCharterQuestion, bool> condition)
        {
            var projectCharterQuestions = _projectCharterQuestionPersistenceManager.FindAll(condition);
            return projectCharterQuestions;
        }

        public ProjectCharterQuestion UpdateProjectCharterQuestion(ProjectCharterQuestion projectCharterQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
