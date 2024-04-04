using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Laba3_4.data;
using Laba3_4.models;

namespace Laba3_4.Pages
{
    [IgnoreAntiforgeryToken]
    public class TestimonialsModel : PageModel
    {
        private readonly ILogger<TestimonialsModel> _logger;

        //внедряем базу данных
        private readonly MyDbContext dbCont;

        public List<TestimonialService> testimonials { get; set; }

        public TestimonialsModel(ILogger<TestimonialsModel> logger, MyDbContext dbContext)
        {
            _logger = logger;
            dbCont = dbContext;
        }

        public void OnGet()
        {
            testimonials = dbCont.Testimonials.ToList();
        }

        public record Test(string name, string occupation, string title,
                           string description);

        public IActionResult OnPost(Test test)
        {
            if (test.name == null || test.name == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter your name !<fieldset>");
            else if (test.occupation == null || test.occupation == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter your occupation !<fieldset>");
            else if (test.title == null || test.title == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter the title !<fieldset>");
            else if (test.description == null || test.description == "")
                return Content("<fieldset>Please, give us more description and write it.<fieldset>");

            dbCont.Testimonials.Add(new TestimonialService { name = test.name, img_url = "Lion.jpg", occupation = test.occupation, title = test.title, description = test.description });
            dbCont.SaveChanges();

            return Content("<fieldset><div id='success_page'><h1>Testimonial Sent Successfully.</h1><p>Thank you, <strong>" + test.name + "</strong>, your testimonial has been submitted to us.</p></div></fieldset>");
        }
    }
}