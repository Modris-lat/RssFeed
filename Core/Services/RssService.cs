using Core.Interfaces;
using System.Xml.Linq;

namespace Core.Services
{
    public class RssService: IRssService
    {
        
        public IList<RssModel> Parse(string url)
        {
            return ParseRss(url);
        }
        public virtual IList<RssModel> ParseRss(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);
                // RSS/Channel/item
                var entries = from item in doc.Root
                              .Descendants()
                              .First(i => i.Name.LocalName == "channel")
                              .Elements()
                              .Where(i => i.Name.LocalName == "item")
                              select new RssModel
                              {
                                  Description = item.Elements().First(i => i.Name.LocalName == "description").Value.Replace("&quot;","\""),
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value).ToString(),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };
                return entries.ToList();
            }
            catch
            {
                return new List<RssModel>();
            }
        }

        private DateTime ParseDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
                return result;
            else
                return DateTime.MinValue;
        }
    }
}
