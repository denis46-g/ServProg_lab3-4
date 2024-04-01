using Laba3_4.models;
using System.Text.Json;

namespace Laba3_4.data
{
    public class JsonContext
    {
        public JsonContext()
        {
            var jsonData = new FileStream("portfolio.json", FileMode.OpenOrCreate);
            portfolios = JsonSerializer.Deserialize<List<PortfolioService>>(jsonData);
        }

        public List<PortfolioService> portfolios = new List<PortfolioService>();
    }
}
