using Laba3_4.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Laba3_4.models;

namespace Laba3_4.Pages
{
    public class FeaturesModel : PageModel
    {
        private readonly ILogger<FeaturesModel> _logger;

        //внедряем базу данных
        private readonly MyDbContext dbCont;

        public List<TestimonialService> testimonials { get; set; }

        public FeaturesModel(ILogger<FeaturesModel> logger, MyDbContext dbContext)
        {
            _logger = logger;
            dbCont = dbContext;
        }

        public void OnGet()
        {
            testimonials = dbCont.Testimonials.ToList();
        }
    }
}