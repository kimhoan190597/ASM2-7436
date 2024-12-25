using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.ViewComponents
{
    public class JobTypeListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public JobTypeListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context!.JobTypes!
                .Select(j => new JobTypeViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Position = j.Position,
                    Description = j.Description,
                })
                .ToListAsync();
            return View(items);
        }

    }
}
