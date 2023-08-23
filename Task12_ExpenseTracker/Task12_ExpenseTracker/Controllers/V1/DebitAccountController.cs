using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    public class DebitAccountController : ControllerBase
    {
        private readonly IDebitAccountService _debitAccountService;

        public DebitAccountController(IDebitAccountService debitAccountService)
        {
            _debitAccountService = debitAccountService;
        }

        [HttpPost(ApiRoutes.DebitAccounts.CreateDebitAccount)]
        public async Task<IActionResult> CreateDebitAccount([FromBody] CreateDebitAccountReqDTO request)
        {
            var response = await _debitAccountService.CreateDebitAccountWithResultAsync(request);

            if (response.ErrorMessage == null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.DebitAccounts.GetDebitAccountByID.Replace("{debitAccountId}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.DebitAccounts.GetAllDebitAccounts)]
        public async Task<IActionResult> GetAllDebitAccounts()
        {
            var debitAccounts = await _debitAccountService.GetAllDebitAccountsAsync();

            if (debitAccounts == null)
            {
                return NotFound();
            }

            return Ok(debitAccounts);
        }

        [HttpGet(ApiRoutes.DebitAccounts.GetDebitAccountByID)]
        public async Task<IActionResult> GetDebitAccountById([FromRoute] Guid Id)
        {
            var debitAccountResponse = await _debitAccountService.GetDebitAccountByIdAsync(Id);

            if (debitAccountResponse != null && debitAccountResponse.DebitAccountsRespDto.Any())
            {
                return Ok(debitAccountResponse);
            }
            else if (debitAccountResponse.ErrorMessage != null)
            {
                return StatusCode(debitAccountResponse.ErrorMessage.StatusCode, debitAccountResponse.ErrorMessage);
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.DebitAccounts.UpdateDebitAccount)]
        public async Task<IActionResult> UpdateDebitAccount([FromBody] UpdateDebitAccountReqDTO request)
        {
            //TODO: add modelstate check: user must provide id or its not update 

            var updated = await _debitAccountService.UpdateDebitAccountAsync(request);

            if (updated.ErrorMessage == null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpDelete(ApiRoutes.DebitAccounts.DeleteDebitAccount)]
        public async Task<IActionResult> DeleteDebitAccount([FromRoute] Guid Id)
        {
            var deleted = await _debitAccountService.DeleteDebitAccountAsync(Id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
