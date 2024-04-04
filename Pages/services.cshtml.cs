using Laba3_4.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Laba3_4.models;

namespace Laba3_4.Pages
{
    public class ServicesModel : PageModel
    {
        private readonly ILogger<ServicesModel> _logger;

        //�������� ���� ������
        private readonly MyDbContext dbCont;

        public List<TestimonialService> testimonials { get; set; }

        public ServicesModel(ILogger<ServicesModel> logger, MyDbContext dbContext)
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