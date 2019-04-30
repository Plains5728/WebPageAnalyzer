using System.Linq;
using System.Web.Mvc;
using WebPageAnalyzer.Models;
using WebPageDownloader;

namespace WebPageAnalyzer.Controllers
{
    public class AnalysisController : Controller
    {
        // GET: Analysis
        public ActionResult Index()
        {
            AnalyzerViewModel viewModel = new AnalyzerViewModel();

            return View(viewModel);
        }

        public ActionResult SubmitUrlforAnalysis(AnalyzerViewModel viewModel)
        {
            var webPageWords= HtmlParser.WordParser(viewModel.TestUrl);
            viewModel.WebPageWordCount = webPageWords.Sum(w => w.Value);

            var top10words= webPageWords.Take(10).ToList();

            viewModel.Top10WebPageWords = webPageWords.Take(10).ToList();

            viewModel.WebPageImages = HtmlParser.GetImageSources(viewModel.TestUrl);

            return View("Index", viewModel);
        }
    }
}