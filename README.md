# WebPageAnalyzer
WebPageAnalyzer 2019-04-30

WebPageAnalyzer is the web project for this code challenge.

Download this repo, open in Visual Studio, and run in IIS Express.

The web application takes a Url and displays any images in the web page in a carousel, 
and displays the word count on the page, 
and displays a chart of the top 10 word counts on the page

WebPageDownloader is a libray used by WebPageAnalyzer
that utizes functionality in the HtmlAgilityPack 
to load the html from a url
extract all text in the html except scripts and styles
and creates a string/int SortedDictionary of words and counts of their appearance in the text.
