using System;
using System.Linq;
using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class ProvinceOrStateBO : GenericRepository<ProvinceOrState>
    {
       

        public List<ProvinceOrState> GetByCode(String code)
        {
            var result = from c in Context.ProvinceOrStates
                         where c.Code == code
                         select c;
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<ProvinceOrState> GetProvinces(string description)
        {
            var query = from item in Context.ProvinceOrStates
                where item.Description.Contains(description)
                select item;

            return query.ToList();

        } 
    }
}
