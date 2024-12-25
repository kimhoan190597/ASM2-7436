using ApplicationDevelopment.WebMVC.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationDevelopment.WebMVC.Helpers
{
    public static class DataHelper
    {
        public static SelectList GetOccupationSelectList()
        {
            var occupations = from OccupationEnum job in Enum.GetValues(typeof(OccupationEnum))
                              select new
                              {
                                  Id = job,
                                  Name = job.ToString()
                              };
            return new SelectList(occupations, "Id", "Name", 4);
        }
    }
}
