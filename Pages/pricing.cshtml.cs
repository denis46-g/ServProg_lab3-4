using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laba3_4.Pages
{
    public class PricingModel : PageModel
    {
        private readonly ILogger<PricingModel> _logger;

        public PricingModel(ILogger<PricingModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}