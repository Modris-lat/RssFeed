using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RSSController : Controller
    {
        IRssService _rssService;
        IFeeds _feeds;
        public RSSController(IRssService rssService, IFeeds feeds)
        {
            _rssService = rssService;
            _feeds = feeds;
        }
        public IActionResult Index(string feed)
        {
            ViewBag.SelectedFeed = feed;
            ViewBag.FeedList = _feeds.GetFeedNameList();

            if (feed != null)
            {
                var url = _feeds.GetFeeds().SingleOrDefault(o=>o.Name == feed).URL;
                ViewBag.RSS = _rssService.Parse(url);
            }
            return View();
        }
    }
}
