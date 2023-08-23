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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(StudentCreateDto studentCreateDto)
        {
            if (studentCreateDto == null)
            {
                throw new InvalidOperationException("Student not found");
            }

            var student = _mapper.Map<Student>(studentCreateDto);

            await _unitOfWork.Students.AddAsync(student);

            var created = await _unitOfWork.Students.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);

            if (student == null)
            {
                throw new InvalidOperationException("Student not found");
            }

            _unitOfWork.Students.RemoveById(id);

            var deleted = await _unitOfWork.Students.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<List<StudentGetDto>> GetAllAsync()
        {
            var studentsUowQuery = await _unitOfWork.Students.GetAll();

            if (!studentsUowQuery.Any() || studentsUowQuery == null)
            {
                throw new InvalidOperationException("Groups not found");
            }

            var students = studentsUowQuery.OrderBy(x => x.LastName).ToList();

            var response = _mapper.Map<List<StudentGetDto>>(students);

            return response;
        }

        public async Task<StudentGetDto> GetByIdAsync(int id)
        {
            var studentQuery = await _unitOfWork.Students
                .FindByCondition(x => x.Id.Equals(id));

            if (studentQuery == null || !studentQuery.Any())
            {
                throw new InvalidOperationException("Student not found");
            }

            var student = await studentQuery.SingleOrDefaultAsync();

            var response = _mapper.Map<StudentGetDto>(student);

            return response;
        }

        public async Task<IEnumerable<StudentGetDto>> GetAllByGroupId(int groupId)
        {
            var studentsQuery = await _unitOfWork.Students
                .FindByCondition(x => x.GroupId == groupId);

            if (studentsQuery == null || !studentsQuery.Any())
            {
                throw new InvalidOperationException("Students not found");
            }

            var students = await studentsQuery.Include(s => s.Group)
                        .OrderBy(x => x.LastName)
                            .ToListAsync();

            var response = _mapper.Map<IEnumerable<StudentGetDto>>(students);

            return response;
        }

        public async Task<bool> UpdateAsync(StudentUpdateDto studentUpdateDto)
        {
            if (studentUpdateDto == null)
            {
                return false;
            }

            var student = _mapper.Map<Student>(studentUpdateDto);

            _unitOfWork.Students.Update(student);

            var updated = await _unitOfWork.Students.SaveChangesAsyncWithResult();

            return updated > 0;
        }
    }
}
