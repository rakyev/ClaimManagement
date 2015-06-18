using System;
using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class GenderBO : GenericRepository<Gender>
    {
        //public override IQueryable<Gender> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<Gender>().OrderBy(item => item.GenderID).Skip(skip).Take(take);
        //}
        public List<Gender> GetByCode(String code)
        {          
            var result = from codes in Context.Genders
                          where codes.Code == code
                          select codes;
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
