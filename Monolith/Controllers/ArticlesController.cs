using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monolith.Models;

namespace Monolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // GET: api/Articles/
        [HttpGet]
        public string GetArticle([FromQuery(Name = "uri")] string uri)
        {

            string result = "";

            using (HttpClient client = new())
            {
                using HttpResponseMessage response = client.GetAsync(uri).Result;
                using HttpContent content = response.Content;
                result = content.ReadAsStringAsync().Result;
            }
            var html = @uri;

            HtmlWeb web = new();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("/article");

            return node.InnerText;
        }
    }
}
