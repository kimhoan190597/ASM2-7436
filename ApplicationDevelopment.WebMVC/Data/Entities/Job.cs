using System.Collections.ObjectModel;

namespace ApplicationDevelopment.WebMVC.Data.Entities
{
    public class Job
    {
        public Job()
        {
            Id = Guid.NewGuid();
            EnterpriseJobDetails = new Collection<EnterpriseJobDetail>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Requirements { get; set; }

        public int Postion { get; set; }

        public Guid JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }

        public ICollection<EnterpriseJobDetail> EnterpriseJobDetails { get; set; }

    }
}
