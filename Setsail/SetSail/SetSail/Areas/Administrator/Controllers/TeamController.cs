using SetSail.DAL;
using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Areas.Administrator.Controllers
{
    public class TeamController : Controller
    {
        // GET: Administrator/Team
        SetSailContext db = new SetSailContext();


        //Position CRUD START//


        public ActionResult PositionIndex()
        {
            List<Position> positions = db.Positions.ToList();
            return View(positions);
        }
        public ActionResult PositionCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PositionCreate(Position pos)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(pos);
                db.SaveChanges();

                return RedirectToAction("PositionIndex");
            }

            return View(pos);
        }

        public ActionResult PositionUpdate(int id)
        {
            Position pos = db.Positions.Find(id);
            if (pos == null)
            {
                return HttpNotFound();
            }

            return View(pos);
        }

        [HttpPost]
        public ActionResult PositionUpdate(Position pos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PositionIndex");
            }

            return View(pos);
        }

        public ActionResult PositionDelete(int id)
        {
            Position pos = db.Positions.Find(id);
            if (pos == null)
            {
                return HttpNotFound();
            }

            db.Positions.Remove(pos);
            db.SaveChanges();

            return RedirectToAction("PositionIndex");
        }

        //Position CRUD END//

        // Team CRUD START//

        public ActionResult Index()
        {
            List<Team> teams = db.Teams.Include("Position").ToList();
            return View(teams);
        }
        public ActionResult Create(int? id)
        {
            ViewBag.Categories = db.Positions.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                if (team.PhotoFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(team);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + team.PhotoFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                team.PhotoFile.SaveAs(imagePath);
                team.Photo = imageName;

                db.Teams.Add(team);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.Positions.ToList();
            return View(team);
        }
        public ActionResult Update(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Positions.ToList();
            return View(team);
        }

        [HttpPost]
        public ActionResult Update(Team team)
        {
            if (ModelState.IsValid)
            {
                Team teamm = db.Teams.Find(team.Id);

                if (team.PhotoFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + team.PhotoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), teamm.Photo);
                    System.IO.File.Delete(OldImagePath);

                    team.PhotoFile.SaveAs(imagePath);
                    teamm.Photo = imageName;
                }

                teamm.Fullname = team.Fullname;
                teamm.About = team.About;
                teamm.PositionId = team.PositionId;

                db.Entry(teamm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.Positions.ToList();
            return View(team);
        }

        public ActionResult Delete(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Team CRUD END//

        // Team SOCIAL CRUD START //

        public ActionResult TeamSocialIndex()
        {
            List<TeamSocial> tsocials = db.TeamSocials.Include("Team").Include("Team.Position").ToList();
            return View(tsocials);
        }
        public ActionResult TeamSocialCreate(int? id)
        {
            ViewBag.Categories = db.Teams.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult TeamSocialCreate(TeamSocial tsocial)
        {
            if (ModelState.IsValid)
            {
                db.TeamSocials.Add(tsocial);
                db.SaveChanges();

                return RedirectToAction("TeamSocialIndex");
            }
            ViewBag.Categories = db.Teams.ToList();
            return View(tsocial);
        }
        public ActionResult TeamSocialUpdate(int id)
        {
            TeamSocial tsocial = db.TeamSocials.Find(id);
            if (tsocial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Teams.ToList();
            return View(tsocial);
        }

        [HttpPost]
        public ActionResult TeamSocialUpdate(TeamSocial tsocial)
        {
            if (ModelState.IsValid)
            {
                TeamSocial tsocialy = db.TeamSocials.Find(tsocial.Id);

                tsocialy.Icon = tsocial.Icon;
                tsocialy.Link = tsocial.Link;
                tsocialy.TeamId = tsocial.TeamId;

                db.Entry(tsocialy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TeamSocialIndex");
            }

            ViewBag.Categories = db.Teams.ToList();
            return View(tsocial);
        }

        public ActionResult TeamSocialDelete(int id)
        {
            TeamSocial tsocial = db.TeamSocials.Find(id);
            if (tsocial == null)
            {
                return HttpNotFound();
            }

            db.TeamSocials.Remove(tsocial);
            db.SaveChanges();

            return RedirectToAction("TeamSocialIndex");
        }


        // Team SOCIAL CRUD END //
    }
}