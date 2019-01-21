using EventPlanning.Mvc.Models.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EventPlanning.Mvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class EventRewardsController : Controller
    {
        private EventPlanningContext db = new EventPlanningContext();

        // GET: EventRewards
        public ActionResult Index()
        {
            var eventRewards = db.EventRewards.Include(e => e.Event).Include(e => e.Reward);
            return View(eventRewards.ToList());
        }

        // GET: EventRewards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var eventReward = db.EventRewards.Find(id);
            if (eventReward == null)
            {
                return HttpNotFound();
            }
            return View(eventReward);
        }

        // GET: EventRewards/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle");
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "AwardName");
            return View();
        }

        // POST: EventRewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventRewardId,AmountRewards,EventId,RewardId")] EventReward eventReward)
        {
            if (ModelState.IsValid)
            {
                db.EventRewards.Add(eventReward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventReward.EventId);
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "AwardName", eventReward.RewardId);
            return View(eventReward);
        }

        // GET: EventRewards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var eventReward = db.EventRewards.Find(id);
            if (eventReward == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventReward.EventId);
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "AwardName", eventReward.RewardId);
            return View(eventReward);
        }

        // POST: EventRewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventRewardId,AmountRewards,EventId,RewardId")] EventReward eventReward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventReward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventTitle", eventReward.EventId);
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "AwardName", eventReward.RewardId);
            return View(eventReward);
        }

        // GET: EventRewards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReward eventReward = db.EventRewards.Find(id);
            if (eventReward == null)
            {
                return HttpNotFound();
            }
            return View(eventReward);
        }

        // POST: EventRewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var eventReward = db.EventRewards.Find(id);
            db.EventRewards.Remove(eventReward);
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
