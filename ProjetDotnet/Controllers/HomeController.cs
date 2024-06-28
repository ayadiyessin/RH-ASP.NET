using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Data;
using ProjetDotnet.Models;
using System.Diagnostics;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GestionRHContext context;
        public HomeController(ILogger<HomeController> logger, GestionRHContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CountEmp = context.Employers.Where(x => x.archive_emp == 0).Count();
            ViewBag.CountDep = context.Departements.Where(x => x.archive_dep == 0).Count();
            ViewBag.CountPost = context.Postes.Where(x => x.archive_poste == 0).Count();
            ViewBag.CountFor = context.Formations.Where(x => x.archive_formation == 0).Count();

            ViewBag.CountEmpArch = context.Employers.Where(x => x.archive_emp == 1).Count();
            ViewBag.CountDepArch = context.Departements.Where(x => x.archive_dep == 1).Count();
            ViewBag.CountPostArch = context.Postes.Where(x => x.archive_poste == 1).Count();
            ViewBag.CountForArch = context.Formations.Where(x => x.archive_formation == 1).Count();

            ViewBag.sexeEmpFemme = context.Employers.Where(x => x.sexe_emp == "Femme" && x.archive_emp==0).Count();
            ViewBag.sexeEmpHomme = context.Employers.Where(x => x.sexe_emp == "Homme" && x.archive_emp == 0).Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
