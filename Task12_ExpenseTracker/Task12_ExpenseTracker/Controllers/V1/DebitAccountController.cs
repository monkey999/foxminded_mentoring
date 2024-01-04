using Domain.Models.Accounts;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Task12_ExpenseTracker.ExceptionFilters;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    [DebitAccountControllerExceptionFilterAttribute]
    public class DebitAccountController : ControllerBase
    {
        private readonly IDebitAccountService _debitAccountService;

        public DebitAccountController(IDebitAccountService debitAccountService)
        {
            _debitAccountService = debitAccountService;
        }

        [HttpPost(ApiRoutes.DebitAccounts.CreateDebitAccount)]
        public async Task<IActionResult> CreateDebitAccount([FromBody] CreateDebitAccountReqDTO request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _debitAccountService.CreateDebitAccountAsync(request, cancellationToken);

            if (response.ErrorMessage is null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.DebitAccounts.GetDebitAccountByID.Replace("{Id}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.DebitAccounts.GetAllDebitAccounts)]
        public async Task<IActionResult> GetAllDebitAccounts(CancellationToken cancellationToken)
        {
            var debitAccounts = await _debitAccountService.GetAllDebitAccountsAsync(cancellationToken);

            if (debitAccounts.ErrorMessage is not null)
            {
                return StatusCode(debitAccounts.ErrorMessage.StatusCode, debitAccounts.ErrorMessage);
            }

            return Ok(debitAccounts);
        }

        [HttpGet(ApiRoutes.DebitAccounts.GetDebitAccountByID)]
        public async Task<IActionResult> GetDebitAccountById([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var debitAccountResponse = await _debitAccountService.GetDebitAccountByIdAsync(Id, cancellationToken);

            if (debitAccountResponse.ErrorMessage is null)
            {
                return Ok(debitAccountResponse);
            }

            return StatusCode(debitAccountResponse.ErrorMessage.StatusCode, debitAccountResponse.ErrorMessage);
        }

        [HttpPut(ApiRoutes.DebitAccounts.UpdateDebitAccount)]
        public async Task<IActionResult> UpdateDebitAccount([FromBody] UpdateDebitAccountReqDTO request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _debitAccountService.UpdateDebitAccountAsync(request, cancellationToken);

            if (updated.ErrorMessage is null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpPatch(ApiRoutes.DebitAccounts.UpdatePatchDebitAccount)]
        public async Task<IActionResult> UpdatePatchDebitAccount([FromRoute] Guid Id, [FromBody] JsonPatchDocument<DebitAccount> patchDocument, CancellationToken cancellationToken)
        {
            var updatedDebitAccount = await _debitAccountService.UpdateDebitAccountPatchAsync(Id, patchDocument, cancellationToken);

            if (updatedDebitAccount is null)
            {
                return NotFound();
            }

            return Ok(updatedDebitAccount);
        }

        [HttpDelete(ApiRoutes.DebitAccounts.DeleteDebitAccount)]
        public async Task<IActionResult> DeleteDebitAccount([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var deleted = await _debitAccountService.DeleteDebitAccountAsync(Id, cancellationToken);

            if (deleted.Deleted)
            {
                return NoContent();
            }

            return StatusCode(deleted.Error.StatusCode, deleted.Error);
        }
    }
}
