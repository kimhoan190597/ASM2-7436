using ApplicationDevelopment.WebMVC.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationDevelopment.WebMVC.Models
{
    [Bind("Id, FullName, DateOfBirth, Gender, Occupation, Email, Phone")]
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int Position { get; set; }

        public OccupationEnum Occupation { get; set; }
    }
}
