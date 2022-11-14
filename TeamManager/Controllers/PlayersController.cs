using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamManager.Interfaces;
using TeamManager.Models;
using TeamManager.Models.ViewModel;
using TeamManager.Services;

namespace TeamManager.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext db;
        private IPlayerService playerService;

        public PlayersController(ApplicationDbContext db, IPlayerService playerService)
        {
            this.db = db;
            this.playerService = playerService;
        }


        // GET: Players
        public ActionResult Index()
        {
            //Return all distinct Team names to the index view instead of all players
            return View(playerService.GetAllTeamNames());
        }

        public ActionResult GetPlayersOnTeam(string team)
        {
            var model = playerService.GetAllPlayersOnTeam(team);
            //Create the _PlayerListPartialView
            return PartialView("_PlayerListPartialView", model);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            var model = new PlayerCreateViewModel { TeamsDropDownItems = playerService.GetAllTeamNamesDropDown() };
            //Create the property TeamDropDownList by getting all distinct team names
            return View(model);
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,TeamName")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
           
            PlayerEditViewModel model = new PlayerEditViewModel {
                ID = player.ID,
                Name = player.Name,
                Age = player.Age,
                TeamName = player.TeamName,
                TeamsDropDownItems = playerService.GetAllTeamNamesDropDown()
            };

            //create the model to be passed to the view
            //Set TeamsDropDownItems equal to all distinct team names

            return View(model);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "ID,Name,Age,TeamName")] Player player)
        {

            //Change the Edit Function to return a JSON with the property 'text' equal to 'Success' should the request success, 'Something went wrong' otherwise
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new {text = "Success"});
            }
            return Json(new {text = "Something went wrong!"});
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
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
