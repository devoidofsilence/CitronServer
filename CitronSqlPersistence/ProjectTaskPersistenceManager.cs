using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence.PersistenceEntities;
using CitronWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence
{
    public class ProjectTaskPersistenceManager : IProjectTaskPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public ProjectTask Create(ProjectTask projectTask)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(projectTask.ProjectCode))
            {
                var parentPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ProjectCode);
                if (parentPersistenceEntity != null)
                {
                    dh.projectID = parentPersistenceEntity.ID;
                }
            }
            if (!string.IsNullOrEmpty(projectTask.ParentTaskCode))
            {
                var parentTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ParentTaskCode);
                if (parentTaskPersistenceEntity != null)
                {
                    dh.parentTaskID = parentTaskPersistenceEntity.ID;
                }
            }
            if (!string.IsNullOrEmpty(projectTask.ResponsibleEmployeeCode))
            {
                var responsibleEmployeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ResponsibleEmployeeCode);
                if (responsibleEmployeePersistenceEntity != null)
                {
                    dh.responsibleEmployeeID = responsibleEmployeePersistenceEntity.ID;
                }
            }

            var projectTaskPersistenceEntity = new ProjectTaskPersistenceEntity()
            {
                Code = projectTask.Code.NullIfEmptyString(),
                Name = projectTask.Name.NullIfEmptyString(),
                Description = projectTask.Description.NullIfEmptyString(),
                ProjectID = dh.projectID,
                ParentProjectTaskID = dh.parentTaskID,
                ResponsibleEmployeeID = dh.responsibleEmployeeID,
                OptimisticTime = projectTask.OptimisticTime,
                PessimisticTime = projectTask.PessimisticTime,
                ExpectedTime = projectTask.ExpectedTime,
                NormalTime = projectTask.NormalTime
            };

            db.ProjectTaskPersistenceEntities.Add(projectTaskPersistenceEntity);
            db.SaveChanges();
            return projectTask;
        }
        public ProjectTask Update(ProjectTask projectTask)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(projectTask.ProjectCode))
            {
                var parentPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ProjectCode);
                if (parentPersistenceEntity != null)
                {
                    dh.projectID = parentPersistenceEntity.ID;
                }
            }
            if (!string.IsNullOrEmpty(projectTask.ParentTaskCode))
            {
                var parentTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ParentTaskCode);
                if (parentTaskPersistenceEntity != null)
                {
                    dh.parentTaskID = parentTaskPersistenceEntity.ID;
                }
            }
            if (!string.IsNullOrEmpty(projectTask.ResponsibleEmployeeCode))
            {
                var responsibleEmployeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ResponsibleEmployeeCode);
                if (responsibleEmployeePersistenceEntity != null)
                {
                    dh.responsibleEmployeeID = responsibleEmployeePersistenceEntity.ID;
                }
            }
            var projectTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.Code);
            projectTaskPersistenceEntity.Code = projectTask.Code.NullIfEmptyString();
            projectTaskPersistenceEntity.Name = projectTask.Name.NullIfEmptyString();
            projectTaskPersistenceEntity.Description = projectTask.Description.NullIfEmptyString();
            projectTaskPersistenceEntity.ProjectID = dh.projectID;
            projectTaskPersistenceEntity.ParentProjectTaskID = dh.parentTaskID;
            projectTaskPersistenceEntity.ResponsibleEmployeeID = dh.responsibleEmployeeID;
            projectTaskPersistenceEntity.OptimisticTime = projectTask.OptimisticTime;
            projectTaskPersistenceEntity.PessimisticTime = projectTask.PessimisticTime;
            projectTaskPersistenceEntity.ExpectedTime = projectTask.ExpectedTime;
            projectTaskPersistenceEntity.NormalTime = projectTask.NormalTime;

            db.SaveChanges();
            return projectTask;
        }

        public ProjectTask Delete(ProjectTask projectTask)
        {
            var projectTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.Code);
            db.ProjectTaskPersistenceEntities.Remove(projectTaskPersistenceEntity);

            db.SaveChanges();
            return projectTask;
        }

        public ProjectTask Find(object code)
        {
            var dh = new TempDataHolder();
            //var projectTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == code);
            var aggregatedTable = (from projectTaskTable in db.ProjectTaskPersistenceEntities.Where(e => e.Code == (string)code)
                                   join projectTaskAssignedEmployeesTable in db.ProjectTaskAssignedEmployeesPersistenceEntities on projectTaskTable.ID equals projectTaskAssignedEmployeesTable.ProjectTaskID into ppaeJoin
                                   from ppae in ppaeJoin.DefaultIfEmpty()
                                   join employeesTable in db.EmployeePersistenceEntities on ppae.EmployeeID equals employeesTable.ID into ppaeeJoin
                                   from ppaee in ppaeeJoin.DefaultIfEmpty()
                                   select new { Project = projectTaskTable, AssignedEmployees = ppae });
            var tableList = aggregatedTable.ToList();
            ProjectTask projectTask = new ProjectTask();
            if (aggregatedTable != null && tableList.Count != 0)
            {
                if (aggregatedTable.FirstOrDefault().Project != null)
                {
                    var aggProjectTable = aggregatedTable.FirstOrDefault().Project;
                    if (aggProjectTable.ParentProjectTaskID != null)
                    {
                        var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.ID == aggProjectTable.ProjectID);
                        if (projectPersistenceEntity != null)
                        {
                            dh.projectCode = projectPersistenceEntity.Code;
                            projectTask.ProjectName = projectPersistenceEntity.Name;
                        }
                    }
                    if (aggProjectTable.ParentProjectTaskID != null)
                    {
                        var parentTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.ID == aggProjectTable.ParentProjectTaskID);
                        if (parentTaskPersistenceEntity != null)
                        {
                            dh.parentTaskCode = parentTaskPersistenceEntity.Code;
                            projectTask.ParentTaskName = parentTaskPersistenceEntity.Name;
                        }
                    }
                    if (aggProjectTable.ParentProjectTaskID != null)
                    {
                        var responsibleEmployeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.ID == aggProjectTable.ResponsibleEmployeeID);
                        if (responsibleEmployeePersistenceEntity != null)
                        {
                            dh.responsibleEmployeeCode = responsibleEmployeePersistenceEntity.Code;
                            projectTask.ResponsibleEmployeeName = responsibleEmployeePersistenceEntity.Name;
                        }
                    }
                    projectTask.Code = aggProjectTable.Code;
                    projectTask.Name = aggProjectTable.Name;
                    projectTask.Description = aggProjectTable.Description;
                    projectTask.ProjectCode = dh.projectCode;
                    projectTask.ParentTaskCode = dh.parentTaskCode;
                    projectTask.ResponsibleEmployeeCode = dh.responsibleEmployeeCode;
                    projectTask.ExpectedTime = aggProjectTable.ExpectedTime;
                    projectTask.OptimisticTime = aggProjectTable.OptimisticTime;
                    projectTask.NormalTime = aggProjectTable.NormalTime;
                    projectTask.PessimisticTime = aggProjectTable.PessimisticTime;
                    var assignedEmployeesCollection = aggregatedTable.AsEnumerable().Select(e => e.AssignedEmployees);
                    var tableEmployeesAssigned = assignedEmployeesCollection.ToList();
                    projectTask.AssignedEmployees = new List<string>();
                    if (aggregatedTable.FirstOrDefault().AssignedEmployees != null)
                    {
                        if (assignedEmployeesCollection != null && tableEmployeesAssigned.Count != 0)
                        {
                            foreach (var item in assignedEmployeesCollection)
                            {
                                projectTask.AssignedEmployees.Add(item.employeePersistenceEntity.Code);
                            }
                        }
                    }
                }
            }
            return projectTask;
        }

        public IList<ProjectTask> FindAll(Func<ProjectTask, bool> condition)
        {
            var dh = new TempDataHolder();
            IList<ProjectTask> projectTasksList = new List<ProjectTask>();

            var aggregatedTable = (from mainProjectTaskTable in db.ProjectTaskPersistenceEntities
                                   join parentProjectTaskTable in db.ProjectTaskPersistenceEntities on mainProjectTaskTable.ParentProjectTaskID equals parentProjectTaskTable.ID into ptJoin
                                   from pt in ptJoin.DefaultIfEmpty()
                                   join projectTable in db.ProjectPersistenceEntities on mainProjectTaskTable.ProjectID equals projectTable.ID into repJoin
                                   from rep in repJoin.DefaultIfEmpty()
                                   join responsibleEmployeeTable in db.EmployeePersistenceEntities on mainProjectTaskTable.ResponsibleEmployeeID equals responsibleEmployeeTable.ID into reJoin
                                   from re in reJoin.DefaultIfEmpty()
                                   select new { MainProjectTask = mainProjectTaskTable, ParentTask = pt, ResponsibleEmployee = re, ProjectTable = rep });

            var tt = aggregatedTable.ToList();

            foreach (var projectTaskPersistenceEntity in aggregatedTable)
            {
                projectTasksList.Add(new ProjectTask()
                {
                    Code = projectTaskPersistenceEntity.MainProjectTask.Code,
                    Name = projectTaskPersistenceEntity.MainProjectTask.Name,
                    Description = projectTaskPersistenceEntity.MainProjectTask.Description,
                    ProjectCode = projectTaskPersistenceEntity.ProjectTable == null ? null : projectTaskPersistenceEntity.ProjectTable.Code,
                    ProjectName = projectTaskPersistenceEntity.ProjectTable == null ? null : projectTaskPersistenceEntity.ProjectTable.Name,
                    ParentTaskCode = projectTaskPersistenceEntity.ParentTask == null ? null : projectTaskPersistenceEntity.ParentTask.Code,
                    ParentTaskName = projectTaskPersistenceEntity.ParentTask == null ? null : projectTaskPersistenceEntity.ParentTask.Name,
                    ResponsibleEmployeeCode = projectTaskPersistenceEntity.ResponsibleEmployee == null ? null : projectTaskPersistenceEntity.ResponsibleEmployee.Code,
                    ResponsibleEmployeeName = projectTaskPersistenceEntity.ResponsibleEmployee == null ? null : projectTaskPersistenceEntity.ResponsibleEmployee.Name,
                    ExpectedTime = projectTaskPersistenceEntity.MainProjectTask.ExpectedTime,
                    OptimisticTime = projectTaskPersistenceEntity.MainProjectTask.OptimisticTime,
                    PessimisticTime = projectTaskPersistenceEntity.MainProjectTask.PessimisticTime,
                    NormalTime = projectTaskPersistenceEntity.MainProjectTask.NormalTime
                });
            }
            return projectTasksList;
        }

        public Project Read(string identifier)
        {
            throw new NotImplementedException();
        }

        ProjectTask IPersistenceManager<ProjectTask>.Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
