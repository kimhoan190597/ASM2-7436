using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Enums;
using ApplicationDevelopment.WebMVC.Helpers;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace ApplicationDevelopment.WebMVC.Controllers
{
    public class UserController : Controller
    {
        //private readonly DataService _serviceData;
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (user == null) return BadRequest();
            try
            {
                if (!string.IsNullOrEmpty(user.FullName))
                {
                    //var listUser = _serviceData.GetUsers();
                    //listUser.Add(user);
                    user.FullName = user.FullName.Trim();
                    user.Name = user.GetNameFromFullname(user.FullName);

                    var count = await _context.Users.CountAsync();
                    user.Position = ++count;

                    await _context.Users.AddAsync(user);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Create");
                }

                //=== Trả dữ liệu User về lại View cho người dùng xem lại ===//
                ViewBag.Occupations = DataHelper.GetOccupationSelectList();
                //return View("Create", user);
            }
            catch { }
            
            return View(user);
        }

        public async Task<IActionResult> Edit(Guid idUser)
        {
            //var listUser = _serviceData.GetUsers();
            //var user = listUser
            //    .Where(u => u.Id == idUser)
            //    .SingleOrDefault();
            var user = await _context.Users
                .Where(u => u.Id == idUser)
                .SingleOrDefaultAsync();

            ViewBag.Occupations = DataHelper.GetOccupationSelectList();

            return View(nameof(Create), user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if(user != null && !string.IsNullOrEmpty(user.FullName))
            {
                //var listUser = _serviceData.GetUsers();
                //var userInList = listUser
                //    .Where(u => u.Id == user.Id)
                //    .SingleOrDefault();
                var userInList = _context.Users
                   .Where(u => u.Id == user.Id)
                   .SingleOrDefault();
                if (userInList != null)
                {
                    userInList.FullName = user.FullName;
                    userInList.Phone = user.Phone;
                    userInList.Email = user.Email;
                    userInList.Gender = user.Gender;
                    userInList.DateOfBirth = user.DateOfBirth;
                    userInList.Occupation = user.Occupation;

                    return RedirectToAction(nameof(Create));
                } else
                {
                    return BadRequest();
                }
            }

            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View(nameof(Create), user);
        }

        //private SelectList GetOccupationSelectList()
        //{
        //    var occupations = from OccupationEnum job in Enum.GetValues(typeof(OccupationEnum))
        //                      select new
        //                      {
        //                          Id = job,
        //                          Name = job.ToString()
        //                      };
        //    return new SelectList(occupations, "Id", "Name", 4);
        //}
    }
}
