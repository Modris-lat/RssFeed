
using Core.Interfaces;

namespace Core
{
    public class Feeds: IFeeds
    {
        List<Feed> _feeds;
        public Feeds()
        {
            _feeds = new List<Feed>
            {
                new Feed
                {
                    Name = "Jaunākās ziņas",
                    URL = "https://www.delfi.lv/rss/?channel=delfi"
                },
                new Feed
                {
                    Name = "Biznesa ziņas",
                    URL = "https://www.delfi.lv/rss/?channel=bizness"
                },
                new Feed
                {
                    Name = "Laika ziņas",
                    URL = "https://www.delfi.lv/rss/?channel=laikazinas"
                }
            };
        }
        public List<Feed> GetFeeds()
        {
            return _feeds.ToList();
        }
        public HashSet<string> GetFeedNameList()
        {
            var names = new HashSet<string>();
            _feeds.ForEach(feed=>names.Add(feed.Name));
            return names;
        }
    }
}
