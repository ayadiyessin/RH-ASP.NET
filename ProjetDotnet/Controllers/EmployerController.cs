using ProjetDotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProjetDotnet.Controllers
{
    [Authorize]
    public class EmployerController : Controller
    {
        private readonly GestionRHContext context;

        public EmployerController(GestionRHContext context)
        {
            this.context = context;
        }
        // GET: EmployerController
        public ActionResult Index()
        {
            List<Employer> employers = context.Employers
                .Include(x => x.Poste)
                .ToList();
            List<Employer> emp = new List<Employer>();
            List<int> nbT = new List<int>();
            List<int> nbF = new List<int>();
            foreach (var i in employers)
            {
                if (i.archive_emp == 0)
                {
                    nbT.Add (context.Taches.Where(x => x.employerId == i.Id_emp).Count());
                    nbF.Add(context.EmployerFormations.Where(x => x.employerId == i.Id_emp).Count());
                    emp.Add(i);
                }
            }
            ViewBag.CountTache = nbT;
            ViewBag.CountFormation = nbF;
            return View(emp);
        }

        // GET: EmployerController/Details/5
        public ActionResult Details(int id)
        {
            Employer employer = context.Employers
                .Include(x => x.Poste)
                .FirstOrDefault(x => x.Id_emp == id) ;
            return View(employer);
        }

        

        // GET: EmployerController/Create
        public ActionResult Create()
        {
            ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste== 0).ToList();
            return View();
        }

        // POST: EmployerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employer employer)
        {
            try
            {
                if (ModelState.IsValid)// verif 3andnechy des contrainte fi modaile (?) accepte valeur nul ou non 
                {
                    if (context.Employers.Where(x => x.cin_emp == employer.cin_emp).Count() > 0 )
                    {
                        ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste == 0).ToList(); // bech n3awed n3abi liste <select>
                        ViewBag.messageerror = "la cin de l'employer existe";
                        return View(employer);
                    }
                    else
                    {
                        if (context.Employers.Where(x => x.email_emp == employer.email_emp).Count() > 0)
                        {
                            ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste == 0).ToList(); // bech n3awed n3abi liste <select>
                            ViewBag.messageerror = "L'adresse e-mail de l'employer existe";
                            return View(employer);
                        }
                        else
                        {
                            context.Employers.Add(employer);
                            context.SaveChanges();
                            ViewBag.create = "employers ajoutée";
                            return RedirectToAction(nameof(Index));
                        }
                    }


                }
                ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste == 0).ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployerController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste == 0).ToList();
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }

        // POST: EmployerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employer employer)
        {
            try
            {
                Employer emp = context.Employers.Find(id);
                emp.cin_emp=employer.cin_emp;
                emp.nom_emp=employer.nom_emp;
                emp.prenom_emp=employer.prenom_emp;
                emp.date_naissance_emp = employer.date_naissance_emp;
                emp.sexe_emp=employer.sexe_emp;
                emp.adresse_emp=employer.adresse_emp;
                emp.numtell_emp=employer.numtell_emp;
                emp.email_emp=employer.email_emp;
                emp.date_embauche_emp = employer.date_embauche_emp;
                employer.psw_emp=employer.psw_emp;
                emp.ville_emp=employer.ville_emp;
                emp.Id_post=employer.Id_post;
                
                context.SaveChanges();
                ViewBag.modifier = " employer modifier ";
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployerController/Delete/5
        public ActionResult Delete(int id)
        {
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }

        // POST: EmployerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employer employer)
        {
            try
            {
                context.Employers.Remove(employer);
                context.SaveChanges();
                ViewBag.supprimer = "employer supprimer ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Archiver()
        {
            List<Employer> employers = context.Employers
                .Include(x => x.Poste)
                .ToList();
            List<Employer> emp = new List<Employer>();
            foreach (var x in employers)
            {
                if (x.archive_emp == 1)
                {
                    emp.Add(x);
                }
            }
            return View(emp);
        }

        public ActionResult EmpArchiver(int id)
        {
            ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste == 0).ToList();
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }

        // POST: EmployerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmpArchiver(int id, Employer employer)
        {
            try
            {
                Employer emp = context.Employers.Find(id);
                emp.archive_emp = 1;
                

                context.SaveChanges();
                ViewBag.modifier = " employer Archiver ";
                return RedirectToAction(nameof(Archiver));

            }
            catch
            {
                return View();
            }
        }

        public ActionResult EmpDesarchiver(int id)
        {
            ViewBag.Listpostes = context.Postes.Where(x => x.archive_poste == 0).ToList();
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }

        // POST: EmployerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmpDesarchiver(int id, Employer employer)
        {
            try
            {
                Employer emp = context.Employers.Find(id);
                emp.archive_emp =0;
                

                context.SaveChanges();
                ViewBag.modifier = " employer Desarchiver ";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
