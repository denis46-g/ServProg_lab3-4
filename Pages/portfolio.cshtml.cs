using Laba3_4.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Laba3_4.models;

namespace Laba3_4.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly ILogger<PortfolioModel> _logger;

        //внедряем сервис
        private readonly JsonContext JsonC;

        //внедряем базу данных
        private readonly MyDbContext dbCont;

        public List<TestimonialService> testimonials { get; set; }

        public List<PortfolioService> portfolios { get; set; }

        public PortfolioModel(ILogger<PortfolioModel> logger, JsonContext jsContext, MyDbContext dbContext)
        {
            _logger = logger;
            JsonC = jsContext;
            dbCont = dbContext;
        }

        public void OnGet()
        {
            portfolios = JsonC.portfolios;
            testimonials = dbCont.Testimonials.ToList();
        }
    }
}