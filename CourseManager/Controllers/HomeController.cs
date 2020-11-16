using CourseManager.Models;
using CourseManager.Models.Courses;
using CourseManager.Models.Interfaces;
using CourseManager.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly UserManager<UserModel> userManager;

        public HomeController(ICourseRepository courseRepository, UserManager<UserModel> userManager)
        {
            this.courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository)); 
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager)); 
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new CourseViewModel();

            model.Courses = courseRepository.GetAllCourses().ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateCourse()
        {
            return View(new CourseViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var currentUser = await userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                courseRepository.CreateCourse(new CourseModel()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    TimeStart = model.TimeStart,
                    TimeEnd = model.TimeEnd,
                    DateStart = model.DateStart,
                    User = currentUser
                });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UpdateCourse(int courseId)
        {
            if (courseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(courseId));
            }

            CourseModel course = courseRepository.GetCourse(courseId);
            var model = new CourseViewModel()
            {
                CourseID = course.CourseID,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                TimeStart = course.TimeStart,
                TimeEnd = course.TimeEnd,
                DateStart = course.DateStart
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCourse(CourseViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                var course = new CourseModel()
                {
                    CourseID = model.CourseID,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    TimeStart = model.TimeStart,
                    TimeEnd = model.TimeEnd,
                    DateStart = model.DateStart
                };

                courseRepository.Update(course);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteCourse(int courseId)
        {
            if (courseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(courseId));
            }

            courseRepository.Delete(courseId);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}