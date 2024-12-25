using ApplicationDevelopment.WebMVC.Commons;
using System.Collections.ObjectModel;

namespace ApplicationDevelopment.WebMVC.Data.Entities
{
    public class Candidate : Person
    {
        public Candidate()
        {
            CVs = new Collection<CV>();
        }
        public ICollection<CV> CVs { get; set; }
    }
}
