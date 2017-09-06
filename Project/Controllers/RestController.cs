using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.EDM;

namespace Project.Controllers
{
    public class RestController : Controller
    {
        //
        // GET: /Rest/  
        RestaurantDBEntities dc = new RestaurantDBEntities();
        public ActionResult vieworder()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {

                int id = int.Parse(Session["rid"].ToString());
                var query = (from o in dc.tblOrders  //contains userid,order_Status,fid
                             from r in dc.tblRestuarantRegistrations  //contains r_id
                             from u in dc.tblUsers // optional userid
                             from f in dc.tblFoods //fid and rid


                             where f.f_id == o.f_id && o.o_userid == u.user_id && r.r_id == id && o.o_status.Contains("Pending")

                             select new
                             {
                                 u.user_name,
                                 f.f_name,
                                 f.f_image,
                                 o.o_quantity,
                                 o.o_date,
                                 r.r_id,
                                 o.o_price,
                                 o.o_status,
                                 o.serial_no,
                                 o.o_id,

                             }).ToList();

                List<orders> obj = new List<orders>();
                foreach (var item in query)
                {
                    orders obj1 = new orders();
                    obj1.username = item.user_name;
                    obj1.serialno = item.serial_no;
                    obj1.foodname = item.f_name;
                    obj1.image = item.f_image;
                    obj1.orderquantity = int.Parse(item.o_quantity);
                    obj1.orderprice = Decimal.Parse(item.o_price.ToString());
                    obj1.orderstatus = item.o_status;
                    obj1.order_id = int.Parse((item.o_id).ToString());
                    obj.Add(obj1);

                }
                ViewData["p"] = dc.tblDeliveryboys.Where(a => a.db_status == "Pending").ToList();
                ViewData["viewo"] = obj;
                return View();
            }
        }
        [HttpPost]
        public ActionResult vieworder(FormCollection fc)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                int id = int.Parse(Session["rid"].ToString());


                tblDeliveryAssign tbl = new tblDeliveryAssign();
                int serial = int.Parse(fc["h1"].ToString());
                var pp = (from n in dc.tblOrders where n.serial_no == serial select n).FirstOrDefault();
                tbl.orderid = pp.o_id;
                tbl.db_id = int.Parse(fc["drp"].ToString());
                tbl.r_id = id;
                tbl.da_date = DateTime.Now;


                pp.o_status = "Delivered";
                dc.tblDeliveryAssigns.Add(tbl);
                dc.SaveChanges();

