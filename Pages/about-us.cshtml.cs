using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laba3_4.Pages
{
    public class AboutUsModel : PageModel
    {
        private readonly ILogger<AboutUsModel> _logger;

        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}