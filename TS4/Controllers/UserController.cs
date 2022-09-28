using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TS4.Areas.Identity.Data;

namespace TS4.Controllers
{
    [Authorize(Policy = "MustBeAuth")]
    public class UserController : Controller
    {
        public readonly UserContext _db;

        public UserController(UserContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            ViewBag.Users = users;
            return View(users);
        }

        /*[HttpPost]
        public IActionResult Index(List<User> hobbies)
        {
            IEnumerable<User> users = _db.Users;
            foreach(User user in hobbies)
            {
                user.Status = user.Status;
            }

            return View(users);
        }*/
        [HttpPost]
        public ActionResult Save(List<User> hobbies)
        {
            foreach (User hobby in hobbies)
            {
                User updatedHobby = _db.Users.ToList().Find(p => p.Id == hobby.Id);
                updatedHobby.Status = hobby.Status;
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
