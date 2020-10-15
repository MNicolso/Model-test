using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using Model_test.Models;

namespace Model_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FizzBuzz()
        {
            List<FizzBuzzModel> Result = new List<FizzBuzzModel>();
            return View(Result);
        }

        [HttpPost]
        public IActionResult FizzBuzz(int fizzInput, int buzzInput, int minInput, int maxInput, int arrayResult)
        {
            List<FizzBuzzModel> Result = new List<FizzBuzzModel>();
            bool fizz = false;
            bool buzz = false;
            for (int i = minInput; i <= maxInput; i++) 
            {
                FizzBuzzModel fbItem = new FizzBuzzModel();
                fizz = (i % fizzInput == 0);
                buzz = (i % buzzInput == 0);

                if(fizz && buzz)
                {
                    fbItem.Result = "fizzBuzz";
                }
                else if (fizz)
                {
                    fbItem.Result = "fizz";
                }
                else if (buzz)
                {
                    fbItem.Result = "buzz";
                }
                else
                {
                    fbItem.Result = i.ToString();
                }
                Result.Add(fbItem);
            }

            
            return View(Result);
        }

            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
