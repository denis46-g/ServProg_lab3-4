using Laba3_4.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Laba3_4.models;

namespace Laba3_4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //внедряем базу данных
        private readonly MyDbContext dbCont;

        public List<TestimonialService> testimonials { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MyDbContext dbContext)
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
