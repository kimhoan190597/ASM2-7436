using ApplicationDevelopment.WebMVC.Models;

namespace ApplicationDevelopment.WebMVC.Data
{
    public class DataService
    {
        private List<User> Users { get; set; } = null;
        public DataService()
        {
            if (Users == null)
            {
                Users = new List<User>();
            }
        }
        public List<User> GetUsers()
        {
            return Users;
        }
    }
}
