using EventPlanning.Mvc.Models.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EventPlanning.Mvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {
        private EventPlanningContext db = new EventPlanningContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.FullName).Include(e => e.Group).Include(e => e.Position);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.FullNameId = new SelectList(db.FullNames, "FullNameId", "LastName");
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "JobTitle");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FullNameId,PositionId,GroupId,Birthday,BiologicalFloor,Adress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FullNameId = new SelectList(db.FullNames, "FullNameId", "LastName", employee.FullNameId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", employee.GroupId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "JobTitle", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.FullNameId = new SelectList(db.FullNames, "FullNameId", "LastName", employee.FullNameId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", employee.GroupId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "JobTitle", employee.PositionId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FullNameId,PositionId,GroupId,Birthday,BiologicalFloor,Adress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FullNameId = new SelectList(db.FullNames, "FullNameId", "LastName", employee.FullNameId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", employee.GroupId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "JobTitle", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
