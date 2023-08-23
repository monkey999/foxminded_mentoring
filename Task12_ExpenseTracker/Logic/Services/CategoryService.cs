using AutoMapper;
using Domain.Models;
using Domain.RepoInterfaces;
using Domain.ValueObjects;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Logic.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateCategoryAsync(CreateCategoryReqDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _unitOfWork.Categories.AddAsync(category);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CreateCategoryRespDTO> CreateCategoryWithResultAsync(CreateCategoryReqDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _unitOfWork.Categories.AddAsync(category);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            if (created > 0)
            {
                var response = _mapper.Map<CreateCategoryRespDTO>(category);

                return response;
            }

            return new CreateCategoryRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while creating category."
                }
            };
        }

        public async Task<bool> DeleteCategoryAsync(Guid categoryId)
        {
            var category = await GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return false;
            }

            _unitOfWork.Categories.RemoveById(categoryId);

            var deleted = await _unitOfWork.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<GetCategoryRespDto> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAll().OrderBy(x => x.Id).ToListAsync();

            if (categories != null)
            {
                var response = new GetCategoryRespDto
                {
                    Categories = _mapper.Map<IEnumerable<GetCategoryRespDto.CategoryRespDto>>(categories)
                };

                return response;
            }

            return new GetCategoryRespDto
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "Category not found."
                }
            };
        }

        public async Task<GetCategoryRespDto> GetCategoryByIdAsync(Guid categoryId)
        {
            var category = await _unitOfWork.Categories.FindByCondition(x => x.Id.Equals(categoryId))
                .SingleOrDefaultAsync();

            var response = new GetCategoryRespDto();

            if (category != null)
            {
                var categoryDto = _mapper.Map<GetCategoryRespDto.CategoryRespDto>(category);
                response.Categories = new List<GetCategoryRespDto.CategoryRespDto> { categoryDto };
            }
            else
            {
                response.ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404, 
                    Message = "Category not found."
                };
            }

            return response;
        }

        public async Task<UpdateCategoryRespDTO> UpdateCategoryAsync(UpdateCategoryReqDTO categoryDto)
        {
            var categoryToUpdate = _mapper.Map<Category>(categoryDto);

            _unitOfWork.Categories.Update(categoryToUpdate);

            var updated = await _unitOfWork.SaveChangesAsyncWithResult();

            if (updated > 0)
            {
                var updatedCategory = _unitOfWork.Categories.FindByCondition(x => x.Id == categoryDto.Id).SingleOrDefault();

                var response = _mapper.Map<UpdateCategoryRespDTO>(updatedCategory);

                return response;
            }

            return new UpdateCategoryRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while updating category. Probably you haven't provided category ID!"
                }
            };
        }
    }
}
