using ApplicationDevelopment.WebMVC.Enums;

namespace ApplicationDevelopment.WebMVC.Commons
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int Position { get; set; }

        public OccupationEnum Occupation { get; set; }

        public string GetNameFromFullname(string fullName)
        {
            var name = "";
            string[] arrayString = fullName.Split(' ');
            if (arrayString != null && arrayString.Length > 0)
            {
                int lastIndex = arrayString.Length - 1;
                name = arrayString[lastIndex];
                this.Name = name;
            }
            return name;
        }
    }
}
