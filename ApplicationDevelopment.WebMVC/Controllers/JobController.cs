using ApplicationDevelopment.WebMVC.Commons;
using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Models;
using ApplicationDevelopment.WebMVC.Validators;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;
        public JobController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.JobTypes = await GetJobTypeSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobViewModel jobVM)
        {
            var validator = new JobValidator();
            try
            {
                var result = await validator.ValidateAsync(jobVM);
                if (result.IsValid)
                {
                    var countJob = await _context.Jobs.CountAsync();
                    var newJob = new Job
                    {
                        Name = jobVM.Name.Trim(),
                        Description = jobVM.Description.Trim(),
                        Requirements = jobVM.Requirements?.Trim(),
                        JobTypeId = jobVM.JobTypeId,
                        Postion = countJob + 1,
                    };
                    _context.Jobs.Add(newJob);
                    await _context.SaveChangesAsync();
                    //ViewBag.Announcement = "Tạo thành công";
                    ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thành công";
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                ViewBag.JobTypes = await GetJobTypeSelectList();

                //ViewBag.Announcement = "Tạo thất bại";
                ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thất bại";
            }

            return View(jobVM);
        }

        public async Task<IActionResult> Edit(Guid idJob)
        {
            var jobVM = await _context.Jobs
                .Where(j => j.Id.Equals(idJob))
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description,
                    Requirements = j.Requirements,
                    JobTypeId = j.JobTypeId,
                })
                .SingleOrDefaultAsync();
            
            ViewBag.JobTypes = await GetJobTypeSelectList();

            return View(nameof(Create), jobVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobViewModel jobVM)
        {
            var validator = new JobValidator();
            try
            {
                var result = await validator.ValidateAsync(jobVM);
                if (result.IsValid)
                {
                    var job = await _context.Jobs
                        .Where(j => j.Id.Equals(jobVM.Id))
                        .SingleOrDefaultAsync();

                    if(job != null)
                    {
                        job.Name = jobVM.Name.Trim();
                        job.Description = jobVM.Description.Trim();
                        job.Requirements = jobVM.Requirements?.Trim();
                        job.JobTypeId = jobVM.JobTypeId;

                        await _context.SaveChangesAsync();
                        //ViewBag.Announcement = "Tạo thành công";
                        ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thành công";
                        return RedirectToAction("Create");
                    }
                }
            }
            catch
            {
                ViewBag.JobTypes = await GetJobTypeSelectList();

                //ViewBag.Announcement = "Tạo thất bại";
                ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thất bại";
            }

            return View(nameof(Create), jobVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid idJob)
        {
            var statusCode = false;
            var message = "Chưa thực thi";
            try
            {
                var job = await _context.Jobs
                        .Where(j => j.Id.Equals(idJob))
                        .SingleOrDefaultAsync();

                if (job != null)
                {
                    _context.Jobs.Remove(job);

                    await _context.SaveChangesAsync();
                    statusCode = true;
                    message = "Xóa thành công";
                }
            }
            catch
            {
                message = "Lỗi thực thi";
            }

            return Json(new { message, statusCode});
        }

        public IActionResult GetAll()
        {
            return ViewComponent("JobList");
        }

        private async Task<SelectList> GetJobTypeSelectList()
        {
            var listJob = await _context.JobTypes
                .OrderBy(jt => jt.Position)
                .Select(jt => new Item
                {
                    Id = jt.Id,
                    Name = jt.Name,
                })
                .ToListAsync();
            listJob.Insert(0, new Item
            {
                Id = Guid.Empty,
                Name = "=== Chọn Job Type ==="
            });
            var selectList = new SelectList(listJob, "Id", "Name");
            return selectList;
        }
    }
}
