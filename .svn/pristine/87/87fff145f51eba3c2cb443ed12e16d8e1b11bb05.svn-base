using System.Drawing;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using ICM.Web.GraphData;
using ICM.Web.Models;

namespace ICM.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ClientCaseAppiointmentVirtual.PopulateAllFieilds();
            var datee = ClientCaseAppiointmentVirtual.GetXaxis()[0];
            var datee2 = ClientCaseAppiointmentVirtual.GetXaxis()[4];
            var chart = new Highcharts("charts")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                .SetTitle(new Title { Text = "Clients, Cases, Doctors and Appointments Statistics" })
                .SetSubtitle(new Subtitle { Text = "Records from " + datee + " to " + datee2 })
                .SetXAxis(new XAxis { Categories = ClientCaseAppiointmentVirtual.GetXaxis()})
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Counts"},AllowDecimals = false,Min = 0})
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    Formatter = @"function() { return '<b>'+ this.series.name  + ':</b> ' + this.y + ' added' + '<br/>' + this.x }"
                })
                .SetPlotOptions(new PlotOptions
                {
                    Line = new PlotOptionsLine
                    {
                        DataLabels = new PlotOptionsLineDataLabels
                        {
                            Enabled = true
                        },
                        EnableMouseTracking = true,
                        Animation = new Animation(true)
                    }
                })
                .SetSeries(new[]
                {
                    new Series{Name = "Clients",Color = Color.RoyalBlue,Data = new DotNet.Highcharts.Helpers.Data(new object[]
                    {
                        ClientCaseAppiointmentVirtual.GetClientCount()[0],
                        ClientCaseAppiointmentVirtual.GetClientCount()[1],
                        ClientCaseAppiointmentVirtual.GetClientCount()[2],
                        ClientCaseAppiointmentVirtual.GetClientCount()[3],
                        ClientCaseAppiointmentVirtual.GetClientCount()[4]
                    })
                    },
                    new Series{Name = "Cases",Color = Color.LimeGreen,Data = new DotNet.Highcharts.Helpers.Data(new object[]
                    {
                        ClientCaseAppiointmentVirtual.GetCaseCount()[0], 
                        ClientCaseAppiointmentVirtual.GetCaseCount()[1],
                        ClientCaseAppiointmentVirtual.GetCaseCount()[2],
                        ClientCaseAppiointmentVirtual.GetCaseCount()[3],
                        ClientCaseAppiointmentVirtual.GetCaseCount()[4]
                    })
                    },
                    new Series{Name = "Doctors",Color = Color.Orange,Data = new DotNet.Highcharts.Helpers.Data(new object[]
                    {
                        ClientCaseAppiointmentVirtual.GetDoctorsCount()[0],
                        ClientCaseAppiointmentVirtual.GetDoctorsCount()[1],
                        ClientCaseAppiointmentVirtual.GetDoctorsCount()[2],
                        ClientCaseAppiointmentVirtual.GetDoctorsCount()[3],
                        ClientCaseAppiointmentVirtual.GetDoctorsCount()[4]
                    })
                    },
                    new Series{Name = "Appointment",Color = Color.Red, Data = new DotNet.Highcharts.Helpers.Data(new object[]
                    {
                        ClientCaseAppiointmentVirtual.GetAppointmentCount()[0],
                        ClientCaseAppiointmentVirtual.GetAppointmentCount()[1],
                        ClientCaseAppiointmentVirtual.GetAppointmentCount()[2],
                        ClientCaseAppiointmentVirtual.GetAppointmentCount()[3],
                        ClientCaseAppiointmentVirtual.GetAppointmentCount()[4]
                    })
                }});

            //ClientCaseDoctorAppointmentCounts insObj = new ClientCaseDoctorAppointmentCounts();

            //TempData.Add("count", insObj);

            return View(chart);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}