using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System.Data;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordServicecs _salesRecordServices;

        public SalesRecordsController(SalesRecordServicecs salesRecordServices)
        {
               _salesRecordServices = salesRecordServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        { 
            if (!minDate.HasValue) 
            {
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }


            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordServices.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
