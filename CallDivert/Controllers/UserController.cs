using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallDivert.Models;


namespace CallDivert.Controllers
{
    public class UserController : Controller
    {
        private readonly CallDivertDbContext _dbContext;

        public UserController(CallDivert.CallDivertDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List","User");
        }

        // GET: User
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }

            // If the model is not valid, return the view with validation errors
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            // Retrieve the user from the database using the provided ID
            User user = _dbContext.Users.Find(id);

            if (user == null)
            {
                // If the user is not found, return a suitable response (e.g., error view or redirect)
                return NotFound();
            }

            // Pass the user to the view for editing
            return View(user);
        }


        [HttpPost]
        public IActionResult Update(User updatedUser)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Update(updatedUser);
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }

            // If the model state is not valid, return the edit view with validation errors
            return View("Edit", updatedUser);
        }

        // Helper method to update the user in the database
        private void UpdateUser(User updatedUser)
        {
             //_dbContext.Entry(updatedUser).State = EntityState.Modified;
             //_dbContext.SaveChanges();
        }

        public IActionResult List()
        {
            var userList = _dbContext.Users.ToList();
            return View(userList);
        }

        public IActionResult Delete(int id)
        {
            User user = _dbContext.Users.Find(id);

            if (user == null)
            {
                // If the user is not found, return a suitable response (e.g., error view or redirect)
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            // Redirect to the list view after successful deletion
            return RedirectToAction("List");
        }
    }
}