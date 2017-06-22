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
            var assignStakeholderPersistenceEntity = new AssignStakeholderPersistenceEntity()
            {
                ProjectCode = assignStakeholder.ProjectCode.NullIfEmptyString(),
                StakeholderCode = assignStakeholder.StakeholderCode.NullIfEmptyString(),
                PowerOnProject = assignStakeholder.PowerOnProject.NullIfEmptyString(),
                InterestOnProject = assignStakeholder.InterestOnProject.NullIfEmptyString(),
                AssignedAsKey = assignStakeholder.AssignAsKey.NullIfEmptyString(),
            };

            db.AssignStakeholderPersistenceEntities.Add(assignStakeholderPersistenceEntity);
            db.SaveChanges();
            return assignStakeholder;
        }

        public AssignStakeholder Delete(AssignStakeholder assignStakeholder)
        {
            var assignStakeholderPersistenceEntity = db.AssignStakeholderPersistenceEntities.FirstOrDefault(e => e.ProjectCode == assignStakeholder.ProjectCode && e.StakeholderCode == assignStakeholder.StakeholderCode);
            db.AssignStakeholderPersistenceEntities.Remove(assignStakeholderPersistenceEntity);

            db.SaveChanges();
            return assignStakeholder;
        }

        public AssignStakeholder Find(object id)
        {
            List<string> codes = ((List<string>)id);
            var stakeholdersPersistenceEntity = db.AssignStakeholderPersistenceEntities.FirstOrDefault(e => e.ProjectCode == codes[0].ToString() && e.StakeholderCode == codes[1].ToString());

            AssignStakeholder stakeholder = new AssignStakeholder();
            if (stakeholdersPersistenceEntity != null)
            {
                stakeholder.ProjectCode = stakeholdersPersistenceEntity.ProjectCode;
                stakeholder.StakeholderCode = stakeholdersPersistenceEntity.StakeholderCode;
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
                                   join projectTable in db.ProjectPersistenceEntities on assignedStakeholderTable.ProjectCode equals projectTable.Code into aspJoin
                                   from asp in aspJoin.DefaultIfEmpty()
                                   join stakeholderTable in db.StakeholderPersistenceEntities on assignedStakeholderTable.StakeholderCode equals stakeholderTable.Code into saspJoin
                                   from sasp in saspJoin.DefaultIfEmpty()
                                   select new { AssignedStakeholder = assignedStakeholderTable, Project = asp, Stakeholder = sasp });

            var tt = aggregatedTable.ToList();

            foreach (var assignStakeholdersPersistenceEntity in aggregatedTable)
            {
                    assignedStakeholdersList.Add(new AssignStakeholder
                    {
                        ProjectCode = assignStakeholdersPersistenceEntity.AssignedStakeholder.ProjectCode,
                        ProjectName = assignStakeholdersPersistenceEntity.Project.Name,
                        StakeholderCode = assignStakeholdersPersistenceEntity.AssignedStakeholder.StakeholderCode,
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
            var assignStakeholderPersistenceEntity = db.AssignStakeholderPersistenceEntities.FirstOrDefault(e => e.ProjectCode == assignStakeholder.ProjectCode && e.StakeholderCode == assignStakeholder.StakeholderCode);
            assignStakeholderPersistenceEntity.PowerOnProject = assignStakeholder.PowerOnProject.NullIfEmptyString();
            assignStakeholderPersistenceEntity.InterestOnProject = assignStakeholder.InterestOnProject.NullIfEmptyString();
            assignStakeholderPersistenceEntity.AssignedAsKey = assignStakeholder.AssignAsKey.NullIfEmptyString();

            db.SaveChanges();
            return assignStakeholder;
        }
    }
}
