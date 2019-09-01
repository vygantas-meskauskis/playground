using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Finance.Application.Analytics.Models;
using Finance.Application.Reports.Models;
using Finance.Client.Interfaces;
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
        public async Task<ActionResult<FinanceTransactionsListViewModel>> FinanceReport()
        {
            return Ok(await _financeReportService.GetAllFinanceReports());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<CategorizedFinanceTransactionsViewModel>>> CategorizedTransactions([FromQuery] string[] sources)
        {
            return Ok(await _financeReportService.GetCategorizedFinanceTransactions(sources.ToList()));
        }
    }
}