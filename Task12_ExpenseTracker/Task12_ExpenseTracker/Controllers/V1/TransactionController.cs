using Domain.Models;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Task12_ExpenseTracker.ExceptionFilters;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    [TransactionControllerExceptionFilterAttribute]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost(ApiRoutes.Transactions.CreateTransaction)]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionReqDTO request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _transactionService.CreateTransactionAsync(request, cancellationToken);

            if (response.ErrorMessage is null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.Transactions.GetTransactionByID.Replace("{Id}", response.TransactionDto.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.Transactions.GetAllTransactions)]
        public async Task<IActionResult> GetAllTransactions(CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetAllTransactionsAsync(cancellationToken);

            if (transactions.ErrorMessage is not null)
            {
                return StatusCode(transactions.ErrorMessage.StatusCode, transactions.ErrorMessage);
            }

            return Ok(transactions);
        }

        [HttpGet(ApiRoutes.Transactions.GetTransactionByID)]
        public async Task<IActionResult> GetTransactionById([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var transactionResponse = await _transactionService.GetTransactionByIdAsync(Id, cancellationToken);

            if (transactionResponse.ErrorMessage is null)
            {
                return Ok(transactionResponse);
            }

            return StatusCode(transactionResponse.ErrorMessage.StatusCode, transactionResponse.ErrorMessage);
        }

        [HttpPut(ApiRoutes.Transactions.UpdateTransaction)]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionReqDTO request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _transactionService.UpdateTransactionAsync(request, cancellationToken);

            if (updated.ErrorMessage is null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpPatch(ApiRoutes.Transactions.UpdatePatchTransaction)]
        public async Task<IActionResult> UpdatePatchTransaction([FromRoute] Guid Id, [FromBody] JsonPatchDocument<Transaction> patchDocument, CancellationToken cancellationToken)
        {
            var updatedTransaction = await _transactionService.UpdateTransactionPatchAsync(Id, patchDocument, cancellationToken);

            if (updatedTransaction is null)
            {
                return NotFound();
            }

            return Ok(updatedTransaction);
        }

        [HttpDelete(ApiRoutes.Transactions.DeleteTransaction)]
        public async Task<IActionResult> DeleteTransaction([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var deleted = await _transactionService.DeleteTransactionAsync(Id, cancellationToken);

            if (deleted.Deleted)
            {
                return NoContent();
            }

            return StatusCode(deleted.Error.StatusCode, deleted.Error);
        }
    }
}
