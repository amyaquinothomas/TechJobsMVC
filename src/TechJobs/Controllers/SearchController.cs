using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> Results = new List<Dictionary<string, string>>();
            if (searchTerm == null)
            {
                ViewBag.jobs = Results;
                return View();
            }
            if (searchType == "all")
            {
                Results = JobData.FindByValue(searchTerm);
            }
            else
            {
                Results = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.jobs = Results;
            return View("Index");
        }
    }
}

