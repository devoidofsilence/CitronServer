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
                Description = project.Name.NullIfEmptyString(),
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
            projectPersistenceEntity.Description = project.Name.NullIfEmptyString();

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

            Project project = new Project();
            if (projectPersistenceEntity != null)
            {
                project.Code = projectPersistenceEntity.Code;
                project.Name = projectPersistenceEntity.Name;
                project.Description = projectPersistenceEntity.Description;
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
