using sortingPersonName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;

namespace sortingPersonName.Controllers
{
    public class HomeController : Controller
    {
        string unsortedFile = System.Web.Hosting.HostingEnvironment.MapPath("/data/unsorted_name_list.txt");
        string sortedFile = System.Web.Hosting.HostingEnvironment.MapPath("/data/sorted_name_list.txt");
        private PersonsRepo oPersonsRepo = new PersonsRepo();
        
        public ActionResult Index()
        {
            var persons = new List<Person>();
            persons = oPersonsRepo.readPersons(unsortedFile);
          
            return View(persons);
        }
        public ActionResult onSorted()
        {
            var persons = new List<Person>();
            persons = oPersonsRepo.readPersons(unsortedFile);

            var sortedPersons = oPersonsRepo.sortPersons(persons);

            oPersonsRepo.createTxtFile(sortedFile, sortedPersons);

            persons = oPersonsRepo.readPersons(sortedFile);

            return View(sortedPersons);
        }
    }
}