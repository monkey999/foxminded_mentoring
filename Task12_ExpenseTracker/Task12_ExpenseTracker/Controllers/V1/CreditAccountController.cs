using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    public class CreditAccountController : ControllerBase
    {
        private readonly ICreditAccountService _creditAccountService;

        public CreditAccountController(ICreditAccountService creditAccountService)
        {
            _creditAccountService = creditAccountService;
        }

        [HttpPost(ApiRoutes.CreditAccounts.CreateCreditAccount)]
        public async Task<IActionResult> CreateCreditAccount([FromBody] CreateCreditAccountReqDTO request)
        {
            var response = await _creditAccountService.CreateCreditAccountWithResultAsync(request);

            if (response.ErrorMessage == null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.CreditAccounts.GetCreditAccountByID.Replace("{creditAccountId}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.CreditAccounts.GetCreditAccounts)]
        public async Task<IActionResult> GetAllCreditAccounts()
        {
            var creditAccounts = await _creditAccountService.GetAllCreditAccountsAsync();

            if (creditAccounts == null)
            {
                return NotFound();
            }

            return Ok(creditAccounts);
        }

        [HttpGet(ApiRoutes.CreditAccounts.GetCreditAccountByID)]
        public async Task<IActionResult> GetCreditAccountById([FromRoute] Guid Id)
        {
            var creditAccountResponse = await _creditAccountService.GetCreditAccountByIdAsync(Id);

            if (creditAccountResponse != null && creditAccountResponse.CreditAccountsRespDto.Any())
            {
                return Ok(creditAccountResponse);
            }
            else if (creditAccountResponse.ErrorMessage != null)
            {
                return StatusCode(creditAccountResponse.ErrorMessage.StatusCode, creditAccountResponse.ErrorMessage);
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.CreditAccounts.UpdateCreditAccount)]
        public async Task<IActionResult> UpdateCreditAccount([FromBody] UpdateCreditAccountReqDTO request)
        {
            //TODO: add modelstate check: user must provide id or its not update 

            var updated = await _creditAccountService.UpdateCreditAccountAsync(request);

            if (updated.ErrorMessage == null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpDelete(ApiRoutes.CreditAccounts.DeleteCreditAccount)]
        public async Task<IActionResult> DeleteCreditAccount([FromRoute] Guid Id)
        {
            var deleted = await _creditAccountService.DeleteCreditAccountAsync(Id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
