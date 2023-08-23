using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    public class InvestAccountController : ControllerBase
    {
        private readonly IInvestAccountService _investAccountService;

        public InvestAccountController(IInvestAccountService investAccountService)
        {
            _investAccountService = investAccountService;
        }

        [HttpPost(ApiRoutes.InvestAccounts.CreateInvestAccount)]
        public async Task<IActionResult> CreateInvestAccount([FromBody] CreateInvestAccountReqDTO request)
        {
            var response = await _investAccountService.CreateInvestAccountWithResultAsync(request);

            if (response.ErrorMessage == null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.InvestAccounts.GetInvestAccountByID.Replace("{investAccountId}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.InvestAccounts.GetAllInvestAccounts)]
        public async Task<IActionResult> GetAllInvestAccounts()
        {
            var investAccounts = await _investAccountService.GetAllInvestAccountsAsync();

            if (investAccounts == null)
            {
                return NotFound();
            }

            return Ok(investAccounts);
        }

        [HttpGet(ApiRoutes.InvestAccounts.GetInvestAccountByID)]
        public async Task<IActionResult> GetInvestAccountById([FromRoute] Guid Id)
        {
            var investAccountResponse = await _investAccountService.GetInvestAccountByIdAsync(Id);

            if (investAccountResponse != null && investAccountResponse.InvestAccountsRespDto.Any())
            {
                return Ok(investAccountResponse);
            }
            else if (investAccountResponse.ErrorMessage != null)
            {
                return StatusCode(investAccountResponse.ErrorMessage.StatusCode, investAccountResponse.ErrorMessage);
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.InvestAccounts.UpdateInvestAccount)]
        public async Task<IActionResult> UpdateInvestAccount([FromBody] UpdateInvestAccountReqDTO request)
        {
            //TODO: add modelstate check: user must provide id or its not update 

            var updated = await _investAccountService.UpdateInvestAccountAsync(request);

            if (updated.ErrorMessage == null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpDelete(ApiRoutes.InvestAccounts.DeleteInvestAccount)]
        public async Task<IActionResult> DeleteInvestAccount([FromRoute] Guid Id)
        {
            var deleted = await _investAccountService.DeleteInvestAccountAsync(Id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
