namespace ApplicationDevelopment.WebMVC.Data.Entities
{
    public class CV
    {
        public CV()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
