using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForActivityBookingModel
    {
        private ActivityBookingBO _activityBookingBo;

        private List<AppointmentResourceModels> _appointmentResource;
        private List<CaseActivityModels> _caseActivities;
        private List<GoodAndService> _goodAndServices;


        public ForeignKeysForActivityBookingModel()
        {   
            _activityBookingBo = new ActivityBookingBO();

             var appointmentResourcesList = _activityBookingBo.GetAppointmentResources();
            _appointmentResource = ModelAdapter.GetConvertedModelList(appointmentResourcesList, new List<AppointmentResourceModels>());

            var caseActivityList = _activityBookingBo.GetCaseActivities();
            _caseActivities = ModelAdapter.GetConvertedModelList(caseActivityList, new List<CaseActivityModels>());

            var goodsAndServicesList = _activityBookingBo.GetGoodAndServices();
            _goodAndServices = ModelAdapter.GetConvertedModelList(goodsAndServicesList, new List<GoodAndService>());

           
        }

        public List<AppointmentResourceModels> GetAppointmentResources()
        {
            return _appointmentResource;
        }

        public List<CaseActivityModels> GetCaseActivities()
        {
            return _caseActivities;
        }

        public List<GoodAndService> GetGoodAndServices()
        {
            return _goodAndServices;
        }
    }
}