using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class WebScraping
    {
        private static string nintendoUrl = "https://www.nintendoswitch.pl/recenzje/";

        public static async Task<string> GetReview(string author = "")
        {
            try
            {
                if (author == "")
                {
                    author = Properties.Resources.ReviewAuthor;
                }

                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(nintendoUrl);
                var reviewsUrls = doc.DocumentNode.SelectNodes("//div[@class='main-wrapper-text']/a");
                foreach (var item in reviewsUrls)
                {
                    if(WebScraping.Find(author, item.Attributes["href"].Value)==true)
                    {
                        return $"{author}\n"+item.Attributes["href"].Value;
                    }
                }
                await Task.CompletedTask;
                return $"Found... nothing... {author} is lazy...";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static bool Find(string text, string url)
        {       
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            var headers = doc.DocumentNode.SelectNodes("//h4");
            var data = text.Split(" ");
            int found = 0;
            for (int i = 0; i < headers.Count; i++)
            {
                found = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    if (headers[i]
                        .InnerText
                        .Contains(data[j]) == true)
                    {
                        ++found;
                    }
                }
                if (found == data.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