                return RedirectToAction("vieworder", "Rest");
            }
        }
        //public ActionResult assignedorders(int id)
        //{

        //    tblOrder p = (from n in dc.tblOrders
        //                  where n.o_id == id
        //                  select n).FirstOrDefault();


        //    p.o_status = "Delivered";

        //    dc.SaveChanges();

        //    ViewData["p"] = dc.tblDeliveryboys.Where(a => a.db_status == "Pending").ToList();
        //    ViewData["p1"] = p;

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult assignedorders(FormCollection fc)
        //{
        //    int rid = int.Parse(Session["rid"].ToString());
        //    tblDeliveryAssign tbl = new tblDeliveryAssign();
        //    tblOrder tbl1 = new tblOrder();

        //    tbl.orderid = int.Parse(fc["oid"]);
        //    tbl.r_id = rid;
        //    tbl.db_id = int.Parse(fc["drp"]);
        //    tbl.da_date = DateTime.Now;


        //    dc.tblDeliveryAssigns.Add(tbl);
        //    dc.SaveChanges();


        //    return RedirectToAction("vieworder", "Rest");
        //}
        public ActionResult Index()
        {
            if (Session["rid"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("restlogin", "Home");
            }
        }
        public ActionResult viewpro()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                int id = int.Parse(Session["rid"].ToString());
                ViewData["temp"] = dc.tblRestuarantRegistrations.Find(id);
                return View();
            }
        }
        public ActionResult editpro()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                int rid = Convert.ToInt16(Session["rid"]);
                tblRestuarantRegistration rtbl = dc.tblRestuarantRegistrations.Find(rid);
                var p = (dc.tblRestuarantRegistrations.Where(c => c.r_id == rid)).ToList();
                ViewData["editpro"] = rtbl;
                ViewData["vf"] = p;
                dc.SaveChanges();

                return View();
            }
        }
        [HttpPost]
        public ActionResult editproo(FormCollection fc)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {

                int id = int.Parse(fc["h1"]);
                var p = dc.tblRestuarantRegistrations.Find(id);
                p.r_name = fc["t1"];
                p.r_mobileno = fc["t2"];
                p.r_emailid = fc["t3"];
                p.r_description = fc["t4"];


                dc.SaveChanges();

                return RedirectToAction("viewpro", "Rest");
            }
        }


        public ActionResult fdetails()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                int id = int.Parse(Session["rid"].ToString());
                var p = (from l in dc.tblCategories
                         from f in dc.tblFoods
                         from r in dc.tblRestuarantRegistrations
                         where f.c_id == l.c_id && r.r_id == f.r_id && f.r_id == id && r.r_id == id
                         select new
                         {
                             f.f_id,
                             f.f_name,
                             f.f_price,
                             f.f_date,
                             f.f_description,
                             f.r_id,
                             f.f_image,

                             l.category_name
                         });

                List<foods> list = new List<foods>();

                foreach (var item in p)
                {
                    foods obj = new foods();
                    obj.f_id = item.f_id;
                    //obj.subcategory_name = item.subcategory_name;
                    obj.food_name = item.f_name;
                    obj.category_name = item.category_name;
                    obj.food_price = int.Parse((item.f_price).ToString());
                    obj.food_description = item.f_description;
                    obj.food_image = item.f_image;
                    obj.food_date = item.f_date.ToString();

                    list.Add(obj);

                }
                ViewData["fdetails"] = list;
                return View();
            }
        }
        public ActionResult fsdetail()
        {

            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                var data = dc.tblSpecials.ToList();
                ViewData["spc"] = data;
                return View();
            }

        }
        public ActionResult addfood()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                ViewData["temp"] = dc.tblCategories.ToList();
                ViewData["temp1"] = dc.tblSubcategories.ToList();
                return View();
            }
        }
        [HttpPost]
        public ActionResult addfood(FormCollection fc, HttpPostedFileBase file)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                tblFood tblfood = new tblFood();

                if (file != null)
                {
                    string file1 = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/fdimg/"), file1);
                    file.SaveAs(path);
                    tblfood.f_image = file1;
                }


                string fname = fc["fname"];
                int fci = int.Parse(fc["drp"]);
                //int fsi = int.Parse(fc["drp1"]);
                int fprice = int.Parse(fc["fprice"]);
                DateTime fdate = DateTime.Now;
                string fdesc = fc["fdesc"];
                int rid = int.Parse(Session["rid"].ToString());


                tblfood.f_name = fname;
                tblfood.c_id = fci;
                //tblfood.f_date = (fdate).ToLongDateString();
                //tblfood.s_id = fsi;
                tblfood.f_price = fprice;
                tblfood.f_description = fdesc;
                tblfood.r_id = rid;
                ViewData["temp"] = dc.tblCategories.ToList();
                ViewData["temp1"] = dc.tblSubcategories.ToList();

                dc.tblFoods.Add(tblfood);
                dc.SaveChanges();
                return View();
            }
        }
        [HttpPost]
        //for add food
        public JsonResult getdata(int id)
        {
            //return Json(p.tblCategories.ToList(), JsonRequestBehavior.AllowGet);

            var p = (from n in dc.tblSubcategories
                     from m in dc.tblCategories
                     where n.c_id == id && m.c_id == n.c_id
                     select new { n.subcategory_name, n.s_id }).ToList();


            return Json(p, JsonRequestBehavior.AllowGet);
        }

        public ActionResult editfood(int id)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                ViewData["temp"] = dc.tblCategories.ToList();
                var p = dc.tblFoods.Find(id);

                var c = dc.tblCategories.ToList();
                int cmt = 0;
                foreach (var item in c)
                {

                    if (p.c_id == item.c_id)
                    {
                        break;
                    }
                    else
                    {

                        cmt++;
                    }

                }
                ViewBag.msg = cmt;

                ViewData["e1"] = p;


                return View();
            }
        }

        //for edit food
        //public JsonResult getdata1(int id)
        //{
        //    //return Json(p.tblCategories.ToList(), JsonRequestBehavior.AllowGet);

        //    var p = (from n in dc.tblSubcategories
        //             from m in dc.tblCategories
        //             where n.c_id == id && m.c_id == n.c_id
        //             select new { n.subcategory_name, n.s_id }).ToList();

        //    return Json(p, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult editfood(FormCollection fc)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                string fname = fc["fname"];
                int drp1 = int.Parse(fc["drp1"]);
                //int drp2 = int.Parse(fc["drp2"]);
                string price = fc["price"];
                DateTime date = DateTime.Parse(fc["date"]);
                string image = fc["image"];
                string desc = fc["desc"];
                int fid = int.Parse(fc["fid"]);
                var p = dc.tblFoods.Find(fid);


                p.f_name = fname;
                p.c_id = drp1;
                //p.s_id = drp2;
                p.f_price = int.Parse(price);

                p.f_image = image;
                p.f_description = desc;
                // TempData["temp"] = dc.tblCategories.ToList();
                //ViewData["temp1"] = dc.tblSubcategories.ToList();



                dc.SaveChanges();
                return Redirect(Url.Action("fdetails", "Rest"));
            }
        }

        public ActionResult deletefood(int id)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                var a = dc.tblFoods.Find(id);
                dc.tblFoods.Remove(a);
                dc.SaveChanges();
                return RedirectToAction("fdetails", "Rest");
            }
        }

        public ActionResult detailfood(FormCollection fc)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                var p = (from n in dc.tblSubcategories
                         from l in dc.tblCategories
                         from f in dc.tblFoods
                         where f.c_id == l.c_id && f.s_id == n.s_id
                         select new

                         {
                             f.f_id,
                             f.f_name,
                             f.f_price,
                             f.f_date,
                             f.f_description,

                             n.subcategory_name,
                             l.category_name
                         });

                List<foods> list = new List<foods>();

                foreach (var item in p)
                {
                    foods obj = new foods();
                    obj.f_id = item.f_id;

                    obj.food_name = item.f_name;
                    obj.category_name = item.category_name;
                    obj.food_price = int.Parse((item.f_price).ToString());
                    obj.food_description = item.f_description;
                    obj.food_date = item.f_date.ToString();
                    list.Add(obj);

                }
                ViewData["dtl"] = p;
                return View();
            }
        }
        public ActionResult dbdetail()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                int id = int.Parse(Session["rid"].ToString());

                var p = (from n in dc.tblDeliveryboys
                         where n.r_id == id
                         select n);

                ViewData["db"] = p.ToList();

                return View();
            }
        }
        [HttpGet]
        public ActionResult adddb()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult adddb(FormCollection fc)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                tblDeliveryboy tbl = new tblDeliveryboy();
                string fname = fc["t1"];
                string mob = fc["t2"];

                tbl.db_name = fname;
                tbl.db_mobile = mob;
                tbl.db_status = "Pending";
                int p = Convert.ToInt16(Session["rid"]);
                tbl.r_id = p;

                dc.tblDeliveryboys.Add(tbl);
                dc.SaveChanges();

                return View();
            }
        }

        public ActionResult specials()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult addspecials()
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                ViewData["temp1"] = dc.tblFoods.ToList();

                ViewData["temp"] = dc.tblFoods.ToList();
                return View();
            }
        }
        [HttpPost]
        public JsonResult getdata1(int id)
        {
            var p = (from n in dc.tblFoods
                     where n.f_id == id
                     select new { n.f_price, n.f_id }).ToList();
            return Json(p, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult addspecials(FormCollection fc, HttpPostedFileBase file)
        {
            if (Session["rid"] == null)
            {
                return RedirectToAction("restlogin", "Home");
            }
            else
            {
                tblSpecial tblfood = new tblSpecial();

                if (file != null)
                {
                    string file1 = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/spcimg/"), file1);
                    file.SaveAs(path);
                    tblfood.offer_image = file1;
                }


                string fname = fc["fname"];
                //int fci = int.Parse(fc["drp"]);
                string old = fc["oprice"];
                int fprice = int.Parse(fc["fprice"]);
                DateTime fsdate = DateTime.Parse(fc["fdate"]);
                DateTime fedate = DateTime.Parse(fc["fdate1"]);
                string fdesc = fc["fdesc"];
                int rid = int.Parse(Session["rid"].ToString());


                tblfood.f_name = fname;
                //tblfood.c_id = fci;
                tblfood.oldprice = old;
                tblfood.offer_price = fprice;
                tblfood.start_date = fsdate;
                tblfood.end_date = fedate;
                tblfood.offer_desc = fdesc;
                tblfood.r_id = rid;
                tblfood.status = "Active";
                ViewData["temp"] = dc.tblFoods.ToList();
                ViewData["temp1"] = dc.tblFoods.ToList();

                dc.tblSpecials.Add(tblfood);
                dc.SaveChanges();
            }
            return View();
        }
      
    }

    public class foods
    {

        public string food_name { get; set; }
        public string food_code { get; set; }
        public string food_image { get; set; }
        public int food_price { get; set; }
        public string category_name { get; set; }
        //public string subcategory_name { get; set; }
        public string food_description { get; set; }
        public string food_date { get; set; }
        public int f_id { get; set; }
        public string r_name { get; set; }
    }

    public class oldorders
    {
        public string username { get; set; }
        public int cart_id { get; set; }
        public int quantity { get; set; }
        public string deliverytime { get; set; }
        public string status { get; set; }

    }

    public class orders
    {
        public int order_id { get; set; }
        public string username { get; set; }
        public string foodname { get; set; }
        public string image { get; set; }
        public decimal orderquantity { get; set; }
        public decimal orderprice { get; set; }
        public DateTime date { get; set; }
        public string orderstatus { get; set; }
        public string rest_name { get; set; }
        public string paymentstatus { get; set; }
        public int serialno { get; set; }
    }
}
