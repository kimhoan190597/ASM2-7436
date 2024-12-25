using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Helpers;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.Controllers
{
    public class EnterpriseController : Controller
    {
        private readonly AppDbContext _context;

        public EnterpriseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnterpriseViewModel enterpriseVM)
        {
            try
            {
                var countEnterprise = await _context.Enterprises.CountAsync();
                var newEnterprise = new Enterprise
                {
                    Name = enterpriseVM.Name,
                    Address = enterpriseVM.Address,
                    Email = enterpriseVM.Email,
                    Hotline = enterpriseVM.Hotline,
                    TaxNumber = enterpriseVM.TaxNumber,
                    Position = countEnterprise + 1,
                };
                _context.Enterprises.Add(newEnterprise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            catch
            {

            }
            
            return View(enterpriseVM);
        }

        public async Task<IActionResult> Edit(Guid idEnterprise)
        {
            var enterpriseVM = await _context.Enterprises
                .Where(c => c.Id.Equals(idEnterprise))
                .Select(c => new EnterpriseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Position = c.Position,
                    Hotline = c.Hotline,
                    Email = c.Email,
                    TaxNumber= c.TaxNumber,
                    Address = c.Address,
                    
                })
                .SingleOrDefaultAsync();
            return View(nameof(Create), enterpriseVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EnterpriseViewModel enterpriseVM)
        {
            try
            {
                var enterprise = await _context.Enterprises
                    .FindAsync(enterpriseVM.Id);
                if (enterprise != null)
                {
                    enterprise.Name = enterpriseVM.Name;
                    enterprise.TaxNumber = enterpriseVM.TaxNumber;
                    enterprise.Address = enterpriseVM.Address;
                    enterprise.Email = enterpriseVM.Email;
                    enterprise.Hotline = enterpriseVM.Hotline;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
            }
            return View(nameof(Create), enterpriseVM);
        }
    }
}
