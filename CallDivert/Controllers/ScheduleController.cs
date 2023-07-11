using CallDivert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace CallDivert.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly CallDivertDbContext _dbContext;

        public ScheduleController(CallDivert.CallDivertDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult SaveEvent(string title, DateTime start, DateTime end)
        {
            // Logic to save the event to the database or perform any other required actions
            // You can access the title, start, and end parameters here

            // Return a response indicating the success or failure of the operation
            return Json(new { success = true });
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: User
        public IActionResult Create()
        {
            var userList = _dbContext.Users.ToList();
            ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View();
        }


        [HttpPost]
        public IActionResult Create(Schedule model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Schedules.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }

            // If the model is not valid, return the view with validation errors
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Schedule schedule = _dbContext.Schedules.SingleOrDefault(s => s.Id == id);
            var userList = _dbContext.Users.ToList(); 
            ViewBag.UserList = new SelectList(userList, "Id", "Name");
            if (schedule == null)
            {
                // If the schedule is not found, return a suitable response (e.g., error view or redirect)
                return NotFound();
            }

            // Pass the schedule to the view for editing
            return View(schedule);
        }

        [HttpPost]
        public IActionResult Update(Schedule updatedSchedule)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Schedules.Update(updatedSchedule);
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }

            // If the model state is not valid, return the edit view with validation errors
            return View("Edit", updatedSchedule);
        }


        // Helper method to update the user in the database
        private void UpdateUser(User updatedUser)
        {
             //_dbContext.Entry(updatedUser).State = EntityState.Modified;
             //_dbContext.SaveChanges();
        }

        public IActionResult List()
        {
            var list = _dbContext.Schedules.Include(s => s.User).ToList();
            return View(list);
        }

        public IActionResult Delete(int id)
        {
            Schedule schedule = _dbContext.Schedules.Find(id);

            if (schedule == null)
            {
                // If the schedule is not found, return a suitable response (e.g., error view or redirect)
                return NotFound();
            }

            _dbContext.Schedules.Remove(schedule);
            _dbContext.SaveChanges();

            // Redirect to the list view after successful deletion
            return RedirectToAction("List","Schedule");
        }

    }
}