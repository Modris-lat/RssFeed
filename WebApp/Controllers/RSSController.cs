using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RSSController : Controller
    {
        RssService _rssService;
        public RSSController(RssService rssService)
        {
            _rssService = rssService;
        }
        public IActionResult Index(string txt_url)
        {
            ViewBag.txt_url = txt_url;

            if (txt_url != null)
            {
                ViewBag.RSS = _rssService.Parse(txt_url);
            }
            return View();
        }
    }
}
