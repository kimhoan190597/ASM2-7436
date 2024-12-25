using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ApplicationDevelopment.WebMVC.Data.Entities
{
    public class Enterprise
    {
        public Enterprise()
        {
            Id = Guid.NewGuid();
            EnterpriseJobDetails = new Collection<EnterpriseJobDetail>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Description("Trụ sở Headquarter")]
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Hotline { get; set; }

        public string TaxNumber { get; set; }

        public int Position { get; set; }

        public ICollection<EnterpriseJobDetail> EnterpriseJobDetails { get; set; }
    }
}
