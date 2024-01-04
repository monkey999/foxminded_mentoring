using AutoMapper;
using C_Logic.DTO_Contracts.Requests.Update;
using C_Logic.Service_interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Task9.Controllers
{
    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var students = await _studentService.GetAllAsync();

            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsByGroupId(int groupId)
        {
            var students = await _studentService.GetAllByGroupId(groupId);

            if (!students.Any())
            {
                return NotFound();
            }

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentUpdateDTORequest = _mapper.Map<StudentUpdateDto>(student);

            return PartialView("_EditStudent", studentUpdateDTORequest);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated =  await _studentService.UpdateAsync(model);

            if (!updated)
            {
                return BadRequest("Something went wrong during updating student!");
            }

            return RedirectToAction("GetStudentsByGroupId", "Student", new { model.GroupId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentUpdateDto = _mapper.Map<StudentUpdateDto>(student);

            ViewBag.EntityName = $"{typeof(StudentController).Name.Replace("Controller", "")}";

            return PartialView("_DeleteStudent", studentUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(StudentUpdateDto model)
        {
            var deleted = await _studentService.DeleteAsync(model.Id);

            ViewBag.EntityName = $"{typeof(StudentController).Name.Replace("Controller", "")}";

            if (!deleted)
            {
                return PartialView("_ErrorDelete");
            }

            return RedirectToAction("GetStudentsByGroupId", "Student", new { model.GroupId });
        }
    }
}
