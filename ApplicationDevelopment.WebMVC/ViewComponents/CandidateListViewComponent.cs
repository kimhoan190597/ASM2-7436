using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.ViewComponents
{
    public class CandidateListViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        public CandidateListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var candidates = await _context.Candidates
                .OrderBy(c => c.Position)
                .Select(c => new CandidateViewModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Name = c.Name,
                    Position = c.Position,
                    Phone = c.Phone,
                    Email = c.Email,
                    Occupation = c.Occupation,
                    Gender = c.Gender,
                    DateOfBirth = c.DateOfBirth,
                })
                .ToListAsync();
            return View(candidates);
        }
    }
}
