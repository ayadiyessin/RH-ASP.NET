using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class CongeController : Controller
    {
        private readonly GestionRHContext context;

        public CongeController(GestionRHContext context)
        {
            this.context = context;
            
        }

        
        // GET: CongeController
        public ActionResult Index()
        {
            List<Conge> conges = context.Conges
                .Include(x => x.Employer )
                .ToList();
            List<Conge> cg = new List<Conge>();
            foreach (var x in conges)
            {
                if (x.confirmation_conge == 0)
                {
                    cg.Add(x);
                }
            }
            return View(cg);
        }

        // GET: CongeController/Details/5
        public ActionResult Details(int id)
        {
            Conge conge = context.Conges
                .Include(x => x.Employer)
                .FirstOrDefault(x => x.Id_conge == id);
            return View(conge);
        }

        // GET: CongeController/Create
        public ActionResult Create()
        {
            ViewBag.Listemployers = context.Employers.ToList();
            return View();
        }

        // POST: CongeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conge conge)
        {
            try
            {
                if (ModelState.IsValid)// verif 3andnechy des contrainte fi modaile (?) accepte valeur nul ou non 
                {
                        conge.date_env_conge = DateTime.Now;
                        context.Conges.Add(conge);
                        context.SaveChanges();
                        ViewBag.create = "Congé ajoutée";
                        return RedirectToAction(nameof(Index));
                }
                ViewBag.Listemployers = context.Employers.ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CongeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Listemployers = context.Employers.ToList();
            Conge conge = context.Conges.Find(id);
            return View(conge);
        }

        // POST: CongeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Conge conge)
        {
            try
            {
                Conge conge1 = context.Conges.Find(id);
                conge1.type_conge = conge.type_conge;
                conge1.description_conge = conge.description_conge;
                conge1.date_env_conge = conge.date_env_conge;
                conge1.date_deb_conge=conge.date_deb_conge;
                conge1.date_fin_conge = conge.date_fin_conge;
                context.SaveChanges();
                ViewBag.modifier = " congé modifier ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CongeController/Delete/5
        public ActionResult Delete(int id)
        {
            Conge conge=context.Conges.Find(id);
            return View(conge);
        }

        // POST: CongeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Conge conge)
        {
            try
            {
                context.Conges.Remove(conge);
                context.SaveChanges();
                ViewBag.supprimer = "Congé supprimer ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConfirmerConge()
        {
            List<Conge> conges = context.Conges
                .Include(x => x.Employer)
                .ToList();
            List<Conge> cg = new List<Conge>();
            foreach (var x in conges)
            {
                if (x.confirmation_conge == 1)
                {
                    cg.Add(x);
                }
            }
            return View(cg);
        }

        public ActionResult BtnConfirmerConge(int id)
        {
            ViewBag.Listemployers = context.Employers.Where(x => x.archive_emp == 0).ToList();
            Conge conge = context.Conges.Find(id);
            return View(conge);
        }

        // POST: CongeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BtnConfirmerConge(int id, Conge conge)
        {
            try
            {
                Conge conge1 = context.Conges.Find(id);
                conge1.confirmation_conge = 1;
                
                context.SaveChanges();
                ViewBag.modifier = " congé confirmer ";
                return RedirectToAction(nameof(ConfirmerConge));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult RefuserConge()
        {
            List<Conge> conges = context.Conges
                .Include(x => x.Employer)
                .ToList();
            List<Conge> cg = new List<Conge>();
            foreach (var x in conges)
            {
                if (x.confirmation_conge == -1)
                {
                    cg.Add(x);
                }
            }
            return View(cg);
        }

        public ActionResult BtnRefuserConge(int id)
        {
            ViewBag.Listemployers = context.Employers.Where(x => x.archive_emp == 0).ToList();
            Conge conge = context.Conges.Find(id);
            return View(conge);
        }

        // POST: CongeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BtnRefuserConge(int id, Conge conge)
        {
            try
            {
                Conge conge1 = context.Conges.Find(id);
                conge1.confirmation_conge = -1;

                context.SaveChanges();
                ViewBag.modifier = " congé confirmer ";
                return RedirectToAction(nameof(RefuserConge));
            }
            catch
            {
                return View();
            }
        }
    }
}
