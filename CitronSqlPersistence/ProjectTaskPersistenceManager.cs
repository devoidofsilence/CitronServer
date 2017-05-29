using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;
using CitronWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence
{
    public class ProjectTaskPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public ProjectTask Create(ProjectTask projectTask)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(projectTask.ParentTask))
            {
                var parentTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ParentTask);
                if (parentTaskPersistenceEntity != null)
                {
                    dh.parentTaskID = parentTaskPersistenceEntity.ID;
                }
            }
            if (!string.IsNullOrEmpty(projectTask.ResponsibleEmployee))
            {
                var responsibleEmployeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ResponsibleEmployee);
                if (responsibleEmployeePersistenceEntity != null)
                {
                    dh.responsibleEmployeeID = responsibleEmployeePersistenceEntity.ID;
                }
            }

            var projectTaskPersistenceEntity = new ProjectTaskPersistenceEntity()
            {
                Code = projectTask.Code.NullIfEmptyString(),
                Name = projectTask.Name.NullIfEmptyString(),
                Description = projectTask.Name.NullIfEmptyString(),
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
            if (!string.IsNullOrEmpty(projectTask.ParentTask))
            {
                var parentTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ParentTask);
                if (parentTaskPersistenceEntity != null)
                {
                    dh.parentTaskID = parentTaskPersistenceEntity.ID;
                }
            }
            if (!string.IsNullOrEmpty(projectTask.ResponsibleEmployee))
            {
                var responsibleEmployeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == projectTask.ResponsibleEmployee);
                if (responsibleEmployeePersistenceEntity != null)
                {
                    dh.responsibleEmployeeID = responsibleEmployeePersistenceEntity.ID;
                }
            }
            var projectTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == projectTask.Code);
            projectTaskPersistenceEntity.Code = projectTask.Code.NullIfEmptyString();
            projectTaskPersistenceEntity.Name = projectTask.Name.NullIfEmptyString();
            projectTaskPersistenceEntity.Description = projectTask.Name.NullIfEmptyString();
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

        public ProjectTask Find(string code)
        {
            var dh = new TempDataHolder();
            var projectTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.Code == code);

            ProjectTask projectTask = new ProjectTask();
            if (projectTaskPersistenceEntity != null)
            {
                if (projectTaskPersistenceEntity.ParentProjectTaskID != null)
                {
                    var parentTaskPersistenceEntity = db.ProjectTaskPersistenceEntities.FirstOrDefault(e => e.ID == projectTaskPersistenceEntity.ParentProjectTaskID);
                    if (parentTaskPersistenceEntity != null)
                    {
                        dh.parentTaskCode = parentTaskPersistenceEntity.Code;
                    }
                }
                if (projectTaskPersistenceEntity.ParentProjectTaskID != null)
                {
                    var responsibleEmployeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.ID == projectTaskPersistenceEntity.ResponsibleEmployeeID);
                    if (responsibleEmployeePersistenceEntity != null)
                    {
                        dh.responsibleEmployeeCode = responsibleEmployeePersistenceEntity.Code;
                    }
                }
                projectTask.Code = projectTaskPersistenceEntity.Code;
                projectTask.Name = projectTaskPersistenceEntity.Name;
                projectTask.Description = projectTaskPersistenceEntity.Description;
                projectTask.ParentTask = dh.parentTaskCode;
                projectTask.ResponsibleEmployee = dh.responsibleEmployeeCode;
                projectTask.ExpectedTime = projectTaskPersistenceEntity.ExpectedTime;
                projectTask.OptimisticTime = projectTaskPersistenceEntity.OptimisticTime;
                projectTask.NormalTime = projectTaskPersistenceEntity.NormalTime;
                projectTask.PessimisticTime = projectTaskPersistenceEntity.PessimisticTime;
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
                                   join responsibleEmployeeTable in db.EmployeePersistenceEntities on mainProjectTaskTable.ResponsibleEmployeeID equals responsibleEmployeeTable.ID into reJoin
                                   from re in reJoin.DefaultIfEmpty()
                                   select new { MainProjectTask = mainProjectTaskTable, ParentTask = pt, ResponsibleEmployee = re });

            var tt = aggregatedTable.ToList();

            foreach (var projectTaskPersistenceEntity in aggregatedTable)
            {
                projectTasksList.Add(new ProjectTask()
                {
                    Code = projectTaskPersistenceEntity.MainProjectTask.Code,
                    Name = projectTaskPersistenceEntity.MainProjectTask.Name,
                    Description = projectTaskPersistenceEntity.MainProjectTask.Description,
                    ParentTask = projectTaskPersistenceEntity.ParentTask == null ? null : projectTaskPersistenceEntity.ParentTask.Code,
                    ResponsibleEmployee = projectTaskPersistenceEntity.ResponsibleEmployee== null ? null : projectTaskPersistenceEntity.ResponsibleEmployee.Code,
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
    }
}
