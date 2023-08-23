using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost(ApiRoutes.Transactions.CreateTransaction)]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionReqDTO request)
        {
            var response = await _transactionService.CreateTransactionWithResultAsync(request);

            if (response.ErrorMessage == null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.Transactions.GetTransactionByID.Replace("{transactionId}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.Transactions.GetAllTransactions)]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();

            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        [HttpGet(ApiRoutes.Transactions.GetTransactionByID)]
        public async Task<IActionResult> GetTransactionById([FromRoute] Guid Id)
        {
            var transactionResponse = await _transactionService.GetTransactionByIdAsync(Id);

            if (transactionResponse != null && transactionResponse.TransactionsRespDto.Any())
            {
                return Ok(transactionResponse);
            }
            else if (transactionResponse.ErrorMessage != null)
            {
                return StatusCode(transactionResponse.ErrorMessage.StatusCode, transactionResponse.ErrorMessage);
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.Transactions.UpdateTransaction)]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionReqDTO request)
        {
            //TODO: add modelstate check: user must provide id or its not update 

            var updated = await _transactionService.UpdateTransactionAsync(request);

            if (updated.ErrorMessage == null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpDelete(ApiRoutes.Transactions.DeleteTransaction)]
        public async Task<IActionResult> DeleteTransaction([FromRoute] Guid Id)
        {
            var deleted = await _transactionService.DeleteTransactionAsync(Id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
