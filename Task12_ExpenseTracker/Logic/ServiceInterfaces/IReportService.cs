using Logic.DTO_Contracts.Responses.Get;

namespace Logic.ServiceInterfaces
{
    public interface IReportService
    {
        Task<GetDailyReportRespDTO> GetDailyReportAsync(DateTime selectedDate, CancellationToken cancellationToken);
        Task<GetDatePeriodReportRespDTO> GetDatePeriodReportAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}
