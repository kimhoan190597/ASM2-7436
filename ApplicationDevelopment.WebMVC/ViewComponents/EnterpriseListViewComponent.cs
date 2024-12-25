using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.ViewComponents
{
    public class EnterpriseListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public EnterpriseListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var enterprises = await _context.Enterprises
                .OrderBy(c => c.Position)
                .Select(c => new EnterpriseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Position = c.Position,
                    Hotline = c.Hotline,
                    Email = c.Email,
                    Address = c.Address,
                    TaxNumber = c.TaxNumber,
                    
                })
                .ToListAsync();
            return View(enterprises);
        }
    }
}
