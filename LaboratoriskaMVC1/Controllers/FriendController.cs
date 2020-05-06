namespace LaboratoriskaMVC1.Controllers
{
    using LaboratoriskaMVC1.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Security.Cryptography.X509Certificates;
    using System.Web.Mvc;

    public class FriendController : Controller
    {
        private static List<Friend> friends = new List<Friend>() {
            new Friend(){ ID = 1, FriendId = 120, Ime = "Margarita", MastoZiveenje = "Skopje" },
            new Friend(){ ID = 2, FriendId = 12, Ime = "Nenad", MastoZiveenje = "Skopje" }
        };


        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FriendView()
        {
            return View(friends);
        }


        public ActionResult NewFriend()
        {
            int lastIndex = friends.Max(x => x.ID);
            Friend model = new Friend() { ID = lastIndex+1 };
            return View(model);
        }

        [HttpPost]
        public ActionResult NewFriend(Friend model)
        {
            Friend friend = friends.FirstOrDefault(x => x.FriendId == model.FriendId);
            if(friend != null)
            {
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            friends.Add(model);
            return View("FriendView", friends);

        }

        public ActionResult EditFriend(int number)
        {
            Friend friend = friends.First(x => x.ID == number);
            return View(friend);
        }

        [HttpPost]
        public ActionResult EditFriend(Friend model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Friend forUpdate = friends.First(x => x.ID == model.ID);
            forUpdate.FriendId = model.FriendId;
            forUpdate.Ime = model.Ime;
            forUpdate.MastoZiveenje = model.MastoZiveenje;

            return View("FriendView", friends);

        }

        public ActionResult DeleteFriend(int number)
        {
            Friend friend = friends.First(x => x.ID == number);
            friends.Remove(friend);
            return View("FriendView", friends);
        }

    }
}