using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence
{
    public class ProjectTaskAssignedEmployeesPersistenceManager : IProjectTaskAssignedEmployeesPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public ProjectTask Create(ProjectTask projectTask)
        {
            var dh = new TempDataHolder();
            Delete(projectTask);
            var projectTaskSelected = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.Code);
            if (projectTask.AssignedEmployees != null)
            {
                foreach (var item in projectTask.AssignedEmployees)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var employeesPersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == item);
                        if (employeesPersistenceEntity != null)
                        {
                            dh.employeeID = employeesPersistenceEntity.ID;
                        }
                    }
                    var projectTaskAssignedEmployeesPersistenceEntity = new ProjectTaskAssignedEmployeesPersistenceEntity();
                    projectTaskAssignedEmployeesPersistenceEntity.EmployeeID = dh.employeeID ?? default(int);
                    projectTaskAssignedEmployeesPersistenceEntity.ProjectTskID = projectTaskSelected.ID;
                    db.ProjectTaskAssignedEmployeesPersistenceEntities.Add(projectTaskAssignedEmployeesPersistenceEntity);
                }
            }

            db.SaveChanges();
            //db.Refresh(RefreshMode.ClientWins, db.ProjectTaskAssignedEmployeesPersistenceEntities);
            return projectTask;
        }

        public ProjectTask Delete(ProjectTask projectTask)
        {
            var projectTaskSelected = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.Code);
            var projectTaskAssignedEmployeesPersistenceEntity = db.ProjectTaskAssignedEmployeesPersistenceEntities.Where(e => e.ProjectTskID == projectTaskSelected.ID);
            foreach (var item in projectTaskAssignedEmployeesPersistenceEntity)
            {
                db.ProjectTaskAssignedEmployeesPersistenceEntities.Remove(item);
            }

            db.SaveChanges();
            return projectTask;
        }

        public ProjectTask Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<ProjectTask> FindAll(Func<ProjectTask, bool> condition)
        {
            throw new NotImplementedException();
        }

        public ProjectTask Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public ProjectTask Update(ProjectTask domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
