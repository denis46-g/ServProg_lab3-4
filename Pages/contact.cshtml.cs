using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;

namespace Laba3_4.Pages
{
    [IgnoreAntiforgeryToken]
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
           
        }

        public record Info(string first_name, string last_name, string email,
                           string phone, string select_service, string select_price,
                           string comments);

        public IActionResult OnPost(Info inf) 
        {
            if (inf.first_name == null || inf.first_name == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter your firstName !<fieldset>");
            else if(inf.last_name == null || inf.last_name == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter your lastName !<fieldset>");
            else if(inf.email == null || inf.email == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter your email !<fieldset>");
            else if(inf.phone == null || inf.phone == "")
                return Content("<fieldset><strong>Error!</strong> Please, enter your phone number !<fieldset>");
            else if (!(inf.phone.All(char.IsDigit) || inf.phone.StartsWith("+") && inf.phone.Substring(1).All(char.IsDigit)))
                return Content("<fieldset><strong>Error!</strong> Phone number contains only digits or the symbol \"+\" and then only digits !<fieldset>");
            else if(!inf.email.Contains('@'))
                return Content("<fieldset><strong>Error!</strong> Email must have the \"@\" symbol !<fieldset>");
            else if(inf.email.StartsWith('@'))
                return Content("<fieldset><strong>Error!</strong> In email the \"@\" symbol must be after username !<fieldset>");
            else if(inf.email.EndsWith('@'))
                return Content("<fieldset><strong>Error!</strong> In email domain name must be after \"@\" symbol !<fieldset>");
            else if(!inf.email.Contains('.'))
                return Content("<fieldset><strong>Error!</strong> Email must have the \".\" symbol !<fieldset>");
            else if (inf.email.StartsWith('.') || inf.email.EndsWith('.') || inf.email.IndexOf('@') > inf.email.IndexOf('.'))
                return Content("<fieldset><strong>Error!</strong> Email should have the structure : username@domainname.codeoforganisationorcountry !<fieldset>");
            else if(inf.comments == null || inf.comments == "")
                return Content("<fieldset>Please, give us more details about yourself and write them.<fieldset>");

            using (var writer = new StreamWriter("contact.csv", true, System.Text.Encoding.UTF8))
            using (var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                csv.NextRecord();
                csv.WriteRecord(inf);
            }

            return Content("<fieldset><div id='success_page'><h1>Email Sent Successfully.</h1><p>Thank you, <strong>" + inf.first_name + ' '+ inf.last_name + "</strong>, your message has been submitted to us.</p></div></fieldset>");
        }
    }
}