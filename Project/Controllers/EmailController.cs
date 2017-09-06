using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Mail;

namespace Project.Controllers
{
    public class EmailController : Controller
    {
       
        public ActionResult email()
        {
            return View();
        }
        [HttpPost]
        public ActionResult email(FormCollection fc)
        {
            string name = fc["name"];
            string email = fc["email"];
            string msg = fc["msg"];
            string subject="";


            string data = "";
            data+= name;
            data+= msg;

            email e = new email();
            e.SendEmail(email, subject,data);

            return View();
        }

    }
   
    }

