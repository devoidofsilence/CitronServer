using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;
using CitronWeb.Utils;

namespace CitronSqlPersistence
{
    public class AssignStakeholderPersistenceManager : IAssignStakeholderPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public AssignStakeholder Create(AssignStakeholder assignStakeholder)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(assignStakeholder.ProjectCode))
            {
                var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == assignStakeholder.ProjectCode);
                if (projectPersistenceEntity != null)
                {
                    dh.projectID = projectPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(assignStakeholder.StakeholderCode))
            {
                var stakeholderPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == assignStakeholder.StakeholderCode);
                if (stakeholderPersistenceEntity != null)
                {
                    dh.stakeholderID = stakeholderPersistenceEntity.ID;
                }
            }
            var assignStakeholderPersistenceEntity = new AssignStakeholderPersistenceEntity()
            {
                ProjectId = dh.projectID,
                StakeholderId = dh.stakeholderID,
                PowerOnProject = assignStakeholder.PowerOnProject,
                InterestOnProject = assignStakeholder.InterestOnProject,
                AssignedAsKey = assignStakeholder.AssignAsKey,
            };

            db.AssignStakeholderPersistenceEntities.Add(assignStakeholderPersistenceEntity);
            db.SaveChanges();
            return assignStakeholder;
        }

        public AssignStakeholder Delete(AssignStakeholder assignStakeholder)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(assignStakeholder.ProjectCode))
            {
                var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == assignStakeholder.ProjectCode);
                if (projectPersistenceEntity != null)
                {
                    dh.projectID = projectPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(assignStakeholder.StakeholderCode))
            {
                var stakeholderPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == assignStakeholder.StakeholderCode);
                if (stakeholderPersistenceEntity != null)
                {
                    dh.stakeholderID = stakeholderPersistenceEntity.ID;
                }
            }
            var assignStakeholderPersistenceEntity = db.AssignStakeholderPersistenceEntities.FirstOrDefault(e => e.ProjectId == dh.projectID && e.StakeholderId == dh.stakeholderID);
            db.AssignStakeholderPersistenceEntities.Remove(assignStakeholderPersistenceEntity);

            db.SaveChanges();
            return assignStakeholder;
        }

        public AssignStakeholder Find(object id)
        {
            List<string> codes = ((List<string>)id);
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(codes[0]))
            {
                string prjCode = codes[0].NullIfEmptyString();
                var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == prjCode);
                if (projectPersistenceEntity != null)
                {
                    dh.projectID = projectPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(codes[1]))
            {
                string stakeholderCode = codes[1].NullIfEmptyString();
                var stakeholderPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == stakeholderCode);
                if (stakeholderPersistenceEntity != null)
                {
                    dh.stakeholderID = stakeholderPersistenceEntity.ID;
                }
            }
            var stakeholdersPersistenceEntity = db.AssignStakeholderPersistenceEntities.FirstOrDefault(e => e.ProjectId == dh.projectID && e.StakeholderId == dh.stakeholderID);

            AssignStakeholder stakeholder = new AssignStakeholder();
            if (stakeholdersPersistenceEntity != null)
            {
                stakeholder.ProjectCode = codes[0].NullIfEmptyString();
                stakeholder.StakeholderCode = codes[1].NullIfEmptyString();
                stakeholder.PowerOnProject = stakeholdersPersistenceEntity.PowerOnProject;
                stakeholder.InterestOnProject = stakeholdersPersistenceEntity.InterestOnProject;
                stakeholder.AssignAsKey = stakeholdersPersistenceEntity.AssignedAsKey;
            }
            return stakeholder;
        }

        public IList<AssignStakeholder> FindAll(Func<AssignStakeholder, bool> condition)
        {
            IList<AssignStakeholder> assignedStakeholdersList = new List<AssignStakeholder>();

            var aggregatedTable = (from assignedStakeholderTable in db.AssignStakeholderPersistenceEntities
                                   join projectTable in db.ProjectPersistenceEntities on assignedStakeholderTable.ProjectId equals projectTable.ID into aspJoin
                                   from asp in aspJoin.DefaultIfEmpty()
                                   join stakeholderTable in db.StakeholderPersistenceEntities on assignedStakeholderTable.StakeholderId equals stakeholderTable.ID into saspJoin
                                   from sasp in saspJoin.DefaultIfEmpty()
                                   select new { AssignedStakeholder = assignedStakeholderTable, Project = asp, Stakeholder = sasp });

            var tt = aggregatedTable.ToList();

            foreach (var assignStakeholdersPersistenceEntity in aggregatedTable)
            {
                    assignedStakeholdersList.Add(new AssignStakeholder
                    {
                        ProjectCode = assignStakeholdersPersistenceEntity.Project.Code,
                        ProjectName = assignStakeholdersPersistenceEntity.Project.Name,
                        StakeholderCode = assignStakeholdersPersistenceEntity.Stakeholder.Code,
                        StakeholderName = assignStakeholdersPersistenceEntity.Stakeholder.Name,
                        PowerOnProject = assignStakeholdersPersistenceEntity.AssignedStakeholder.PowerOnProject,
                        InterestOnProject = assignStakeholdersPersistenceEntity.AssignedStakeholder.InterestOnProject,
                        AssignAsKey = assignStakeholdersPersistenceEntity.AssignedStakeholder.AssignedAsKey
                    });
            }
            return assignedStakeholdersList;
        }

        public AssignStakeholder Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public AssignStakeholder Update(AssignStakeholder assignStakeholder)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(assignStakeholder.ProjectCode))
            {
                var projectPersistenceEntity = db.ProjectPersistenceEntities.FirstOrDefault(e => e.Code == assignStakeholder.ProjectCode);
                if (projectPersistenceEntity != null)
                {
                    dh.projectID = projectPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(assignStakeholder.StakeholderCode))
            {
                var stakeholderPersistenceEntity = db.StakeholderPersistenceEntities.FirstOrDefault(e => e.Code == assignStakeholder.StakeholderCode);
                if (stakeholderPersistenceEntity != null)
                {
                    dh.stakeholderID = stakeholderPersistenceEntity.ID;
                }
            }
            var assignStakeholderPersistenceEntity = db.AssignStakeholderPersistenceEntities.FirstOrDefault(e => e.ProjectId == dh.projectID && e.StakeholderId == dh.stakeholderID);
            assignStakeholderPersistenceEntity.PowerOnProject = assignStakeholder.PowerOnProject;
            assignStakeholderPersistenceEntity.InterestOnProject = assignStakeholder.InterestOnProject;
            assignStakeholderPersistenceEntity.AssignedAsKey = assignStakeholder.AssignAsKey;

            db.SaveChanges();
            return assignStakeholder;
        }
    }
}
