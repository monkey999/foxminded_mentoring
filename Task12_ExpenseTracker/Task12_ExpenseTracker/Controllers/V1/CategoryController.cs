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
    [CategoryControllerExceptionFilterAttribute]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(ApiRoutes.Categories.CreateCategory)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryReqDTO request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.CreateCategoryAsync(request, cancellationToken);

            if (response.ErrorMessage is null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.Categories.GetCategoryByID.Replace("{Id}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.Categories.GetAllCategories)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);

            if (categories.ErrorMessage is not null)
            {
                return StatusCode(categories.ErrorMessage.StatusCode, categories.ErrorMessage);
            }

            return Ok(categories);
        }

        [HttpGet(ApiRoutes.Categories.GetCategoryByID)]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var categoryResponse = await _categoryService.GetCategoryByIdAsync(Id, cancellationToken);

            if (categoryResponse.ErrorMessage is null)
            {
                return Ok(categoryResponse);
            }

            return StatusCode(categoryResponse.ErrorMessage.StatusCode, categoryResponse.ErrorMessage);
        }

        [HttpPut(ApiRoutes.Categories.UpdateCategory)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryReqDTO request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _categoryService.UpdateCategoryAsync(request, cancellationToken);

            if (updated.ErrorMessage is null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpPatch(ApiRoutes.Categories.UpdatePatchCategory)]
        public async Task<IActionResult> UpdatePatchCategory([FromRoute] Guid Id, [FromBody] JsonPatchDocument<Category> patchDocument, CancellationToken cancellationToken)
        {
            var updatedCategory = await _categoryService.UpdateCategoryPatchAsync(Id, patchDocument, cancellationToken);

            if (updatedCategory.ErrorMessage is not null)
            {
                return NotFound();
            }

            return Ok(updatedCategory);
        }

        [HttpDelete(ApiRoutes.Categories.DeleteCategory)]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(Id, cancellationToken);

            if (deleted.Deleted)
            {
                return NoContent();
            }

            return StatusCode(deleted.Error.StatusCode, deleted.Error);
        }
    }
}
