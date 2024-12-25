using ApplicationDevelopment.WebMVC.Commons;
using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Models;
using ApplicationDevelopment.WebMVC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.Controllers
{
    public class JobTypeController : Controller
    {
        private readonly AppDbContext _context;
        public JobTypeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobTypeViewModel jobTypeVM)
        {
            var statusCode = new StatusCode
            {
                Message = "Chưa thực thi",
                Code = 0,
            };
            try
            {
                var validator = new JobTypeValidator();
                var result = validator.Validate(jobTypeVM);
                if (result.IsValid)
                {
                    var countJobType = await _context.JobTypes.CountAsync();
                    var newJobType = new JobType
                    {
                        Name = jobTypeVM.Name.Trim(),
                        Description = jobTypeVM.Description?.Trim(),
                        Position = ++countJobType
                    };
                    _context.JobTypes.Add(newJobType);
                    await _context.SaveChangesAsync();
                    statusCode.Code = 1;
                    statusCode.Message = "Tạo thành công";
                }
            }
            catch
            {
                statusCode.Code = -1;
                statusCode.Message = "Tạo thất bại";
            }
            
            return Json(statusCode);
        }
    }
}
