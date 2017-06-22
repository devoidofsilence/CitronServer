using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class ProjectCharterQuestionPersistenceManager : IProjectCharterQuestionPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public ProjectCharterQuestion Create(ProjectCharterQuestion domainEntity)
        {
            throw new NotImplementedException();
        }

        public ProjectCharterQuestion Delete(ProjectCharterQuestion domainEntity)
        {
            throw new NotImplementedException();
        }

        public ProjectCharterQuestion Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<ProjectCharterQuestion> FindAll(Func<ProjectCharterQuestion, bool> condition)
        {
            var dh = new TempDataHolder();
            IList<ProjectCharterQuestion> projectCharterQuestion = new List<ProjectCharterQuestion>();
            var aggregatedTable = (from projectCharterQuestionTable in db.ProjectCharterQuestionPersistenceEntities
                                   join projectCharterQuestionHeaderTable in db.ProjectCharterQuestionHeaderPersistenceEntities on projectCharterQuestionTable.HeaderID equals projectCharterQuestionHeaderTable.ID into ppaeeJoin
                                   from ppaee in ppaeeJoin.DefaultIfEmpty()
                                   select new { ProjectCharterQuestions = projectCharterQuestionTable, Header = ppaee });
            var tableList = aggregatedTable.ToList();
            if (aggregatedTable != null && tableList.Count != 0)
            {
                if (aggregatedTable.FirstOrDefault().ProjectCharterQuestions != null)
                {
                    var aggProjectCharterTable = aggregatedTable.AsEnumerable().Select(e => e.ProjectCharterQuestions);
                    foreach (var item in aggProjectCharterTable)
                    {
                        projectCharterQuestion.Add(new ProjectCharterQuestion {
                            HeaderCode = item.projectCharterQuestionHeaderEntity.Code,
                            Code = item.Code,
                            Name = item.Name,
                            Note = item.Note
                        });
                    }
                }
            }
            return projectCharterQuestion;
        }

        public ProjectCharterQuestion Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public ProjectCharterQuestion Update(ProjectCharterQuestion domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
