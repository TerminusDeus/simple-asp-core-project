using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace deus.Controllers
{
    public class ZeusController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YourMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PrintMessage()
        {
            var msg = HttpContext.Request.Form["Text1"].ToString();
            ViewBag.Messages = (string.IsNullOrEmpty(msg)) ? "Please enter your message" : msg;
            return View("YourMessage");
        }

        [HttpPost]
        public IActionResult Send()
        {
            const string url =
                "http://api.geonames.org/weatherJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&username=demo";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();

            ViewBag.Messages = response;
            return View("YourMessage");
        }
    }
}