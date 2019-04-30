using System.Collections.Generic;

namespace WebPageAnalyzer.Models
{
    public class AnalyzerViewModel
    {
        public List<KeyValuePair<string,int>> Top10WebPageWords { get; set; }
        public int WebPageWordCount { get; set; }
        public List<string> WebPageImages { get; set; }
        public string TestUrl { get; set; }

        public AnalyzerViewModel()
        {
            WebPageImages = new List<string>();
            Top10WebPageWords = new List<KeyValuePair<string, int>>();
        }
    }
}