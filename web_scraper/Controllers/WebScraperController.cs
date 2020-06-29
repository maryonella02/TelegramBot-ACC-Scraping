using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AngleSharp;
using AngleSharp.Html.Parser;
using web_scraper.Models;

namespace web_scraper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {  private const string CURRENT_URL = "https://acc.md/mmedia/deconectari-curente.html";
        private readonly ILogger<WebScraperController> _logger;
        // Constructor
        public WebScraperController(ILogger<WebScraperController> logger)
        {
            _logger = logger;
        }

             [HttpGet]

        private async Task<List<dynamic>> GetPageData(string CURRENT_URL, List<dynamic> results)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(CURRENT_URL);

            // Debug
            //_logger.LogInformation(document.DocumentElement.OuterHtml);

            var shutrows = document.QuerySelectorAll("tr");

            foreach (var row in shutrows)
            {
                // Create a container object
                CurrentShutdown shutdown = new CurrentShutdown(){
                    Region = row.QuerySelector("tr td:nth-child(1)").TextContent,
                    Street = row.QuerySelector(" tr td:nth-child(2)").TextContent,



                    Disconnectdate = row.QuerySelector("tr td:nth-child(7)").TextContent,

                    Disconnecthour = row.QuerySelector("tr td:nth-child(8)").TextContent,
                    Connectdate = row.QuerySelector("tr td:nth-child(9)").TextContent,
                    Connecthour = row.QuerySelector("tr td:nth-child(10)").TextContent                
};
                results.Add(shutdown);
                
            }
             
            return results;
            }

        [HttpGet]
        public string Get()
        {
          
            return "Hello";
        }
         }  
    }  
