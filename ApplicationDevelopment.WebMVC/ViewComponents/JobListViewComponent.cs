using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.ViewComponents
{
    public class JobListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public JobListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool isForHome = false)
        {
            //var items = await GetItemsAsync();
            var items = await _context!.Jobs!
                //.Where()
                .Include(j => j.JobType)
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description,
                    JobType = j.JobType.Name,
                    //JobTypeId = j.JobTypeId,
                    Requirements = j.Requirements
                })
                .ToListAsync();
            if (isForHome)
            {
                return View("HomeViewJobList", items);
            }
            return View(items);

        }

        private Task<List<JobViewModel>> GetItemsAsync()
        {
            return _context!.Jobs!
                //.Where()
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description,
                    JobTypeId = j.JobTypeId,
                    Requirements = j.Requirements
                })
                .ToListAsync();
        }
    }
}
