using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class TacheController : Controller
    {
        private readonly GestionRHContext context;

        public TacheController(GestionRHContext context)
        {
            this.context=context;
        }
        // GET: TacheController
        public ActionResult Index(int id)
        {
            List<Tache> taches = context.Taches
                .Include(x => x.Employer)
                .Where(x => x.employerId == id)
                .ToList();
            Employer emp = context.Employers.Find(id);
            ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == id).ToList();
            ViewBag.Listpostes = context.Postes.Where(x => x.Id_post == emp.Id_post).ToList();
            return View(taches);
        }

        // GET: TacheController/Details/5
        public ActionResult Details(int id)
        {
            Tache tache = context.Taches
                .Include(x => x.Employer)
                .FirstOrDefault(x => x.Id_tache == id);
            return View(tache);
        }

        // GET: TacheController/Create
        public ActionResult Create(int id)
        {
            ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == id).ToList();
            return View();
        }

        // POST: TacheController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int idx,Tache tache)
        {
            try
            {
                if (ModelState.IsValid)// verif 3andnechy des contrainte fi modaile (?) accepte valeur nul ou non 
                {
                    context.Taches.Add(tache);
                    context.SaveChanges();
                    ViewBag.create = "tache ajoutée";
                    return RedirectToAction("Index", "Employer");
                }
                ViewBag.ListEmployers = context.Employers.Where(x => x.Id_emp == idx).ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TacheController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Listemployers = context.Employers.Where(x => x.archive_emp == 0).ToList();
            Tache tache = context.Taches.Find(id);
            return View(tache);
        }

        // POST: TacheController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tache tache)
        {
            try
            {
                Tache tach = context.Taches.Find(id);
                tach.date_deb_tache=tache.date_deb_tache;
                //tach.date_fin_tache = tache.date_fin_tache;
                tach.description_rapp=tach.description_rapp;
                tach.employerId=tache.employerId;
                context.SaveChanges();
                ViewBag.modifier = " tache modifier ";
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: TacheController/Delete/5
        public ActionResult Delete(int id)
        {
            Tache tache = context.Taches.Find(id);
            return View(tache);
        }

        // POST: TacheController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tache tache)
        {
            try
            {
                context.Taches.Remove(tache);
                context.SaveChanges();
                ViewBag.supprimer = "tache supprimer ";
                return RedirectToAction("Index", "Employer");
            }
            catch
            {
                return View();
            }
        }

        // GET: TacheController/Edit/5
        public ActionResult TacheTerminer(int id)
        {
            ViewBag.Listemployers = context.Employers.Where(x => x.archive_emp == 0).ToList();
            Tache tache = context.Taches.Find(id);
            return View(tache);
        }

        // POST: TacheController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TacheTerminer(int id, Tache tache)
        {
            try
            {
                Tache tach = context.Taches.Find(id);
                tach.date_fin_tache = DateTime.Now;
                tach.description_rapp = tache.description_rapp;
                context.SaveChanges();
                ViewBag.modifier = " tache terminer ";
                return RedirectToAction("Index", "Employer");

            }
            catch
            {
                return View();
            }
        }
    }
}
