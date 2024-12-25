using ApplicationDevelopment.WebMVC.Data;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Helpers;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.WebMVC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly AppDbContext _context;
        public CandidateController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateViewModel candidate)
        {
            try
            {
                var countCandidate = await _context.Candidates.CountAsync();
                
                var newCandidate = new Candidate
                {
                    Position = ++countCandidate,
                    FullName = candidate.FullName,
                    Name = GetNameFromFullname(candidate.FullName),
                    Email = candidate.Email,
                    Phone = candidate.Phone,
                    Gender = candidate.Gender,
                    DateOfBirth = candidate.DateOfBirth,
                    Occupation = candidate.Occupation
                };
                //candidate.Position = ++countCandidate;
                //candidate.GetNameFromFullname(candidate.FullName);
                
                //newCandidate.GetNameFromFullname(candidate.FullName);
                _context.Candidates.Add(newCandidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
            }
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View(candidate);
        }

        public async Task<IActionResult> Edit(Guid idCandidate)
        {
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            //var candidate = await _context.Candidates.FindAsync(idCandidate);
            var candidateVM = await _context.Candidates
                .Where(c => c.Id.Equals(idCandidate))
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
                .SingleOrDefaultAsync();
            //return View("Create", candidate);
            return View(nameof(Create), candidateVM);
        }
        [HttpPost]
        //public async Task<IActionResult> Edit([Bind("Include = Id, FullName, DateOfBirth, Gender, Occupation, Email, Phone")] CandidateViewModel candidateVM)
        public async Task<IActionResult> Edit(CandidateViewModel candidateVM)
        {
            try
            {
                var candidate = await _context.Candidates
                    .FindAsync(candidateVM.Id);
                candidate.FullName = candidateVM.FullName;
                candidate.GetNameFromFullname(candidateVM.FullName);
                candidate.DateOfBirth = candidateVM.DateOfBirth;
                candidate.Gender = candidateVM.Gender;
                candidate.Occupation = candidateVM.Occupation;
                candidate.Email = candidateVM.Email;
                candidate.Phone = candidateVM.Phone;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
            }
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View(nameof(Create), candidateVM);
        }
        
        public string GetNameFromFullname(string fullName)
        {
            var name = "";
            string[] arrayString = fullName.Split(' ');
            if (arrayString != null && arrayString.Length > 0)
            {
                int lastIndex = arrayString.Length - 1;
                name = arrayString[lastIndex];
                
            }
            return name;
        }
    }
}
