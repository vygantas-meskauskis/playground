using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Finance.Application.Reports.Queries;
using Finance.Client.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Feature.Finance
{
    [Route("api/[controller]")]
    public class FinanceDataController : Controller
    {
        private readonly IFinanceReportService _financeReportService;
        public FinanceDataController(IFinanceReportService financeReportService)
        {
            _financeReportService = financeReportService;
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadData()
        {
            using (var stream = new MemoryStream())
            {
                await Request.Body.CopyToAsync(stream);
                await _financeReportService.UploadFileAsync("revolut", stream);
            }

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<FinanceReportViewModel>> FinanceReportAsync()
        {
            var reports =  await _financeReportService.GetAllFinanceReports();
            return reports.FinanceReportViewModels;
        }

    }
}