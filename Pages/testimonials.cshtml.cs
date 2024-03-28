using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laba3_4.Pages
{
    public class TestimonialsModel : PageModel
    {
        private readonly ILogger<TestimonialsModel> _logger;

        public TestimonialsModel(ILogger<TestimonialsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}