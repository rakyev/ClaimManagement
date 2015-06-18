using System;
using System.Linq;
using System.Web;
using ICM.Data.Business.BusinessObject;

namespace ICM.Data.Business.CountImplementation
{
    public class ClientCaseDoctorAppointmentCounts
    {


        public static long ClientCount
        {
            get
            {
                if (_countClient == 0)
                    _countClient = new ClientBO().GetAll().Count();

                return _countClient;
            }

            set
            {
                _countClient = value;
            }
        }


        public static long DoctorCount
        {
            get
            {
                if (_countDoctor == 0)
                    _countDoctor = new AppointmentResourceBO().GetAll().Count();

                return _countDoctor;
            }

            set
            {
                _countDoctor = value;
            }
        }


        public static long CaseCount
        {
            get
            {
                if (_countCase == 0)
                    _countCase = new ClientCaseBO().GetAll().Count();

                return _countCase;
            }

            set
            {
                _countCase = value;
            }
        }


        public static long AppointmentCount
        {
            get
            {
                if (_countAppointment == 0)
                    _countAppointment = new ActivityBookingBO().GetAll().Count();

                return _countAppointment;
            }

            set
            {
                _countAppointment = value;
            }
        }


        private static long _countClient;
        private static long _countDoctor;
        private static long _countCase;
        private static long _countAppointment;

    }
}
