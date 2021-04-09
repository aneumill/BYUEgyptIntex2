using BYUEgyptIntex2.Models;
using BYUEgyptIntex2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MummyDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MummyDbContext con)
        {
            _logger = logger;
            _context = con;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult AddRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecord(MummyModel formsubmission)
        {
            if (ModelState.IsValid)
            {

                _context.Mummy.Update(formsubmission);
                _context.SaveChanges();
                return View("AddConfirmation", formsubmission);
            }
            else
            {
                return View(formsubmission);
            }
        }

        [HttpGet]
        public IActionResult EditRecord()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditRecord(MummyModel formsubmission)
        {
            if (ModelState.IsValid)
            {

                _context.Mummy.Update(formsubmission);
                _context.SaveChanges();
                return View("EditConfirmation", formsubmission);
            }
            else
            {
                return View(formsubmission);
            }
        }

        [HttpPost]
        public IActionResult RemoveRecord(MummyModel formsubmission)

        {
            //instantiate a querable movie object equal to the DBcontextfile where the movie ID equals the passed in form
            IQueryable<MummyModel> queryable = _context.Mummy.Where(p => p.MummyID == formsubmission.MummyID);
            //Loop through the querable object and remove all data where those MovieIDs match
            foreach (var x in queryable)
            {
                _context.Mummy.Remove(x);
            }
            _context.SaveChanges();
            //Return the delete confirmation page
            return View("DeleteConfirmation");
        }

        [HttpGet]
        public IActionResult ViewRecords(long MummyID, int pageNum = 1)
        {
            //return View(_context.Mummy);



            //Set the items per page
            int pageSize = 1;

            return View(new ViewRecordViewModel
            {
                Mummy = _context.Mummy
            .Where(x => x.MummyID == MummyID || MummyID == 0)
            .OrderBy(x => x.Name)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList(),

                //Create the page numbering info dynamically
                PageNumberingInfo = new PagingNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (_context.Mummy.Count())

                },



            });

        }
        [HttpPost]
        public IActionResult ViewRecords(MummyModel formsubmission)
        {
            return View("EditRecord", formsubmission);
        }

























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
