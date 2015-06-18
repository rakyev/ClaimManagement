using ICM.Data.Business.RepositoryImplementation;
using System.Collections.Generic;
using System.Linq;

//Created by Femi 2015-02-08 02:44AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseContactRelationshipBO : GenericRepository<CaseContactRelationship>
    {
        //public override IQueryable<CaseContactRelationship> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<CaseContactRelationship>().OrderBy(item => item.CaseContactRelationshipID).Skip(skip).Take(take);
        //}
        public List<CaseContactRelationship> GetRelationshipsSearched(string search)
        {
            var query = from test in Context.CaseContactRelationships
                        where test.Description.Contains(search)
                        select test;

            return query.ToList();
        }
    }
}
