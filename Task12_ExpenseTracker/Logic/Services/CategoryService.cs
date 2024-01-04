using AutoMapper;
using DataAccess.Specifications.CategorySpecs;
using Domain.Models;
using Domain.RepoInterfaces;
using Domain.ValueObjects;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Delete;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.IdentityModel.Tokens;
using System.Transactions;

namespace Logic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWOrk _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(IUnitOfWOrk unitOfWork, IMapper mapper, ICategoryRepo categoryRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<CreateCategoryRespDTO> CreateCategoryAsync(CreateCategoryReqDTO categoryDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var category = _mapper.Map<Category>(categoryDto);

                await _categoryRepo.AddAsync(category, cancellationToken);

                var response = _mapper.Map<CreateCategoryRespDTO>(category);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new CreateCategoryRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Category wasn't created!"
                        }
                    };
                }

                scope.Complete();

                return response;
            }
        }

        public async Task<DeleteCategoryRespDTO> DeleteCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _categoryRepo
                    .FindByConditionAsync(cancellationToken, new CategoryGetByIdAsNoTrackingSpecification(x => x.Id == categoryId)))
                        .IsNullOrEmpty())
                {
                    return new DeleteCategoryRespDTO
                    {
                        Deleted = false,
                        Error = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Such category doesn't exist!"
                        }
                    };
                }

                _categoryRepo.RemoveById(categoryId);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new DeleteCategoryRespDTO
                    {
                        Deleted = false,
                        Error = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while deleting category!"
                        }
                    };
                }

                scope.Complete();

                var response = new DeleteCategoryRespDTO { Deleted = true };

                return response;
            }
        }

        public async Task<GetCategoryRespDto> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            if ((await _categoryRepo.FindByConditionAsync(cancellationToken, new CategoryGetAllSpecification()))
                    .IsNullOrEmpty())
            {
                return new GetCategoryRespDto
                {
                    ErrorMessage = new ErrorMessage
                    {
                        StatusCode = 404,
                        Message = $"No categories were found!"
                    }
                };
            }

            var allCategories = await _categoryRepo.FindByConditionAsync(cancellationToken, new CategoryGetAllSpecification());

            var response = new GetCategoryRespDto
            {
                Categories = _mapper.Map<IEnumerable<CategoryRespDto>>(allCategories)
            };

            return response;
        }

        public virtual async Task<GetCategoryRespDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            if ((await _categoryRepo.FindByConditionAsync(cancellationToken, new CategoryGetByIdAsNoTrackingSpecification(c => c.Id == categoryId))).IsNullOrEmpty())
            {
                return new GetCategoryRespDto
                {
                    ErrorMessage = new ErrorMessage
                    {
                        StatusCode = 404,
                        Message = "Category not found."
                    }
                };
            }

            var categoryByIdDto = await _categoryRepo
                .FindByConditionAsync(cancellationToken, new CategoryGetByIdSpecification(c => c.Id == categoryId));

            var mappedCategoryDto = _mapper.Map<CategoryRespDto>(categoryByIdDto);

            return new GetCategoryRespDto
            {
                Categories = new List<CategoryRespDto> { mappedCategoryDto }
            };
        }

        public async Task<UpdateCategoryRespDTO> UpdateCategoryAsync(UpdateCategoryReqDTO categoryDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _categoryRepo
                    .FindByConditionAsync(cancellationToken, new CategoryGetByIdAsNoTrackingSpecification(x => x.Id == categoryDto.Id)))
                        .IsNullOrEmpty())
                {
                    return new UpdateCategoryRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 404,
                            Message = "Category not found."
                        }
                    };
                }

                var categoryToUpdate = ((await _categoryRepo
                    .FindByConditionAsync(cancellationToken, new CategoryGetByIdSpecification(x => x.Id == categoryDto.Id))))
                    .FirstOrDefault();

                var mappedCategoryToUpdateDto = _mapper.Map(categoryDto, categoryToUpdate);

                _categoryRepo.Update(mappedCategoryToUpdateDto);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new UpdateCategoryRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while updating category!"
                        }
                    };
                }

                var response = _mapper.Map<UpdateCategoryRespDTO>(categoryToUpdate);

                scope.Complete();

                return response;
            }
        }

        public async Task<UpdateCategoryPatchRespDto> UpdateCategoryPatchAsync(Guid Id, JsonPatchDocument<Category> patchDocument, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _categoryRepo
                     .FindByConditionAsync(cancellationToken, new CategoryGetByIdAsNoTrackingSpecification(x => x.Id == Id)))
                         .IsNullOrEmpty())
                {
                    return new UpdateCategoryPatchRespDto
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 404,
                            Message = "Category not found."
                        }
                    };
                }

                var categoryToUpdate = (await _categoryRepo
                    .FindByConditionAsync(cancellationToken, new CategoryGetByIdSpecification(x => x.Id == Id)))
                    .FirstOrDefault();

                patchDocument.ApplyTo(categoryToUpdate);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new UpdateCategoryPatchRespDto
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while patch updating category!"
                        }
                    };
                }

                var response = _mapper.Map<UpdateCategoryPatchRespDto>(categoryToUpdate);

                scope.Complete();

                return response;
            }
        }
    }
}

