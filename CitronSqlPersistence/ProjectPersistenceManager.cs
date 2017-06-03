using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronWeb.Utils;
using CitronSqlPersistence.PersistenceEntities;

namespace CitronSqlPersistence
{
    public class ProjectPersistenceManager : IProjectPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Project Create(Project project)
        {
            var dh = new TempDataHolder();
            var projectPersistenceEntity = new ProjectPersistenceEntity()
            {
                Code = project.Code.NullIfEmptyString(),
                Name = project.Name.NullIfEmptyString(),
                Description = project.Description.NullIfEmptyString(),
                Status = project.Status.NullIfEmptyString(),
                PercentageCompleted = project.PercentageCompleted
            };

            db.ProjectPersistenceEntities.Add(projectPersistenceEntity);
            db.SaveChanges();
            return project;
        }
        public Project Update(Project project)
        {
            var dh = new TempDataHolder();
            var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == project.Code);
            projectPersistenceEntity.Code = project.Code.NullIfEmptyString();
            projectPersistenceEntity.Name = project.Name.NullIfEmptyString();
            projectPersistenceEntity.Description = project.Description.NullIfEmptyString();
            projectPersistenceEntity.Status = project.Status.NullIfEmptyString();
            projectPersistenceEntity.PercentageCompleted = project.PercentageCompleted;

            db.SaveChanges();
            return project;
        }

        public Project Delete(Project project)
        {
            var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == project.Code);
            db.ProjectPersistenceEntities.Remove(projectPersistenceEntity);

            db.SaveChanges();
            return project;
        }

        public Project Find(string code)
        {
            var dh = new TempDataHolder();
            var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == code);
            var aggregatedTable = (from projectTable in db.ProjectPersistenceEntities.Where(e => e.Code == code)
                                   join projectAssignedEmployeesTable in db.ProjectAssignedEmployeesPersistenceEntities on projectTable.ID equals projectAssignedEmployeesTable.ProjectID into ppaeJoin
                                   from ppae in ppaeJoin.DefaultIfEmpty()
                                   join employeesTable in db.EmployeePersistenceEntities on ppae.EmployeeID equals employeesTable.ID into ppaeeJoin
                                   from ppaee in ppaeeJoin.DefaultIfEmpty()
                                   select new { Project = projectTable, AssignedEmployees = ppae, EmployeeMap = ppaee });
            var tableList = aggregatedTable.ToList();
            Project project = new Project();
            if (aggregatedTable != null && tableList.Count != 0)
            {
                if (aggregatedTable.FirstOrDefault().Project != null)
                {
                    var aggProjectTable= aggregatedTable.FirstOrDefault().Project;
                    project.Code = aggProjectTable.Code;
                    project.Name = aggProjectTable.Name;
                    project.Description = aggProjectTable.Description;
                    project.Status = aggProjectTable.Status;
                    project.PercentageCompleted = aggProjectTable.PercentageCompleted;
                    var assignedEmployeesCollection = aggregatedTable.AsEnumerable().Select(e => e.AssignedEmployees);
                    var tableEmployeesAssigned = assignedEmployeesCollection.ToList();
                    project.AssignedEmployees = new List<string>();
                    if (aggregatedTable.FirstOrDefault().AssignedEmployees != null)
                    {
                        if (assignedEmployeesCollection != null && tableEmployeesAssigned.Count != 0)
                        {
                            foreach (var item in assignedEmployeesCollection)
                            {
                                project.AssignedEmployees.Add(item.employeePersistenceEntity.Code);
                            }
                        }
                    }
                }
            }
            return project;
        }

        public IList<Project> FindAll(Func<Project, bool> condition)
        {
            var dh = new TempDataHolder();
            IList<Project> projectsList = new List<Project>();

            var projectPersistenceEntities = db.ProjectPersistenceEntities;

            foreach (var projectPersistenceEntity in projectPersistenceEntities)
            {
                projectsList.Add(new Project()
                {
                    Code = projectPersistenceEntity.Code,
                    Name = projectPersistenceEntity.Name,
                    Description = projectPersistenceEntity.Description,
                    Status = projectPersistenceEntity.Status,
                    PercentageCompleted = projectPersistenceEntity.PercentageCompleted
                });
            }
            return projectsList;
        }

        public Project Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
