using System;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.GraphData
{
    public class ClientCaseAppiointmentVirtual
    {
       

        private const int NumberOfDays = 5;


        

        private static readonly ClientBO ClientBo = new ClientBO();
        private static readonly ClientCaseBO CaseBo = new ClientCaseBO();
        private static readonly ActivityBookingBO ActivityBookingBo = new ActivityBookingBO();
        private static readonly AppointmentResourceBO AppointmentResourceBo = new AppointmentResourceBO();

       
        private static readonly string[] XAxis = new string[NumberOfDays];
        private static readonly int[] ClientCount = new int[NumberOfDays];
        private static readonly int[] CaseCount = new int[NumberOfDays];
        private static readonly int[] AppointmentCount = new int[NumberOfDays];
        private static readonly int[] DoctorsCount = new int[NumberOfDays];


        public static void PopulateAllFieilds()
        {
            var count = -5;
            for (var i = 0; i < XAxis.Length; i++)
            {
                DateTime date = DateTime.Today.AddDays(count);
                XAxis[i] = DateTime.Today.AddDays(count).Date.ToString("yyyy-MMM-dd ddd");

                ClientCount[i] = ClientBo.CountClientByDateCreated(date);
                CaseCount[i] = CaseBo.CountCaseByDateCreated(date);
                AppointmentCount[i] = ActivityBookingBo.CountCaseByDateCreated(date);
                DoctorsCount[i] = AppointmentResourceBo.CountDoctorsByDateCreated(date);
                count++;
            }
        }
        
        
        public static int[] GetClientCount()
        {
            return ClientCount;
        }

        public static int[] GetAppointmentCount()
        {
            return AppointmentCount;
        }

        public static int[] GetCaseCount()
        {
            return CaseCount;
        }

        public static int[] GetDoctorsCount()
        {
            return DoctorsCount;
        }

        public static string[] GetXaxis()
        {
            return XAxis;
        }

        
    }

   
}