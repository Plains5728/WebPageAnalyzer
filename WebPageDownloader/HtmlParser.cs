using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebPageDownloader
{
    public static class HtmlParser {
        /// <summary>
        /// Get a dictionary of words and counts by word
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, int>> WordParser(string url)
        {
            SortedDictionary<string, int> wordsDictionary = new SortedDictionary<string, int>();

            HtmlWeb html = new HtmlWeb();
            HtmlDocument doc = html.Load(url);
            var text = doc.DocumentNode.SelectNodes("//*[not(self::script or self::style)]/text()[normalize-space()]")
                .Select(t => t.InnerText);

            foreach (var sentence in text)
            {
                foreach (var word in sentence.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }))
                {
                    if (Regex.IsMatch(word, @"\w+"))
                    {
                        if (wordsDictionary.Keys.Any(k => k == word))
                        {
                            wordsDictionary[word]++;
                        }
                        else
                        {
                            wordsDictionary.Add(word, 1);
                        }
                    }
                }
            }

            return wordsDictionary.OrderByDescending(w => w.Value).ToList();
        }

        public static List<string> GetImageSources(string url)
        {
            List<string> imgSrc = new List<string>();

            HtmlWeb html = new HtmlWeb();
            HtmlDocument doc = html.Load(url);

            imgSrc.AddRange(doc.DocumentNode.Descendants("img")
                            .Select(e => e.GetAttributeValue("src", null)));

            return imgSrc;
        }
    }
}
