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
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(GroupCreateDto groupCreateDto)
        {
            if (groupCreateDto == null)
            {
                throw new InvalidOperationException("Group wasn't provided!");
            }

            var group = _mapper.Map<Group>(groupCreateDto);

            await _unitOfWork.Groups.AddAsync(group);

            var created = await _unitOfWork.Groups.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var group = await GetByIdAsync(id);

            if (group == null)
            {
                throw new InvalidOperationException("Group not found");
            }

            var studentsInGroupQuery = await _unitOfWork.Students.FindByCondition(x => x.GroupId == id);

            var ifAnyStudInGroupFlag = studentsInGroupQuery.Any();

            if (ifAnyStudInGroupFlag)
            {
                return false;
            }

            _unitOfWork.Groups.RemoveById(id);

            var deleted = await _unitOfWork.Groups.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<List<GroupGetDto>> GetAllAsync()
        {
            var groupsUowQuery = await _unitOfWork.Groups.GetAll();

            if (!groupsUowQuery.Any() || groupsUowQuery == null)
            {
                throw new InvalidOperationException("Groups not found");
            }

            var groups = groupsUowQuery.OrderBy(x => x.Name).ToList();

            var response = _mapper.Map<List<GroupGetDto>>(groups);

            return response;
        }

        public async Task<GroupGetDto> GetByIdAsync(int id)
        {
            var groupQuery = await _unitOfWork.Groups
                .FindByCondition(x => x.Id.Equals(id));

            if (!groupQuery.Any() || groupQuery == null)
            {
                throw new InvalidOperationException("Group not found");
            }

            var group = groupQuery.SingleOrDefault();

            var response = _mapper.Map<GroupGetDto>(group);

            return response;
        }

        public async Task<IEnumerable<GroupGetDto>> GetAllByCourseId(int courseId)
        {
            var groupsQuery = await _unitOfWork.Groups
                .FindByCondition(x => x.CourseId == courseId);

            if (!groupsQuery.Any() || groupsQuery == null)
            {
                throw new InvalidOperationException("Groups not found");
            }

            var groups = await groupsQuery.OrderBy(x => x.Name)
                        .ToListAsync();

            var response = _mapper.Map<IEnumerable<GroupGetDto>>(groups);

            return response;
        }

        public async Task<bool> UpdateAsync(GroupUpdateDto groupUpdateDto)
        {
            if (groupUpdateDto == null)
            {
                return false;
            }

            var group = _mapper.Map<Group>(groupUpdateDto);

            _unitOfWork.Groups.Update(group);

            var updated = await _unitOfWork.Groups.SaveChangesAsyncWithResult();

            return updated > 0;
        }
    }
}
