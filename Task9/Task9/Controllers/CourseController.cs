using C_Logic.Service_interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Task9.Controllers
{
    [Route("[controller]/[action]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var courses = await _courseService.GetAllAsync();

            if (!courses.Any())
            {
                return NotFound();
            }

            return View(courses);
        }
    }
}
