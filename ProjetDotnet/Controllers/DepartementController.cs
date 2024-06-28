using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class DepartementController : Controller
    {
        private readonly GestionRHContext context;

        public DepartementController(GestionRHContext context)
        {
            this.context=context;
            
        }
        // GET: DepartementController
        public ActionResult Index()
        {
            List<Departement> departements = context.Departements.ToList();
            List<Departement> dep = new List<Departement>();
            foreach (var x in departements)
            {
                if (x.archive_dep == 0)
                {
                    dep.Add(x);
                }
            }
            return View(dep);
        }

        // GET: DepartementController/Details/5
        public ActionResult Details(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }

        // GET: DepartementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement)
        {
            try
            {
                if (context.Departements.Where(x => x.Id_dep == departement.Id_dep)
                    .Count() > 0
                    )
                {
                    ViewBag.error = "Le departement existe !!!";
                    return View(departement);
                }
                context.Departements.Add(departement);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartementController/Edit/5
        public ActionResult Edit(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }

        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departement departement)
        {
            try
            {
                Departement dep = context.Departements.Find(id);
                dep.Id_dep=departement.Id_dep;
                dep.Nom_dep=departement.Nom_dep;
                dep.description_dep = departement.description_dep;
                //dep.archive_dep = departement.archive_dep;
                context.SaveChanges();
                ViewBag.modifier = " departement modifier ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartementController/Delete/5
        public ActionResult Delete(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }

        // POST: DepartementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departement departement)
        {
            try
            {
                context.Departements.Remove(departement);
                context.SaveChanges();
                ViewBag.supprimer = "departement supprimer ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //archiver
        public ActionResult Archiver()
        {
            List<Departement> departements = context.Departements.ToList();
            List<Departement> dep = new List<Departement>();
            foreach (var x in departements)
            {
                if (x.archive_dep == 1)
                {
                    dep.Add(x);
                }
            }
            return View(dep);
        }

        public ActionResult depArchiver(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }
        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult depArchiver(int id, Departement departement)
        {
            try
            {
                Departement dep = context.Departements.Find(id);
               // dep.Id_dep = departement.Id_dep;
               // dep.Nom_dep = departement.Nom_dep;
               // dep.description_dep = departement.description_dep;
                dep.archive_dep = 1;
                context.SaveChanges();
                ViewBag.archiver = " departement archiver ";
                return RedirectToAction(nameof(Archiver));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult depDesarchiver(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }

        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult depDesarchiver(int id, Departement departement)
        {
            try
            {
                Departement dep = context.Departements.Find(id);
                //dep.Id_dep = departement.Id_dep;
               // dep.Nom_dep = departement.Nom_dep;
               // dep.description_dep = departement.description_dep;
                dep.archive_dep = 0;
                context.SaveChanges();
                ViewBag.desarchiver = " departement Desarchiver ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    

}
