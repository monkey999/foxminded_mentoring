using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    public class DebtAccountController : ControllerBase
    {
       private readonly IDebtAccountService _debtAccountService;

        public DebtAccountController(IDebtAccountService debtAccountService)
        {
            _debtAccountService = debtAccountService;
        }

        [HttpPost(ApiRoutes.DebtAccounts.CreateDebtAccount)]
        public async Task<IActionResult> CreateDebtAccount([FromBody] CreateDebtAccountReqDTO request)
        {
            var response = await _debtAccountService.CreateDebtAccountWithResultAsync(request);

            if (response.ErrorMessage == null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.DebtAccounts.GetDebtAccountByID.Replace("{debtAccountId}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.DebtAccounts.GetAllDebtAccounts)]
        public async Task<IActionResult> GetAllDebtAccounts()
        {
            var DebtAccounts = await _debtAccountService.GetAllDebtAccountsAsync();

            if (DebtAccounts == null)
            {
                return NotFound();
            }

            return Ok(DebtAccounts);
        }

        [HttpGet(ApiRoutes.DebtAccounts.GetDebtAccountByID)]
        public async Task<IActionResult> GetDebtAccountById([FromRoute] Guid Id)
        {
            var debtAccountResponse = await _debtAccountService.GetDebtAccountByIdAsync(Id);

            if (debtAccountResponse != null && debtAccountResponse.DebtAccountsRespDto.Any())
            {
                return Ok(debtAccountResponse);
            }
            else if (debtAccountResponse.ErrorMessage != null)
            {
                return StatusCode(debtAccountResponse.ErrorMessage.StatusCode, debtAccountResponse.ErrorMessage);
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.DebtAccounts.UpdateDebtAccount)]
        public async Task<IActionResult> UpdateDebtAccount([FromBody] UpdateDebtAccountReqDTO request)
        {
            //TODO: add modelstate check: user must provide id or its not update 

            var updated = await _debtAccountService.UpdateDebtAccountAsync(request);

            if (updated.ErrorMessage == null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpDelete(ApiRoutes.DebtAccounts.DeleteDebtAccount)]
        public async Task<IActionResult> DeleteDebtAccount([FromRoute] Guid Id)
        {
            var deleted = await _debtAccountService.DeleteDebtAccountAsync(Id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
