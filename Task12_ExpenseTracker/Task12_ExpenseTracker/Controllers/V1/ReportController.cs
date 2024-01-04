using Logic.DTO_Contracts.Requests.Get;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Task12_ExpenseTracker.ExceptionFilters;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    [ReportControllerExceptionFilterAttribute]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost(ApiRoutes.Reports.GetDailyReport)]
        public async Task<IActionResult> GetDailyReport([FromBody] GetDailyReportReqDTO getDailyReport, CancellationToken cancellationToken)
        {
            if (!DateTime.TryParseExact(getDailyReport.DateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var selectedDate))
            {
                return BadRequest("Invalid DateTime format. Please use 'yyyy-MM-dd'.");
            }

            var report = await _reportService.GetDailyReportAsync(selectedDate, cancellationToken);

            if (report.ErrorMessage is null)
            {
                return Ok(report);
            }

            return StatusCode(report.ErrorMessage.StatusCode, report.ErrorMessage);
        }

        [HttpPost(ApiRoutes.Reports.GetDatePeriodReport)]
        public async Task<IActionResult> GetDatePeriodReport([FromBody] GetDatePeriodReportReqDTO getDatePeriodReport, CancellationToken cancellationToken)
        {
            if (!DateTime.TryParseExact(getDatePeriodReport.StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate) ||
                !DateTime.TryParseExact(getDatePeriodReport.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate))
            {
                return BadRequest("Invalid DateTime format. Please use 'yyyy-MM-dd'.");
            }

            var report = await _reportService.GetDatePeriodReportAsync(startDate, endDate, cancellationToken);

            if (report.ErrorMessage is null)
            {
                return Ok(report);
            }

            return StatusCode(report.ErrorMessage.StatusCode, report.ErrorMessage);
        }
    }
}
