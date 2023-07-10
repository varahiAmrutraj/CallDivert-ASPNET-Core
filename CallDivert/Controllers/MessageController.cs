using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallDivert.Models;


namespace CallDivert.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            // Call the SendMessage function from the SendMessages class
            CallDivert.AdditionalClasses.SendMessages.SendMessage(message);

            // Optionally, you can redirect the user to another page after sending the message
            return RedirectToAction("Message", "Message");
        }
    }
}