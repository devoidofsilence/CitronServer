using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;

namespace CitronSqlPersistence
{
    public class ProjectAssignedEmployeesPersistenceManager : IProjectAssignedEmployeesPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Project Create(Project project)
        {
            var dh = new TempDataHolder();
            Delete(project);
            var projectSelected = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == project.Code);
            if (project.AssignedEmployees != null)
            {
                foreach (var item in project.AssignedEmployees)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var employeesPersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == item);
                        if (employeesPersistenceEntity != null)
                        {
                            dh.employeeID = employeesPersistenceEntity.ID;
                        }
                    }
                    var projectAssignedEmployeesPersistenceEntity = new ProjectAssignedEmployeesPersistenceEntity();
                    projectAssignedEmployeesPersistenceEntity.EmployeeID = dh.employeeID ?? default(int);
                    projectAssignedEmployeesPersistenceEntity.ProjectID = projectSelected.ID;
                    db.ProjectAssignedEmployeesPersistenceEntities.Add(projectAssignedEmployeesPersistenceEntity);
                }
            }

            db.SaveChanges();
            return project;
        }

        public Project Delete(Project project)
        {
            var projectSelected = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == project.Code);
            var projectAssignedEmployeesPersistenceEntity = db.ProjectAssignedEmployeesPersistenceEntities.Where(e => e.ProjectID == projectSelected.ID);
            foreach (var item in projectAssignedEmployeesPersistenceEntity)
            {
                db.ProjectAssignedEmployeesPersistenceEntities.Remove(item);
            }

            db.SaveChanges();
            return project;
        }

        public Project Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<Project> FindAll(Func<Project, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Project Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
