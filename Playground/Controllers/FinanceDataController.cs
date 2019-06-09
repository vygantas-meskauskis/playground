using System.Collections.Generic;
using System.IO;
using Finance.Client.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers
{
    [Route("api/[controller]")]
    public class FinanceDataController : Controller
    {
        private readonly IFinanceReportService _financeReportService;
        public FinanceDataController(IFinanceReportService financeReportService)
        {
            _financeReportService = financeReportService;
        }

        [HttpPost]
        public IActionResult UploadData(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            return Ok();
        }

        [Route("financeReport")]
        [HttpGet]
        public IEnumerable<object> GetFinanceReport()
        {
            return _financeReportService.GetAllFinanceReports();
        }

        [HttpPost]
        public IActionResult UploadData()
        {
            //if (file == null || file.Length == 0)
            //    return Content("file not selected");

            //var path = Path.Combine(
            //            Directory.GetCurrentDirectory(), "wwwroot",
            //            file.FileName);

            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    file.CopyToAsync(stream);
            //}

            return Ok();
        }

    }
}