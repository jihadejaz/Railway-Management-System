using Microsoft.AspNetCore.Mvc;
using Railway_Management_System.Models;
using System.Diagnostics;


namespace Railway_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext data;
        public HomeController(MyDbContext myDbContext)
        {
            data = myDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Signup(RMSpassengers passengers)
        {
            ModelState.Remove("Password");

            if (!ModelState.IsValid)
            {
                return View("Signup");
            }
            else
            {
                var existingUser = data.Passengers.FirstOrDefault(u => u.User_name == passengers.User_name);
                if (existingUser != null)
                {
                    existingUser.remember_Me = passengers.remember_Me;

                    data.Passengers.Update(existingUser);
                    data.SaveChanges();
                    ViewBag.success = "Record Updated Successfully";

                    return View("Signup");
                }
                else
                {
                    ViewBag.success = "Congratulation Account created! Your temporary password is 'rms123'";
                    passengers.Password = "rms123"; // Update the password as needed
                    data.Passengers.Add(passengers);
                    data.SaveChanges();

                }
                return View("Signup");
            }


        }

        public IActionResult Signin()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Signin(string username, string password)
        {
            var verify = data.Passengers.FirstOrDefault(u => u.User_name == username);

            if (verify != null)
            {
                if (verify.Role == "User" && verify.Password == password)
                {
                    HttpContext.Session.SetString("userName", verify.User_name);

                    return RedirectToAction("Index");
                }
                else if (verify.Role == "Admin" && verify.Password == password)
                {
                    HttpContext.Session.SetString("admin", verify.User_name);

                    return RedirectToAction("Admin");
                }
                else
                {
                    ViewBag.error = "Incorrect Username or Password";
                }
            }
            else
            {
                ViewBag.error = "User not found"; 
            }

            return View();
        }

        //USER PROFILE METHOD
        public IActionResult myAccount(string username)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userName")))
            {
                ViewBag.error = "Please Login First";
                return View("Signin"); 
            }

            if (!string.IsNullOrEmpty(username))
            {
                var user = data.Passengers.FirstOrDefault(u => u.User_name == username);

                if (user != null) 
                {
                    ViewBag.success = "User found";
                    return View("myAccount", user);
                }else
                {

                }
            }

            ViewBag.Error = "404 'No user found'";
            return View("myAccount");
        }

        public IActionResult complaintFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult complaintFile(RMScomplaints complaints)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userName")))
            {
                ViewBag.error = "Please Login First";
                return View("Signin");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewBag.success = "Complaint has been filed";
            data.complaints.Add(complaints);
            data.SaveChanges();
            return View();
        }


        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}