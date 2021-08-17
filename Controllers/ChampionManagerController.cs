using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Stateemo.Data;
using Stateemo.Models;
using PagedList;

namespace Stateemo.Controllers
{

    public class ChampionManagerController : Controller
    {
        private StateemoContext db = new StateemoContext();
        private ApplicationDbContext db2 = new ApplicationDbContext();
        private ApplicationUser user = new ApplicationUser();
        [AllowAnonymous]
        //GET: ChampionManager
        /*public ActionResult Index()
        {
            var championModels = db.ChampionModels.Include(c => c.Role);
            return View(championModels.ToList());
        }*/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int ?page, int ?pagesize)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RoleSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var championModels = from c in db.ChampionModels
                           select c;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {   
                searchString = currentFilter;
            }

            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Value="4", Text= "4" },
                new SelectListItem() { Value="8", Text= "8" },
                new SelectListItem() { Value="12", Text= "12" },
            };

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                championModels = championModels.Where(c => c.Name.Contains(searchString)
                                       || c.Role.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    championModels = championModels.OrderByDescending(c => c.Name);
                    break;
                case "Date":
                    championModels = championModels.OrderBy(c => c.Role.Name);
                    break;
                case "date_desc":
                    championModels = championModels.OrderByDescending(c => c.Role.Name);
                    break;
                default:
                    championModels = championModels.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = (pagesize ?? 4);
            //int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(championModels.ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
        // GET: ChampionManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionModel championModel = db.ChampionModels.Find(id);
            if (championModel == null)
            {
                return HttpNotFound();
            }
            return View(championModel);
        }

        // GET: ChampionManager/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.RoleModels, "Id", "Name");
            return View();
        }

        // POST: ChampionManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,Name,Title,IconURL,Ranged,AttackDamage,Health,HealthRegen,Mana,ManaRegen,Armor,MagicResist,MovementSpeed")] ChampionModel championModel)
        {
            if (ModelState.IsValid)
            {
                db.ChampionModels.Add(championModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.RoleModels, "Id", "Name", championModel.RoleId);
            return View(championModel);
        }
        
        // GET: ChampionManager/Edit/5
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionModel championModel = db.ChampionModels.Find(id);
            if (championModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.RoleModels, "Id", "Name", championModel.RoleId);
            return View(championModel);
        }

        // POST: ChampionManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,Name,Title,IconURL,Ranged,AttackDamage,Health,HealthRegen,Mana,ManaRegen,Armor,MagicResist,MovementSpeed")] ChampionModel championModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(championModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.RoleModels, "Id", "Name", championModel.RoleId);
            return View(championModel);
        }

        // GET: ChampionManager/Delete/5
        [Authorize (Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionModel championModel = db.ChampionModels.Find(id);
            if (championModel == null)
            {
                return HttpNotFound();
            }
            return View(championModel);
        }

        // POST: ChampionManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChampionModel championModel = db.ChampionModels.Find(id);
            db.ChampionModels.Remove(championModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Favourite(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionModel championModel = db.ChampionModels.Find(id);
            if (championModel == null)
            {
                return HttpNotFound();
            }
            string UserId = User.Identity.GetUserId();
            ApplicationUser AppUser = db2.Users.Find(UserId);
            FavouriteModel FavouriteChamp = new FavouriteModel(id, championModel, UserId, AppUser);

            return View(FavouriteChamp);
        }

        //POST ChampionManager/Favourite/5
        [HttpPost, ActionName("Favourite")]
        [ValidateAntiForgeryToken]
        public ActionResult FavouriteConfirmed(int id)
        {

            string  UserId = User.Identity.GetUserId();
            ChampionModel championModel = db.ChampionModels.Find(id);
            ApplicationUser AppUser = db2.Users.Find(UserId);
            FavouriteModel FavouriteChamp = new FavouriteModel(id, championModel, UserId, AppUser);
            //AppUser.Favourites.Add(FavouriteChamp);
            db2.Users.Find(UserId).Favourites.Add(FavouriteChamp);
            //db2.Users.Find(UserId).FavouritesIds.Add(FavouriteChamp.Id);   
            db2.SaveChanges();
            return RedirectToAction("Favourites", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
