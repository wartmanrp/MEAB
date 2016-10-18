using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MEAB.Models;

namespace MEAB.Controllers
{
    public class ArmyListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArmyLists
        public async Task<ActionResult> Index()
        {
            var armyLists = db.ArmyLists.Include(a => a.Creator).Include(a => a.Leader);
            return View(await armyLists.ToListAsync());
        }

        // GET: ArmyLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArmyList armyList = await db.ArmyLists.FindAsync(id);
            if (armyList == null)
            {
                return HttpNotFound();
            }
            return View(armyList);
        }

        // GET: ArmyLists/Create
        public ActionResult Create()
        {
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.LeaderId = new SelectList(db.Units, "Id", "Name");
            return View();
        }

        // POST: ArmyLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ArmyName,PointsLimit,LeaderId,CreatorId,Created,Updated")] ArmyList armyList)
        {
            if (ModelState.IsValid)
            {
                db.ArmyLists.Add(armyList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName", armyList.CreatorId);
            ViewBag.LeaderId = new SelectList(db.Units, "Id", "Name", armyList.LeaderId);
            return View(armyList);
        }

        // GET: ArmyLists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArmyList armyList = await db.ArmyLists.FindAsync(id);
            if (armyList == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName", armyList.CreatorId);
            ViewBag.LeaderId = new SelectList(db.Units, "Id", "Name", armyList.LeaderId);
            return View(armyList);
        }

        // POST: ArmyLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ArmyName,PointsLimit,LeaderId,CreatorId,Created,Updated")] ArmyList armyList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armyList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName", armyList.CreatorId);
            ViewBag.LeaderId = new SelectList(db.Units, "Id", "Name", armyList.LeaderId);
            return View(armyList);
        }

        // GET: ArmyLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArmyList armyList = await db.ArmyLists.FindAsync(id);
            if (armyList == null)
            {
                return HttpNotFound();
            }
            return View(armyList);
        }

        // POST: ArmyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ArmyList armyList = await db.ArmyLists.FindAsync(id);
            db.ArmyLists.Remove(armyList);
            await db.SaveChangesAsync();
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
