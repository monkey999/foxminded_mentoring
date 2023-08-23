using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Task12_ExpenseTracker.Controllers.V1
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(ApiRoutes.Categories.CreateCategory)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryReqDTO request)
        {
            var response = await _categoryService.CreateCategoryWithResultAsync(request);

            if (response.ErrorMessage == null)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                var locationUri = baseUrl + "/" + ApiRoutes.Categories.GetCategoryByID.Replace("{categoryId}", response.Id.ToString());

                return Created(locationUri, response);
            }

            return StatusCode(response.ErrorMessage.StatusCode, response.ErrorMessage);
        }

        [HttpGet(ApiRoutes.Categories.GetAllCategories)]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpGet(ApiRoutes.Categories.GetCategoryByID)]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid Id)
        {
            var categoryResponse = await _categoryService.GetCategoryByIdAsync(Id);

            if (categoryResponse != null && categoryResponse.Categories.Any())
            {
                return Ok(categoryResponse);
            }
            else if (categoryResponse.ErrorMessage != null)
            {
                return StatusCode(categoryResponse.ErrorMessage.StatusCode, categoryResponse.ErrorMessage);
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.Categories.UpdateCategory)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryReqDTO request)
        {
            //TODO: add modelstate check: user must provide id or its not update 

            var updated = await _categoryService.UpdateCategoryAsync(request);

            if (updated.ErrorMessage == null)
            {
                return Ok(updated);
            }

            return StatusCode(updated.ErrorMessage.StatusCode, updated.ErrorMessage);
        }

        [HttpDelete(ApiRoutes.Categories.DeleteCategory)]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid Id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(Id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
