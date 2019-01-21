using EventPlanning.Mvc.Models.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EventPlanning.Mvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class IssuedRewardsController : Controller
    {
        private EventPlanningContext db = new EventPlanningContext();

        // GET: IssuedRewards
        public ActionResult Index()
        {
            var issuedRewards = db.IssuedRewards.Include(i => i.Employee).Include(i => i.EventReward);
            return View(issuedRewards.ToList());
        }

        // GET: IssuedRewards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedReward issuedReward = db.IssuedRewards.Find(id);
            if (issuedReward == null)
            {
                return HttpNotFound();
            }
            return View(issuedReward);
        }

        // GET: IssuedRewards/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "AspNetUsersId");
            ViewBag.EventRewardId = new SelectList(db.EventRewards, "EventRewardId", "EventRewardId");
            return View();
        }

        // POST: IssuedRewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssuedRewardId,RemunerationDate,AmountRewardIssued,EventRewardId,EmployeeId")] IssuedReward issuedReward)
        {
            if (ModelState.IsValid)
            {
                db.IssuedRewards.Add(issuedReward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "AspNetUsersId", issuedReward.EmployeeId);
            ViewBag.EventRewardId = new SelectList(db.EventRewards, "EventRewardId", "EventRewardId", issuedReward.EventRewardId);
            return View(issuedReward);
        }

        // GET: IssuedRewards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedReward issuedReward = db.IssuedRewards.Find(id);
            if (issuedReward == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "AspNetUsersId", issuedReward.EmployeeId);
            ViewBag.EventRewardId = new SelectList(db.EventRewards, "EventRewardId", "EventRewardId", issuedReward.EventRewardId);
            return View(issuedReward);
        }

        // POST: IssuedRewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssuedRewardId,RemunerationDate,AmountRewardIssued,EventRewardId,EmployeeId")] IssuedReward issuedReward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issuedReward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "AspNetUsersId", issuedReward.EmployeeId);
            ViewBag.EventRewardId = new SelectList(db.EventRewards, "EventRewardId", "EventRewardId", issuedReward.EventRewardId);
            return View(issuedReward);
        }

        // GET: IssuedRewards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedReward issuedReward = db.IssuedRewards.Find(id);
            if (issuedReward == null)
            {
                return HttpNotFound();
            }
            return View(issuedReward);
        }

        // POST: IssuedRewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssuedReward issuedReward = db.IssuedRewards.Find(id);
            db.IssuedRewards.Remove(issuedReward);
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
