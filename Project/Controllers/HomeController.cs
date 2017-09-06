using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Project.EDM;
using System.Net.Mail;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        RestaurantDBEntities dc = new RestaurantDBEntities();
        [HttpPost]
        public ActionResult adminlogin(FormCollection fc)
        {
            string email = fc["f1"];
            string password = fc["f2"];

            if (email == "admin" && password == "12345")
            {
                return RedirectToAction("adminindex", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Index()
        {

            var p = dc.tblFoods.ToList();
            ViewData["foods"] = p;
            ViewBag.Title = "Index";
            //CATEGORY BREAKFAST

            var p1 = (from c in dc.tblCategories
                      from f in dc.tblFoods
                      where c.c_id == f.c_id && c.category_name == "BREAKFAST"
                      select new
                      {
                          f.f_name,
                          f.f_image,
                          f.f_price,
                          f.f_id,
                          f.f_description
                      }).ToList();
            List<cat> obj = new List<cat>();

            foreach (var item in p1)
            {
                cat obj1 = new cat();
                obj1.f_id = item.f_id;
                obj1.f_image = item.f_image;
                obj1.f_name = item.f_name;
                obj1.f_price = int.Parse(item.f_price.ToString());
                obj.Add(obj1);

            }
            ViewData["cat"] = obj;


            //CATEGORY LUNCH

            var p2 = (from c in dc.tblCategories
                      from f in dc.tblFoods
                      where c.c_id == f.c_id && c.category_name == "LUNCH"
                      select new
                      {
                          f.f_name,
                          f.f_image,
                          f.f_price,
                          f.f_id,
                          f.f_description
                      }).ToList();
            List<cat> obj2 = new List<cat>();

            foreach (var item in p2)
            {
                cat obj3 = new cat();
                obj3.f_id = item.f_id;
                obj3.f_image = item.f_image;
                obj3.f_name = item.f_name;
                obj3.f_price = int.Parse(item.f_price.ToString());
                obj2.Add(obj3);

            }
            ViewData["cat2"] = obj2;

            //CATEGORY ICE CREAM

            var p3 = (from c in dc.tblCategories
                      from f in dc.tblFoods
                      where c.c_id == f.c_id && c.category_name == "ICE CREAM"
                      select new
                      {
                          f.f_name,
                          f.f_image,
                          f.f_price,
                          f.f_id,
                          f.f_description
                      }).ToList();
            List<cat> obj5 = new List<cat>();

            foreach (var item in p3)
            {
                cat obj4 = new cat();
                obj4.f_id = item.f_id;
                obj4.f_image = item.f_image;
                obj4.f_name = item.f_name;
                obj4.f_price = int.Parse(item.f_price.ToString());
                obj5.Add(obj4);

            }
            ViewData["cat3"] = obj5;

            //CATEGORY DESSERTS

            var p4 = (from c in dc.tblCategories
                      from f in dc.tblFoods
                      where c.c_id == f.c_id && c.category_name == "ICE CREAM"
                      select new
                      {
                          f.f_name,
                          f.f_image,
                          f.f_price,
                          f.f_id,
                          f.f_description
                      }).ToList();
            List<cat> obj7 = new List<cat>();

            foreach (var item in p4)
            {
                cat obj6 = new cat();
                obj6.f_id = item.f_id;
                obj6.f_image = item.f_image;
                obj6.f_name = item.f_name;
                obj6.f_price = int.Parse(item.f_price.ToString());
                obj7.Add(obj6);

            }
            ViewData["cat4"] = obj7;

            return View();

        }
       
        public ActionResult search()
        {
            var p = (from n in dc.tblFoods select n).ToList();
            ViewData["search"] = p;
            return View();
        }
        [HttpPost]
        public JsonResult searchtext(string srchtext)
        {
            return Json(new { result = "Redirect", url = Url.Action("search", "Home", new { id = srchtext }) });

        }
        public ActionResult  aboutuspage()
        {
            return View();
        }

        public ActionResult gallary()
        {
            return View();
        }
        public ActionResult email()
        {
            return View();
        }
        [HttpPost]
        public ActionResult email(FormCollection fc)
        {
            string name = fc["name"];
            string emails = fc["email"];
            string msg = fc["msg"];
            string subject = "";

            string email = "foodc10@gmail.com";
            string data = "";
            data = emails + " :=";
            data += name;
            data += msg;

            email e = new email();
            e.SendEmail(email, subject, data);

            return View();
        }
        //for user
        [HttpGet]
        public ActionResult userregi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult userregi(FormCollection fc)
        {
            string uemail = fc["uemail"];
            var p = (from n in dc.tblUsers where n.user_email == uemail select n).Count();
            if (p == 0)
            {
                string uname = fc["uname"];
                string upwd = fc["upwd"];
                string uadd = fc["uadd"];
                string umobile = fc["umobile"];

                tblUser tbl = new tblUser();

                tbl.user_name = uname;
                tbl.user_email = uemail;
                tbl.user_pwd = upwd;
                tbl.user_address = uadd;
                tbl.user_mobile = umobile;
                tbl.user_status = "Pending";

                dc.tblUsers.Add(tbl);
                dc.SaveChanges();
                TempData["tmp"] = "<script>alert('Welcome to food corner');</script>";
                return Redirect(Url.Action("userindex", "User"));

            }
            else
            {
                TempData["u1"] = "User id already exist ! try different";
                return View();
            }
        }
        public ActionResult userlogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult userlogin(FormCollection fc)
        {
            
            string luemail = fc["t1"];
            string lupwd = fc["t2"];

            if (luemail == "abc" && lupwd == "123")
            {
                return Redirect(Url.Action("adminindex", "Admin"));
            }

            tblUser tbl = new tblUser();
            var p = (dc.tblUsers.Where(a => a.user_email == luemail && a.user_pwd == lupwd)).Count();
            //var q = (from n in dc.tblUsers where n.user_email == luemail && n.user_pwd == lupwd select n).Count();



            if (p == 1)
            {
                var q = (dc.tblUsers.Where(a => a.user_email == luemail && a.user_pwd == lupwd).FirstOrDefault());

                Session["userlogin"] = q.user_id;
                Session["uname"] = q.user_name;
                TempData["msg"] = "<script>alert('Your order successfully done....')<script>";
                return RedirectToAction("userindex", "User");

            }
            else
            {
                ViewBag.Message = "Invalid";
                return View();
            }


        }

        public ActionResult forgetpwd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult forgetpwd(FormCollection fc)
        {
            string email = fc["t1"];
            string phone = fc["t2"];


            var query = dc.tblUsers.Where(a => a.user_email == email && a.user_mobile == phone).Count();

            if (query == 1)
            {

                var p = dc.tblUsers.Where(c => c.user_email == email && c.user_mobile == phone).FirstOrDefault();


                string pwd;
                pwd = p.user_pwd;

                string data = "";
                string sub = "";
                data = "Your Password: " + pwd + "\r\nEmail: " + email + "\r\nMessage: ";

                email e = new email();
                e.SendEmail(email, sub, data);



                TempData["1"] = "<script>alert('Password Sent to your E-mail')</script>";
                return View();

            }


            else
            {
                TempData["1"] = "<script>alert('invalid..')</scirpt>";
                return View();
            }
        }
      
        public ActionResult logout()
        {
            Session["logout"] = null;
            return Redirect(Url.Action("Index", "Home"));
        }

        //public JsonResult checkuserlogin(string name,string pwd,FormCollection fc)
        //{
        //    name = fc["luemail"];
        //    pwd = fc["lupwd"];
        //    RestuarantEntities11 dc = new RestuarantEntities11();
        //    var login = dc.tblUsers.Where(s => s.user_email == name && s.user_pwd == pwd).FirstOrDefault();
        //    if (login!=null)
        //    {
        //        return Json(login.user_email, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json("Invalid user", JsonRequestBehavior.AllowGet);
        //}
        //for restuarant
        public ActionResult restregi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult restregi(FormCollection fc, HttpPostedFileBase file)
        {

            tblRestuarantRegistration rtbl = new tblRestuarantRegistration();

            var obj = dc.tblRestuarantRegistrations.Where(a => a.r_name.Equals(rtbl.r_name)).FirstOrDefault();
            if (obj != null)
            {
                Session["restid"] = obj.r_id.ToString();

                return RedirectToAction("Index", "Rest");

            }

            if (file != null)
            {
                string file1 = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/rest_img/"), file1);
                file.SaveAs(path);
                rtbl.rest_image = file1;
            }

            string remail = fc["remail"];
            var p = (from n in dc.tblRestuarantRegistrations where n.r_emailid == remail select n).Count();
            if (p == 0)
            {
                string runame = fc["runame"];
                string rdesc = fc["rdesc"];
                string rphno = fc["rphno"];
                string radd = fc["radd"];
                string rpwd = fc["rpwd"];



                rtbl.r_name = runame;
                rtbl.r_emailid = remail;
                rtbl.r_description = rdesc;
                rtbl.r_mobileno = rphno;
                rtbl.r_address = radd;
                rtbl.r_pwd = rpwd;
                rtbl.r_status = "Pending";

                dc.tblRestuarantRegistrations.Add(rtbl);
                dc.SaveChanges();
                TempData["tmp"] = "<script>alert('thanks for registration wait till admin cannot approve');</script>";

                return Redirect(Url.Action("Index", "Home"));

               // Session["new"] = "new";
            }
            else
            {
                TempData["u1"] = "User id already exist ! try different";

                return View();

            }
        }
        public ActionResult restlogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult restlogin(FormCollection fc)
        {

            string remail = fc["remail"];
            string rpwd = fc["rpwd"];

            tblRestuarantRegistration rtbl = new tblRestuarantRegistration();

            var p = (dc.tblRestuarantRegistrations.Where(r => r.r_emailid == remail && r.r_pwd == rpwd)).Count();


            if (p == 1)
            {

                //var pend = (from n in dc.tblRestuarantRegistrations where n.r_status == "Pending" select n).FirstOrDefault();

                //if (pend.r_status == "Pending")
                //{
                //    ViewBag.msg = "Your Registration is Pending";
                //}
                var q = (dc.tblRestuarantRegistrations.Where(c => c.r_emailid == remail && c.r_pwd == rpwd && c.r_status == "Approve")).Count();
                if (q == 1)
                {
                    var r = (dc.tblRestuarantRegistrations.Where(c => c.r_emailid == remail && c.r_pwd == rpwd && c.r_status == "Approve").FirstOrDefault());

                    Session["restlogin"] = r.r_name;
                    Session["img"] = r.rest_image;
                    Session["rid"] = r.r_id;
                    Session["lstlogin"] = r.r_lastdate;
                    return RedirectToAction("vieworder", "Rest");
                }
                else
                {
                    TempData["key1"] = "<script>alert('Invalid')</script>";

                    ViewBag.msg = "Try Again Invalid User";
                }

            }
            else
            {

                ViewBag.msg = "Try again Invalid User";

            }
            ModelState.AddModelError("", "Invalid");
            return View();

        }
        public ActionResult restlogout()
        {
            Session.Abandon();
            var p = DateTime.Now;

            tblRestuarantRegistration rt = new tblRestuarantRegistration();
            int id = int.Parse(Session["rid"].ToString());
            var m = dc.tblRestuarantRegistrations.Find(id);
            m.r_lastdate = p;
            dc.SaveChanges();
            return RedirectToAction("rlogin", "Home");
        }
        public ActionResult About()
        {
            var p = dc.tblCategories.ToList();
            ViewData["foods"] = p;
            return View();
        }




    }
    
    public class email
    {
        public string SendEmail(string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            string senderID = "foodc10@gmail.com";// use sender’s email id here..
            const string senderPassword = "aamss123"; // sender password here…
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                //ex.Message;
                
                result = "Error sending email.!!!";
            }
            return result;
        }
    }
    public class cat
    {
        public int f_id { get; set; }
        public int f_price { get; set; }
        public string f_name { get; set; }
        public string f_image { get; set; }

    }
}
