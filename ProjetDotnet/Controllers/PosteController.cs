using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class PosteController : Controller
    {
        private readonly GestionRHContext context;

        public PosteController(GestionRHContext context)
        {
            
            this.context=context;
        }
        // GET: PosteController
        public ActionResult Index()
        {
            List<Poste> postes = context.Postes
               .Include(x => x.Departement)
               .ToList();
            List<Poste> pst = new List<Poste>();
            foreach (var x in postes)
            {
                if (x.archive_poste == 0)
                {
                    pst.Add(x);
                }
            }
            return View(pst);
        }

        // GET: PosteController/Details/5
        public ActionResult Details(int id)
        {
                Poste poste = context.Postes
               .Include(x => x.Departement)
               .FirstOrDefault(x => x.Id_post == id); 
            return View(poste);
        }

        // GET: PosteController/Create
        public ActionResult Create()
        {
            ViewBag.ListDepartements = context.Departements.Where(x => x.archive_dep == 0).ToList();
            return View();
        }

        // POST: PosteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Poste poste)
        {
            try
            {
                if (ModelState.IsValid)// verif 3andnechy des contrainte fi modaile (?) accepte valeur nul ou non 
                {
                    if (context.Postes.Where(x => x.Nom_post == poste.Nom_post).Count() > 0)
                    {
                        ViewBag.ListDepartements = context.Departements.Where(x => x.archive_dep == 0).ToList(); // bech n3awed n3abi liste <select>
                        ViewBag.messageerror = "la poste existe";
                        return View(poste);
                    }
                    else
                    {
                        context.Postes.Add(poste);
                        context.SaveChanges();
                        ViewBag.create = "poste ajoutée";
                        return RedirectToAction(nameof(Index));
                    }


                }
                ViewBag.ListDepartements = context.Departements.Where(x => x.archive_dep == 0).ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PosteController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListDepartements = context.Departements.Where(x => x.archive_dep == 0).ToList();
            Poste poste = context.Postes.Find(id);
            return View(poste);
        }

        // POST: PosteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Poste poste)
        {
            try
            {
                Poste pos = context.Postes.Find(id);
                pos.Nom_post=poste.Nom_post;
                pos.description_post = poste.description_post;
                pos.salaire_post = poste.salaire_post;
                pos.Id_dep = poste.Id_dep;
                context.SaveChanges();
                ViewBag.edit = "poste modifier";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PosteController/Delete/5
        public ActionResult Delete(int id)
        {
            Poste poste = context.Postes.Find(id);
            return View(poste);
            
        }

        // POST: PosteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Poste poste)
        {
            try
            {
                context.Postes.Remove(poste);
                context.SaveChanges();
                ViewBag.delate = "Poste supprimer ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Archiver()
        {
            List<Poste> postes = context.Postes
               .Include(x => x.Departement)
               .ToList();
            List<Poste> pst = new List<Poste>();
            foreach (var x in postes)
            {
                if (x.archive_poste == 1)
                {
                    pst.Add(x);
                }
            }
            return View(pst);
        }

        public ActionResult PostArchiver(int id)
        {
            ViewBag.ListDepartements = context.Departements.Where(x => x.archive_dep == 0).ToList();
            Poste poste = context.Postes.Find(id);
            return View(poste);
        }
        // POST: PosteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostArchiver(int id, Poste poste)
        {
            try
            {
                Poste pos = context.Postes.Find(id);
                pos.archive_poste = 1;
                context.SaveChanges();
                ViewBag.edit = "poste archiver";
                return RedirectToAction(nameof(Archiver));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PostDesarchiver(int id)
        {
            ViewBag.ListDepartements = context.Departements.Where(x => x.archive_dep == 0).ToList();
            Poste poste = context.Postes.Find(id);
            return View(poste);
        }

        // POST: PosteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostDesarchiver(int id, Poste poste)
        {
            try
            {
                Poste pos = context.Postes.Find(id);
                pos.archive_poste = 0;
                context.SaveChanges();
                ViewBag.edit = "poste desarchiver";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
