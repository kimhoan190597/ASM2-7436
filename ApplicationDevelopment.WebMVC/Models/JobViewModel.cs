using Microsoft.AspNetCore.Mvc;

namespace ApplicationDevelopment.WebMVC.Models
{
    [Bind("Id, Name, Description, Requirements, JobTypeId")]
    public class JobViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Requirements { get; set; }

        public Guid JobTypeId { get; set; }
        public string JobType { get; set; } = string.Empty;
    }
}
