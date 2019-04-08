using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using EventPlanning.Mvc.Models.Entities;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using EventPlanning.Mvc.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventPlanning.Mvc.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private const int CountColumnExcel = 8;
        private EventPlanningContext db = new EventPlanningContext();

        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public EventsController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Events
        public ActionResult Index(string sortOrder, string currentFilter, string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                var retCategoryQuery = from c in db.Events
                    orderby c.EventCategory.ToString()
                    select c.EventCategory.ToString();


                ViewBag.Category = new SelectList(retCategoryQuery);

                return View(db.Events.ToList());
            }

            ViewBag.CurrentFilter = category;

            var categoryQuery = from c in db.Events
                                orderby c.EventCategory.ToString()
                                select c.EventCategory.ToString();


            ViewBag.Category = new SelectList(categoryQuery);


            var events = from i in db.Events
                              select i;


            if (!string.IsNullOrEmpty(categoryQuery.ToString()))
            {
                events = events.Where(i => i.EventCategory.ToString() == category);
            }



            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CostSortParm = sortOrder == "cost" ? "cost_desc" : "cost";
            ViewBag.CategorySortParm = sortOrder == "category" ? "category_desc" : "category";

            switch (sortOrder)
            {
                case "name_desc":
                    events = events.OrderByDescending(i => i.EventTitle);
                    break;
                case "category":
                    events = events.OrderBy(i => i.EventCategory);
                    break;
                case "category_desc":
                    events = events.OrderByDescending(i => i.EventCategory);
                    break;
                case "cost":
                    events = events.OrderBy(i => i.EventDate);
                    break;
                case "cost_desc":
                    events = events.OrderByDescending(i => i.EventDate);
                    break;
                default:
                    events = events.OrderBy(i => i.EventTitle);
                    break;
            }

            return View(events);
        }

        // GET: Events/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            int currentAmountParticipants = 0;
            foreach (var employee in @event.Employees)
            {
                employee.FullName = db.FullNames.First(x => x.FullNameId == employee.FullNameId);
                employee.Position = db.Positions.First(x => x.PositionId == employee.PositionId);
                employee.Group = db.Groups.First(x => x.GroupId == employee.GroupId);
                currentAmountParticipants++;
            }

            var currentUserId = User.Identity.GetUserId();
            ViewBag.SignUp = @event.Employees.FirstOrDefault(e => e.AspNetUsersId == currentUserId) != null;

            var abilityToUnsubscribe = true;
            var rewards = new List<Reward>();
            foreach (var eventReward in db.EventRewards.Where(r => r.EventId == id).ToList())
            {
                var reward = db.Rewards.FirstOrDefault(r => r.RewardId == eventReward.RewardId);
                if (reward != null)
                {
                    rewards.Add(reward);
                }

                if (eventReward.IssuanceOnRequest)
                {
                    abilityToUnsubscribe = false;
                }
            }

            ViewBag.Message = (abilityToUnsubscribe) ? "" : "Unable to unsubscribe after recording!";
            ViewBag.Rewards = rewards;
            ViewBag.CurrentAmountParticipants = currentAmountParticipants;

            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", @event.EventId);
            }

            var abilityToUnsubscribe = true;
            var currentUserId = User.Identity.GetUserId();

            var currentEmployee = db.Employees.First(e => e.AspNetUsersId == currentUserId);
            @event = db.Set<Event>().Find(@event.EventId);

            var listEventRewards = db.EventRewards.Where(r => r.EventId == @event.EventId).ToList();
            for (var i = 0; i < listEventRewards.Count; i++)
            {
                if (listEventRewards[i].IssuanceOnRequest)
                {
                    abilityToUnsubscribe = false;
                    using (var dbEventReward = new EventPlanningContext())
                    {
                        listEventRewards[i] = dbEventReward.Set<EventReward>().Find(listEventRewards[i].EventRewardId);
                        double writeOffInQuantity;

                        if (@event.EventTitle.Contains("Children's New Year's gifts"))
                        {
                            writeOffInQuantity = currentEmployee.AmountChildren;
                            if (listEventRewards[i].AmountRewards >= writeOffInQuantity)
                            {
                                listEventRewards[i].AmountRewards -= writeOffInQuantity;
                                dbEventReward.Entry(listEventRewards[i]).State = EntityState.Modified;

                                var issuedReward = new IssuedReward
                                {
                                    AmountRewardIssued = writeOffInQuantity,
                                    EmployeeId = currentEmployee.EmployeeId,
                                    EventRewardId = listEventRewards[i].EventRewardId,
                                    RemunerationDate = DateTime.Now
                                };

                                dbEventReward.IssuedRewards.Add(issuedReward);
                                dbEventReward.SaveChanges();
                            }
                            else
                            {
                                ViewBag.Message = "Not enough in stock.";
                                return RedirectToAction("Details", @event.EventId);
                            }
                        }
                        else
                        {
                            writeOffInQuantity = listEventRewards[i].WriteOffInQuantity;
                            if (listEventRewards[i].AmountRewards >= writeOffInQuantity)
                            {
                                listEventRewards[i].AmountRewards -= writeOffInQuantity;
                                dbEventReward.Entry(listEventRewards[i]).State = EntityState.Modified;

                                var issuedReward = new IssuedReward
                                {
                                    AmountRewardIssued = writeOffInQuantity,
                                    EmployeeId = currentEmployee.EmployeeId,
                                    EventRewardId = listEventRewards[i].EventRewardId,
                                    RemunerationDate = DateTime.Now
                                };

                                dbEventReward.IssuedRewards.Add(issuedReward);
                                dbEventReward.SaveChanges();
                            }
                            else
                            {
                                ViewBag.Message = "Not enough in stock.";
                                return RedirectToAction("Details", @event.EventId);
                            }
                        }
                    }
                }
                else
                {
                    //Some code...
                    //
                }
            }

            if (@event.Employees.FirstOrDefault(e => e.AspNetUsersId == currentUserId) == null)
            {
                @event.Employees.Add(currentEmployee);
            }
            else
            {
                if (abilityToUnsubscribe)
                {
                    @event.Employees.Remove(currentEmployee);
                }
                else
                {
                    ViewBag.Message = "This event does not provide for cancellation of the application.";
                    return RedirectToAction("Details", @event.EventId);
                }
            }

            db.Entry(@event).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Details", @event.EventId);
        }

        public ActionResult ExportExcel(int? id)
        {
            using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Event staff");

                worksheet.Cell("A1").Value = "Last name";
                worksheet.Cell("B1").Value = "First name";
                worksheet.Cell("C1").Value = "Sure name";
                worksheet.Cell("D1").Value = "Group name";
                worksheet.Cell("E1").Value = "Position name";
                worksheet.Row(1).Style.Font.Bold = true;
                for (var i = 1; i < CountColumnExcel; i++)
                {
                    worksheet.Column(i).Width = 25;
                }

                var selectedEvent = db.Events.Find(id);
                var employees = selectedEvent.Employees.ToList();
                foreach (var employee in employees)
                {
                    employee.FullName = db.FullNames.First(x => x.FullNameId == employee.FullNameId);
                    employee.Position = db.Positions.First(x => x.PositionId == employee.PositionId);
                    employee.Group = db.Groups.First(x => x.GroupId == employee.GroupId);
                }

                //нумерация строк/столбцов начинается с индекса 1 (не 0)
                for (var i = 0; i < employees.Count; i++)
                {
                    worksheet.Column(i + 1).Width = 25;
                    worksheet.Cell(i + 2, 1).Value = employees[i].FullName.LastName;
                    worksheet.Cell(i + 2, 2).Value = employees[i].FullName.FirstName;
                    worksheet.Cell(i + 2, 3).Value = employees[i].FullName.SureName;
                    worksheet.Cell(i + 2, 4).Value = employees[i].Group.GroupName;
                    worksheet.Cell(i + 2, 5).Value = employees[i].Position.JobTitle;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = string.Join(string.Empty, selectedEvent.EventTitle, "_", selectedEvent.EventDate, ".xlsx")
                    };
                }
            }
        }

        // GET: Events/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            var employees = db.Employees.ToList();

            foreach (var employee in employees)
            {
                employee.FullName = db.FullNames.First(x => x.FullNameId == employee.FullNameId);
            }

            ViewBag.Employees = employees;
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventTitle,EventDate,RepeatEventType,EventDescription,EventVisible")] Event @event, 
            int[] selectedEmployees, HttpPostedFileBase upimage = null)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }

            if (selectedEmployees != null)
            {
                foreach (var e in db.Employees.Where(employee => selectedEmployees.Contains(employee.EmployeeId)))
                {
                    @event.Employees.Add(e);
                }
            }

            if (upimage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(upimage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(upimage.ContentLength);
                }

                @event.EventImage = imageData;
            }

            db.Events.Add(@event);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Events/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            var employees = db.Employees.ToList();
            foreach (var employee in employees)
            {
                employee.FullName = db.FullNames.First(x => x.FullNameId == employee.FullNameId);
            }

            ViewBag.Employees = db.Employees.ToList();

            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventTitle,EventDate,RepeatEventType,EventDescription,EventVisible")] Event @event,
            int[] selectedEmployees, HttpPostedFileBase upimage = null)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }

            using (var evDb = new EventPlanningContext())
            {
                var existingEmployee = evDb.Events.First(e => e.EventId == @event.EventId);
                existingEmployee.Employees.Clear();

                if (selectedEmployees != null)
                {
                    foreach (var e in evDb.Employees.Where(employee => selectedEmployees.Contains(employee.EmployeeId)))
                    {
                        existingEmployee.Employees.Add(e);
                    }
                }

                evDb.Entry(existingEmployee).State = EntityState.Modified;
                evDb.SaveChanges();
            }

            byte[] imageData = null;
            if (upimage != null)
            {
                using (var binaryReader = new BinaryReader(upimage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(upimage.ContentLength);
                }

                @event.EventImage = imageData;
            }
            else
            {
                using (var evDb = new EventPlanningContext())
                {
                    imageData = evDb.Events.First(e => e.EventId == @event.EventId).EventImage;
                }
                @event.EventImage = imageData;
            }

            db.Entry(@event).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Events/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
