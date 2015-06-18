using System.Collections.Generic;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForClientModel
    {
        public ForeignKeysForClientModel()
        {
            var clientObject = new ClientBO();

            CountryList = new List<Country>();
            GenderList = new List<Gender>();
            PrefixesList = new List<Prefix>();
            ProvinceOrStatesList = new List<ProvinceOrState>();
            MaritalList = new List<MaritalState>();

            ModelAdapter.GetConvertedModelList(clientObject.GetCountryList(), CountryList);
            ModelAdapter.GetConvertedModelList(clientObject.GetGenderList(), GenderList);
            ModelAdapter.GetConvertedModelList(clientObject.GetMaritalStateList(), MaritalList);
            ModelAdapter.GetConvertedModelList(clientObject.GetPrefixList(), PrefixesList);
            ModelAdapter.GetConvertedModelList(clientObject.GetProvinceOrStateList(), ProvinceOrStatesList);
        }
        private List<Country> CountryList;
        private List<Gender> GenderList; 
        private List<MaritalState> MaritalList;
        private List<Prefix> PrefixesList;
        private List<ProvinceOrState> ProvinceOrStatesList;

        public List<Country> GetCountries()
        {
            return CountryList;
        }

        public List<Gender> Gengers()
        {
            return GenderList;
        }

        public List<MaritalState> GetMaritals()
        {
            return MaritalList;
        }


        public List<Prefix> GetPrexises()
        {
            return PrefixesList;
        }


        public List<ProvinceOrState> GetProvincesList()
        {
            return ProvinceOrStatesList;
        }
    }
}