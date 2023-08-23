using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.Service_interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Task9.Controllers
{
    [Route("[controller]/[action]")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var groups = await _groupService.GetAllAsync();

            if (groups == null)
            {
                return NotFound();
            }

            return View(groups);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupsByCourseId(int courseId)
        {
            var groups = await _groupService.GetAllByCourseId(courseId);

            if (groups == null)
            {
                return NotFound();
            }

            return View(groups);
        }

        [HttpGet]
        public async Task<IActionResult> EditGroup(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            var groupUpdateDTORequest = _mapper.Map<GroupUpdateDto>(group);

            return PartialView("_EditGroup", groupUpdateDTORequest);
        }

        [HttpPost]
        public async Task<IActionResult> EditGroup(GroupUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _groupService.UpdateAsync(model);

            if (!updated)
            {
                return BadRequest("Something went wrong during updating group!");
            }

            return RedirectToAction("GetGroupsByCourseId", "Group", new { model.CourseId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            var groupUpdateDtoRequest = _mapper.Map<GroupUpdateDto>(group);

            ViewBag.EntityName = $"{typeof(GroupController).Name.Replace("Controller", "")}";

            return PartialView("_DeleteGroup", groupUpdateDtoRequest);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup(GroupUpdateDto model)
        {
            var deleted = await _groupService.DeleteAsync(model.Id);

            ViewBag.EntityName = $"{typeof(GroupController).Name.Replace("Controller", "")}";

            if (!deleted)
            {
                return PartialView("_ErrorDelete");
            }

            return RedirectToAction("GetGroupsByCourseId", "Group", new { model.CourseId });
        }
    }
}
