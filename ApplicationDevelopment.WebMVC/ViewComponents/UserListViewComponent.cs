using ApplicationDevelopment.WebMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationDevelopment.WebMVC.ViewComponents
{
    public class UserListViewComponent: ViewComponent
    {
        private readonly DataService _serviceData;
        private readonly AppDbContext _context;
        public UserListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        public IViewComponentResult Invoke()
        {
            //var users = _serviceData.GetUsers();
            var users = _context.Users
                .OrderBy(u => u.Position)
                .ToList();
            return View(users);
        }
    }
}
