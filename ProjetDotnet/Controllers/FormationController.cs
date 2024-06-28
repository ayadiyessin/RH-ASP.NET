using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class FormationController : Controller
    {
        private readonly GestionRHContext context;

        public FormationController(GestionRHContext context)
        {
            this.context=context;
        }
        // GET: FormationController
        public ActionResult Index()
        {
            List<Formation> formations = context.Formations.ToList();
            List<Formation> fr = new List<Formation>();
            foreach (var x in formations)
            {
                if (x.archive_formation == 0)
                {
                    fr.Add(x);
                }
            }
            return View(fr);
        }

        // GET: FormationController/Details/5
        public ActionResult Details(int id)
        {
            Formation formation = context.Formations.Find(id);
            return View(formation);
        }

        // GET: FormationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Formation formation)
        {
            try
            {
                if (context.Formations.Where(x => x.nom_formation == formation.nom_formation)
                    .Count() > 0
                    )
                {
                    ViewBag.error = "Le formation existe !!!";
                    return View(formation);
                }
                context.Formations.Add(formation);
                context.SaveChanges();
                ViewBag.create = "Le formation ajouter !!!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormationController/Edit/5
        public ActionResult Edit(int id)
        {
            Formation formation=context.Formations.Find(id);
            return View(formation);
        }

        // POST: FormationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Formation formation)
        {
            try
            {
                Formation form = context.Formations.Find(id);
                form.nom_formation = formation.nom_formation;
                form.description_formation = formation.description_formation;
                context.SaveChanges();
                ViewBag.modifier = " Formation modifier ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormationController/Delete/5
        public ActionResult Delete(int id)
        {
            Formation formation = context.Formations.Find(id);
            return View(formation);
        }

        // POST: FormationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Formation formation)
        {
            try
            {
                context.Formations.Remove(formation);
                context.SaveChanges();
                ViewBag.supprimer = "Formation supprimer ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Archive()
        {
            List<Formation> formations = context.Formations.ToList();
            List<Formation> fr = new List<Formation>();
            foreach (var x in formations)
            {
                if (x.archive_formation == 1)
                {
                    fr.Add(x);
                }
            }
            return View(fr);
        }

        public ActionResult FormArchive(int id)
        {
            Formation formation = context.Formations.Find(id);
            return View(formation);
        }
        // POST: FormationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormArchive(int id, Formation formation)
        {
            try
            {
                Formation form = context.Formations.Find(id);
                form.archive_formation = 1;
                context.SaveChanges();
                ViewBag.modifier = " Formation Archiver ";
                return RedirectToAction(nameof(Archive));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FormDesarchive(int id)
        {
            Formation formation = context.Formations.Find(id);
            return View(formation);
        }

        // POST: FormationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormDesarchive(int id, Formation formation)
        {
            try
            {
                Formation form = context.Formations.Find(id);
                form.archive_formation = 0;
                context.SaveChanges();
                ViewBag.modifier = " Formation modifier ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
