using A_Domain.Repo_interfaces;
using AutoMapper;
using C_Logic.DTO_Contracts.Requests;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.DTO_Contracts.Responses;
using C_Logic.Service_interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CourseCreateDto courseCreateDto)
        {
            if (courseCreateDto == null)
            {
                throw new InvalidOperationException("Course wasn't provided!");
            }

            var course = _mapper.Map<Course>(courseCreateDto);
           
            await _unitOfWork.Courses.AddAsync(course);

            var created = await _unitOfWork.Courses.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id);

            if (course == null)
            {
                throw new InvalidOperationException("Course not found");
            }

            _unitOfWork.Courses.RemoveById(id);

            var deleted = await _unitOfWork.Courses.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<List<CourseGetDto>> GetAllAsync()
        {
            var coursesUowQuery = await _unitOfWork.Courses.GetAll();

            var courses = coursesUowQuery.OrderBy(x => x.Name).ToList();

            if (!courses.Any())
            {
                throw new InvalidOperationException("Courses not found");
            }

            var response = _mapper.Map<List<CourseGetDto>>(courses);

            return response;
        }

        public async Task<CourseGetDto> GetByIdAsync(int id)
        {
            var courseQuery = await _unitOfWork.Courses
                    .FindByCondition(x => x.Id.Equals(id));
                        
            if (courseQuery == null || !courseQuery.Any())
            {
                throw new InvalidOperationException("Course not found");
            }

            var course = await courseQuery.SingleOrDefaultAsync();

            var response = _mapper.Map<CourseGetDto>(course);

            return response;
        }

        public async Task<bool> UpdateAsync(CourseUpdateDTO courseUpdateDto)
        {
            if (courseUpdateDto == null)
            {
                throw new InvalidOperationException("Course wasn't provided!");
            }

            var course = _mapper.Map<Course>(courseUpdateDto);

            _unitOfWork.Courses.Update(course);

            var updated = await _unitOfWork.Courses.SaveChangesAsyncWithResult();

            return updated > 0;
        }
    }
}
