using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Railway_Management_System.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace Railway_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext data;

        public HomeController(MyDbContext myDbContext)
        {
            data = myDbContext;
           
            
        }

        public void fetch_train()
        {

            var train = data.TrainMasters.ToList();
            var city = data.citiesAndStates.ToList();
            ViewData["Train"] = train;
            ViewData["City"] = city;
        }


        public IActionResult Index()
        {
            var cities = data.citiesAndStates.ToList();
            var train = data.TrainMasters.ToList();
            ViewData["Train"] = train;
            ViewData["City"] = cities;

 
            var populatedModel = new compositeModel
            {
                CitiesAndStates = cities,
                TrainMasters = train,

            };

            return View(populatedModel);
        }

        [HttpPost]
        public IActionResult CalculateFare([Bind("selectTrain", "fromCity", "toCity")] compositeModel trainData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View("FareCalculateResult", trainData);
          
        }


        public IActionResult fareCalculateResult()
        {
           
            return View();
        }

        [HttpPost]

        public IActionResult searchTrain([Bind("from","to", "trainDate")] compositeModel trainSearch)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.error = "All fields required";
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult bookAticket([Bind("passengerName, age, gender, totalPassengers, dateOfTravel, trainCategory, trainNumber")] passengersBooking booking)
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userName")))
            {
                TempData["error"] = "Sign in for booking";

                return View("Signin");

            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                data.passengerBooking.Add(booking);
                data.SaveChanges();

                TempData["msg"] = "Booking Confirmed";
                return View("Index");

            }

        }


        public IActionResult passengerBooking()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Signup()
        {
            fetch_train();

            return View();
        }

        [HttpPost]
        public IActionResult Signup(RMSpassengers passengers)
        {
            ModelState.Remove("Password");

            if (!ModelState.IsValid)
            {
                fetch_train();
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
                    HttpContext.Session.SetString("userName", passengers.User_name);

                    fetch_train();
                    return View("Signup");
                }
                else
                {
                    ViewBag.success = "Congratulation Account created! Your temporary password is 'rms123'";
                    passengers.Password = "rms123"; // Update the password as needed
                    data.Passengers.Add(passengers);
                    data.SaveChanges();
                    fetch_train();
                    HttpContext.Session.SetString("userName", passengers.User_name);

                }
                return View("Signup");
            }


        }

        public IActionResult Signin()
        {
            fetch_train();
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

                    if (HttpContext.Session.GetString("admin") != null)
                    {

                   String a=HttpContext.Session.GetString("admin");
                   TempData["Data"] = a;

                    return RedirectToAction("Admin");
                    }
                    

                }
                else
                {
                    fetch_train();
                    ViewBag.error = "Incorrect Username or Password";
                }
            }
            else
            {
                fetch_train();
                ViewBag.error = "User not found"; // Adjust the error message as needed
            }

            return View();
        }

        [HttpGet]
        public IActionResult user_logout()
        {
            if (HttpContext.Session.GetString("userName")!= null)
            {
                HttpContext.Session.Remove("userName");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult trainTimings()
        {
            return View();
        }

        public IActionResult stationSchedule()
        {
            return View();
        }

        public IActionResult userprofile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userName")))
            {
                ViewBag.error = "Access Denied, Signin First";

                return View("Signin");

            }

            return View();
        }






        /* Admin pannel function*/

        public IActionResult Admin()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                return View("Signin");
            }

            var user = data.Passengers.Count();
            ViewBag.user = user;
            ViewBag.error = "Sign in First";


            return View(user);
        }


        public IActionResult demi_user()
        {
            return View();
        }

       
        public IActionResult Update_user(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                return View("Signin");
            }
            var update = data.Passengers.Find(id);

            return View(update);
        }


        [HttpPost]
        public IActionResult Update_user(RMSpassengers rms)
        {


            if (ModelState.IsValid)
            {

                data.Passengers.Update(rms);
                data.SaveChanges();

                ViewBag.success = "User Recorde Update success";
                return RedirectToAction("show_user");
            }

            return View();

        }



        public IActionResult show_user()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                return View("Signin");
            }
            var userdata = data.Passengers.ToList();
            return View(userdata);
        }

        public IActionResult delete_user(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                return View("Signin");
            }

            var delete = data.Passengers.Find(id);
            data.Passengers.Remove(delete);
            data.SaveChanges();

            ViewBag.error = "User Recorde Delete success";

            return RedirectToAction("Alluser", "AdminController");
        }

        public IActionResult Add_train()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                return View("Signin");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add_train([Bind("trainName, status, routeCode, compartmentNo, trainCategory, departureTime, trainType")] trainMaster train)
        {
            
            if (ModelState.IsValid)
            {
                data.TrainMasters.Add(train);
                data.SaveChanges();

                TempData["msg"] = "Train Add Success";
                ViewBag.msg = "Train Uploaded";
            }

            return View();
        }


        public IActionResult Add_station()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                return View("Signin");
            }

            return View();
        }


        [HttpPost]
        public IActionResult Add_station(stationMaster station)
        {
            if (ModelState.IsValid)
            {
                data.StationMasters.Add(station);
                data.SaveChanges();

                ViewBag.msg = "Station Uploaded";

               return RedirectToAction("Add_station");
			}

            // If ModelState is not valid, return to the form with validation errors
            return View();
        }


        public IActionResult Admin_profile()
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                string a = HttpContext.Session.GetString("admin");
                var adminProfile = data.Passengers.FirstOrDefault(p => p.User_name == a && p.Role == "Admin");

                if (adminProfile != null)
                {
                 
                return View(adminProfile); 
                }
    
            }

            return View();
        }


        [HttpPost]
        public IActionResult Admin_profile(RMSpassengers passanger)
        {
            data.Passengers.Update(passanger);
            data.SaveChanges();

            return RedirectToAction("Admin_profile");
        }


        public IActionResult admin_logout()
        {
            if(HttpContext.Session.GetString("admin")!=null)
            {
                HttpContext.Session.Remove("admin");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Admin");

        }

        //CACULATE FARE METHOD 







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}