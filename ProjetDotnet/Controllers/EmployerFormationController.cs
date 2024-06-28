using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class EmployerFormationController : Controller
    {
        private readonly GestionRHContext context;

        public EmployerFormationController(GestionRHContext context)
        {

            this.context=context;
        }
        // GET: EmployerFormationController
        public ActionResult Index(int id)
        {
            List<EmployerFormation> employerFormations = context.EmployerFormations
                .Include(x => x.Employer)
                .Include(y => y.Formation)
                .Where(x => x.employerId == id)
                .ToList();
            ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == id).ToList();
            return View(employerFormations);
        }

        // GET: EmployerFormationController/Details/5
        public ActionResult Details(int id)
        {
            EmployerFormation employerFormation = context.EmployerFormations
                .Include(x => x.Employer)
                .Include(y => y.Formation)
                .FirstOrDefault(x => x.Id_empform == id) ;
            return View(employerFormation);
        }

        // GET: EmployerFormationController/Create
        public ActionResult Create(int id)
        {
            ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == id).ToList();
            ViewBag.Listformations = context.Formations.Where(x => x.archive_formation == 0).ToList();
            return View();
        }

        // POST: EmployerFormationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int idep,EmployerFormation employerFormation)
        {
            try
            {
                if (ModelState.IsValid)// verif 3andnechy des contrainte fi modaile (?) accepte valeur nul ou non 
                {
                    context.EmployerFormations.Add(employerFormation);
                    context.SaveChanges();
                    ViewBag.create = "formation ajoutée pour cette employer";
                    ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == idep).ToList();
                    return RedirectToAction("Index", "Employer");
                }
                ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == idep).ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployerFormationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Listemployers = context.Employers.Where(x => x.archive_emp == 0).ToList();
            ViewBag.Listformations = context.Formations.Where(x => x.archive_formation == 0).ToList();
            EmployerFormation employerFormation = context.EmployerFormations.Find(id);
            return View(employerFormation);
        }

        // POST: EmployerFormationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,EmployerFormation employerFormation)
        {
            try
            {
                EmployerFormation employerFormation1 = context.EmployerFormations.Find(id);
                employerFormation1.date_fin_empform=DateTime.Now;
                ViewBag.edit = "formation terminer";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployerFormationController/Delete/5
        public ActionResult Delete(int id)
        {
            EmployerFormation employerFormation = context.EmployerFormations.Find(id);
            return View(employerFormation);
        }

        // POST: EmployerFormationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployerFormation employerFormation)
        {
            try
            {
                context.EmployerFormations.Remove(employerFormation);
                context.SaveChanges();
                ViewBag.supprimer = "employer formation supprimer ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // raj3elna kol employer 9adeh andou men formation 
        public int CountFormation(int id) // id employer 
        {
            //var count = context.EmployerFormations.Count(f => f.employerId == id);
            var count = context.EmployerFormations.Where(x => x.employerId == id).Count();

            return count;
        }
    }
}
