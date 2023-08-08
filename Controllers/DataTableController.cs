using Calender_TestCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;

namespace Calender_TestCase.Controllers
{


    public class DataTableController : Controller
    {
        private readonly CalenderContext calenderContext;
        public DataTableController(CalenderContext _CalenderContext)
        {
            calenderContext = _CalenderContext;
        }

        public IActionResult Index()
        {
            using (var context = new CalenderContext())
            {




                var HeaderDate = calenderContext.HeaderTables.Select(t => t.Date).ToList();
                var allMeetingDetails = calenderContext.DataTables.Select(d => d.MeetingDetails).Distinct().ToList();

                var meetingSelectListItems = allMeetingDetails.Select(meeting => new SelectListItem
                {
                    Value = meeting, // Set the value of the option
                    Text = meeting,  // Set the text displayed in the option
                }).ToList();


                var ViewModel = new CombinedModels
                {
                    Dates = HeaderDate,
                    MeetingDetails = new List<List<string>>()
                };


                foreach (var date in HeaderDate)
                {
                    var meetingsForDate = context.DataTables
                        .Where(d => d.Date == date)
                        .Select(d => d.MeetingDetails)
                        .ToList();
                    ViewModel.MeetingDetails.Add(meetingsForDate);
                }

                ViewBag.AllMeetingDetails = new SelectList(meetingSelectListItems, "Value", "Text");


                return View(ViewModel);
            }
        }
        [HttpPost]
        public IActionResult FilterTableByMeeting(string meeting)
        {
            using (var context = new CalenderContext())
            {
                var HeaderDate = context.HeaderTables.Select(t => t.Date).ToList();

                var ViewModel = new CombinedModels
                {
                    Dates = HeaderDate,
                    MeetingDetails = new List<List<string>>()
                };

                foreach (var date in HeaderDate)
                {
                    var meetingsForDate = context.DataTables
                        .Where(d => d.Date == date && d.MeetingDetails == meeting)
                        .Select(d => d.MeetingDetails)
                        .ToList();
                    ViewModel.MeetingDetails.Add(meetingsForDate);
                }

                return PartialView("_TablePartial", ViewModel);

            }
        }
    }
}