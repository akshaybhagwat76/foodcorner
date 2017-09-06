using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.EDM;
using System.Net.Mail;

namespace Project.Controllers
{
    public class UserController : Controller
    {

        RestaurantDBEntities dc = new RestaurantDBEntities();

        public ActionResult userindex()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
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
                List<cat2> obj2 = new List<cat2>();

                foreach (var item in p2)
                {
                    cat2 obj3 = new cat2();
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
                List<cat3> obj5 = new List<cat3>();

                foreach (var item in p3)
                {
                    cat3 obj4 = new cat3();
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
                List<cat4> obj7 = new List<cat4>();

                foreach (var item in p4)
                {
                    cat4 obj6 = new cat4();
                    obj6.f_id = item.f_id;
                    obj6.f_image = item.f_image;
                    obj6.f_name = item.f_name;
                    obj6.f_price = int.Parse(item.f_price.ToString());
                    obj7.Add(obj6);

                }
                ViewData["cat4"] = obj7;

                return View();
            }
        }
        public ActionResult single_food(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                ViewBag.Title = "single";
                ViewData["s1"] = dc.tblRestuarantRegistrations.ToList();
                ViewData["state"] = dc.tblStates.ToList();
                ViewData["city"] = dc.tblCities.ToList();
                ViewData["area"] = dc.tblAreas.ToList();


                var p1 = dc.tblFoods.Where(p => p.f_id == id).ToList();
                ViewData["p"] = p1;

                var fid = int.Parse(Request.QueryString["id2"].ToString());
                var uid = int.Parse(Session["userlogin"].ToString());
                var query = (from n in dc.tblCarts
                             where n.user_id == uid && n.f_id == fid
                             select n).Count();

                ViewData["qcnt"] = query;


                //var img = Request.QueryString["img"];
                //var name = Request.QueryString["n2"];
                //var desc = Request.QueryString["d"];
                //var price = Request.QueryString["price"];
                //var id2 = Request.QueryString["id2"];


                //ViewData["img"] = img;
                //ViewData["name"] = name;
                //ViewData["d"] = desc;

                //ViewData["price"] = price;
                //ViewData["id"] = id2;



                return View();
            }
        }

        public ActionResult search1()
        {
            var p = (from n in dc.tblFoods select n).ToList();
            ViewData["search"] = p;
            return View();
        }
        [HttpPost]
        public JsonResult searchtext(string srchtext)
        {
            return Json(new { result = "Redirect", url = Url.Action("search1", "User", new { id = srchtext }) });

        }



        public ActionResult special()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var p = dc.tblSpecials.ToList();
                ViewData["spc"] = p;
                ViewBag.Title = "Index";
                return View();
            }
        }
        public ActionResult readspecial(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var p1 = dc.tblSpecials.Where(p => p.offer_id == id).ToList();
                ViewData["p"] = p1;

                return View();
            }
        }
        public ActionResult viewrest()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {

                var p2 = dc.tblRestuarantRegistrations.ToList();
                ViewData["p"] = p2;
                return View();
            }
        }
        public ActionResult readrest(int id)
        {
            var p1 = dc.tblRestuarantRegistrations.Where(p => p.r_id == id).ToList();
            ViewData["p"] = p1;

            return View();
        }
        public ActionResult orderstatus()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int id = int.Parse(Session["userlogin"].ToString());
                var p = (from f in dc.tblFoods
                         from u in dc.tblUsers
                         from o in dc.tblOrders


                         where o.f_id == f.f_id && u.user_id == id && o.o_userid == id
                         select new { f.f_id, o.o_id, f.f_image, o.o_quantity, f.f_name, o.o_status, f.f_price, o.o_date, o.o_price, o.serial_no }).ToList();

                var p1 = (from f in dc.tblSpecials
                          from u in dc.tblUsers
                          from o in dc.tblOrders


                          where o.offer_id == f.offer_id && u.user_id == id && o.o_userid == id
                          select new { f.offer_id, o.o_id, f.offer_image, o.o_quantity, f.f_name, o.o_status, f.offer_price, o.o_date, o.o_price, o.serial_no }).ToList();

                List<oder> li = new List<oder>();

                foreach (var item in p)
                {
                    oder obj1 = new oder();
                    obj1.oder_id = int.Parse(item.o_id.ToString());
                    obj1.food_id = int.Parse(item.f_id.ToString());
                    obj1.food_image = item.f_image;
                    obj1.food_name = item.f_name;
                    obj1.status = item.o_status;

                    obj1.food_price = int.Parse(item.f_price.ToString());
                    obj1.o_quntity = int.Parse(item.o_quantity.ToString());

                    li.Add(obj1);
                }
                foreach (var item in p1)
                {
                    oder obj1 = new oder();
                    obj1.oder_id = int.Parse(item.o_id.ToString());
                    obj1.food_id = int.Parse(item.offer_id.ToString());
                    obj1.food_image = item.offer_image;
                    obj1.food_name = item.f_name;
                    obj1.status = item.o_status;

                    obj1.food_price = int.Parse(item.offer_price.ToString());
                    obj1.o_quntity = int.Parse(item.o_quantity.ToString());

                    li.Add(obj1);
                }

                ViewData["order"] = li.ToList();
                return View();
            }
        }
        //public ActionResult orderstatusinfo(int id)
        //{
        //    var p = (from f in dc.tblFoods
        //             from u in dc.tblUsers
        //             from o in dc.tblOrders

        //             where o.f_id == f.f_id && u.user_id == id && o.o_userid == id
        //             select new { f.f_id, o.o_id, f.f_image, o.o_quantity, f.f_name, o.o_status, f.f_price, o.o_date, o.o_price, o.serial_no }).ToList();

        //    List<oder> obj = new List<oder>();

        //    foreach (var item in p)
        //    {
        //        oder obj1 = new oder();
        //        obj1.oder_id = int.Parse(item.o_id.ToString());
        //        obj1.food_id = int.Parse(item.f_id.ToString());
        //        obj1.food_image = item.f_image;
        //        obj1.food_name = item.f_name;
        //        obj1.status = item.o_status;
        //        obj1.food_price = int.Parse(item.f_price.ToString());
        //        obj1.o_quntity = int.Parse(item.o_quantity.ToString());

        //        obj.Add(obj1);
        //    }
        //    ViewData["read"] = p1;
        //    return View();
        //}

        public ActionResult changeadd(string add)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult changeadd(FormCollection fc, string id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var s = int.Parse(Session["chng"].ToString());

                string add = fc["address"];

                tblOrder i = (from o in dc.tblOrders where o.o_userid == s select o).FirstOrDefault();

                i.address = add;

                dc.SaveChanges();
                return View();
            }
        }
        public ActionResult buynow(int id)
        {
            
            var p1 = dc.tblFoods.Where(p => p.f_id == id).ToList();
            
            ViewData["buynow"] = p1;
            return View();
        }
        [HttpPost]
        public ActionResult buynow(FormCollection fc)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int uid = int.Parse(Session["userlogin"].ToString());
                while (dc.tblOrders.Where(x => x.o_userid == uid && x.o_status == "pending").Count() != 0)
                {
                    tblOrder t = dc.tblOrders.Where(x => x.o_userid == uid).FirstOrDefault();
                    dc.tblOrders.Remove(t);
                    dc.SaveChanges();
                }
                tblOrder od = new tblOrder();



                int orderid = 0;
                int cntorder = dc.tblOrders.Count();
                if (cntorder == 0)
                {
                    orderid = 401;
                }
                else
                {

                    int value = int.Parse(dc.tblOrders
                                .OrderByDescending(p => p.serial_no)
                                .Select(r => r.o_id)
                                .First().ToString());
                    // var p = (from n in dc.order_dtls select new { n.order_id }).LastOrDefault();
                    orderid = value + 1;
                }
                var i2 = fc["i"];


                od.f_id = Convert.ToInt32(fc["oid"]);
                od.o_quantity = fc["txtqty" + i2];
                od.o_price = Convert.ToInt32(fc["tot" + i2]);
                od.o_userid = Convert.ToInt32(Session["userlogin"]);
                od.o_date = DateTime.Now;
                od.o_status = "Pending";
                od.o_id = orderid;
                od.address = fc["add"];
                od.mobile = fc["mb"];
                od.r_id = int.Parse(fc["rid"].ToString());

                dc.tblOrders.Add(od);
                dc.SaveChanges();
                while (dc.tblCarts.Where(x => x.user_id == uid).Count() != 0)
                {
                    tblCart t = dc.tblCarts.Where(x => x.user_id == uid).FirstOrDefault();
                    dc.tblCarts.Remove(t);
                    dc.SaveChanges();
                }

                return RedirectToAction("makepayment", "User");
            }
        }

        public ActionResult buynow1(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var p1 = dc.tblSpecials.Where(p => p.offer_id == id).ToList();

                ViewData["buynow1"] = p1;
                return View();
            }
        }
        [HttpPost]
        public ActionResult buynow1(FormCollection fc)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int uid = int.Parse(Session["userlogin"].ToString());
                while (dc.tblOrders.Where(x => x.o_userid == uid && x.o_status == "pending").Count() != 0)
                {
                    tblOrder t = dc.tblOrders.Where(x => x.o_userid == uid).FirstOrDefault();
                    dc.tblOrders.Remove(t);
                    dc.SaveChanges();
                }
                tblOrder od = new tblOrder();



                int orderid = 0;
                int cntorder = dc.tblOrders.Count();
                if (cntorder == 0)
                {
                    orderid = 401;
                }
                else
                {

                    int value = int.Parse(dc.tblOrders
                                .OrderByDescending(p => p.serial_no)
                                .Select(r => r.o_id)
                                .First().ToString());
                    // var p = (from n in dc.order_dtls select new { n.order_id }).LastOrDefault();
                    orderid = value + 1;
                }
                var i2 = fc["i"];


                od.offer_id = Convert.ToInt32(fc["oid"]);
                od.o_quantity = fc["txtqty" + i2];
                od.o_price = Convert.ToInt32(fc["tot" + i2]);
                od.o_userid = Convert.ToInt32(Session["userlogin"]);
                od.o_date = DateTime.Now;
                od.o_status = "Pending";
                od.o_id = orderid;
                od.address = fc["add"];
                od.mobile = fc["mb"];
                od.r_id = int.Parse(fc["rid"].ToString());
                dc.tblOrders.Add(od);
                dc.SaveChanges();
                while (dc.tblCarts.Where(x => x.user_id == uid).Count() != 0)
                {
                    tblCart t = dc.tblCarts.Where(x => x.user_id == uid).FirstOrDefault();
                    dc.tblCarts.Remove(t);
                    dc.SaveChanges();
                }

                return RedirectToAction("makepayment1", "User");
            }
        }

        [HttpGet]
        public ActionResult makepayment1()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {

                int id = int.Parse(Session["userlogin"].ToString());

                var p = (from o in dc.tblOrders
                         from f in dc.tblSpecials
                         where o.offer_id == f.offer_id && o.o_status == "Pending" && o.o_userid == id
                         select new
                         {
                             o.o_id,
                             f.offer_id,
                             f.f_name,
                             f.offer_image,
                             o.o_quantity,
                             o.o_price,
                             o.o_userid,
                             o.mobile,
                         }).ToList();

                List<cartdetail> obj = new List<cartdetail>();

                foreach (var item in p)
                {
                    cartdetail obj1 = new cartdetail();
                    obj1.o_id = int.Parse(item.o_id.ToString());
                    obj1.food_name = item.f_name;
                    obj1.food_image = item.offer_image;
                    obj1.o_quantity = (item.o_quantity).ToString();
                    obj1.o_price = (item.o_price).ToString();
                    obj.Add(obj1);
                }
                ViewData["confirm1"] = obj;
                return View();
            }

        }
        [HttpPost]
        public ActionResult makepayment1(FormCollection fc)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int uid = int.Parse(Session["userlogin"].ToString());

                int cnt = Convert.ToInt32(fc["record_cnt"]);

                var p = dc.tblOrders.Where(c => c.o_userid == uid).FirstOrDefault();
                int grandtotal = int.Parse(fc["gt"]);
                string mode = fc["mode"];
                var ki = dc.tblUsers.Where(c => c.user_id == uid).FirstOrDefault();
                tblPayment od = new tblPayment();

               // string msg = " Thanks for buying our product.. Your order will place within 10 to 15 minutes";


                od.order_id = p.o_id;
               
                od.total_amount = grandtotal;
                od.payment_mode = mode;
                od.payment_date = DateTime.Now;
                od.payment_status = "Complete";

                dc.tblPayments.Add(od);
                //string data = "https://control.msg91.com/api/sendhttp.php?authkey=146289AKndIGBtt58ef2d4b&mobiles=" +  + "&message=" + msg + "&sender=NGOHUB&route=4&country=91";

                //var wc = new System.Net.WebClient();

                //string url = wc.DownloadString(data);

                dc.SaveChanges();
                ViewBag.msg = "Your order successfully done....";
                while (dc.tblOrders.Where(x => x.o_id == p.o_id && x.o_status == "Pending").Count() != 0)
                {
                    tblOrder t = dc.tblOrders.Where(x => x.o_id == p.o_id && x.o_status == "Pending").FirstOrDefault();
                    t.o_status = "Complete";
                    dc.SaveChanges();
                }
                return RedirectToAction("userindex", "User");
            }
        }


        public ActionResult demo()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var p = dc.tblFoods.ToList();
                ViewData["f"] = p;

                return View();
            }
        }
        public ActionResult single1()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                return View();
            }
        }
       
        public ActionResult single2()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult single(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                ViewBag.Title = "single";
                ViewData["s1"] = dc.tblRestuarantRegistrations.ToList();
                ViewData["state"] = dc.tblStates.ToList();
                ViewData["city"] = dc.tblCities.ToList();
                ViewData["area"] = dc.tblAreas.ToList();



                var p1 = dc.tblCategories.Where(p => p.c_id == id).ToList();
                ViewData["p1"] = p1;


                return View();
            }

        }

        public ActionResult single_sub(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                ViewBag.Title = "single";
                ViewData["s1"] = dc.tblRestuarantRegistrations.ToList();
                ViewData["state"] = dc.tblStates.ToList();
                ViewData["city"] = dc.tblCities.ToList();
                ViewData["area"] = dc.tblAreas.ToList();



                var p1 = dc.tblSubcategories.Where(p => p.s_id == id).ToList();
                ViewData["p"] = p1;


                return View();
            }

        }
       
        public ActionResult payment()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                return View();
            }
        }


        //Sub Food view
        public ActionResult viewa(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var p = (from n in dc.tblSubcategories where n.c_id == id select n).ToList();

                ViewData["food1"] = p;

                return View();
            }
        }
        public ActionResult viewb(int id)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                var p = (from n in dc.tblFoods where n.s_id == id select n).ToList();

                ViewData["food2"] = p;

                return View();
            }
        }

        public ActionResult addtocart(int id)
        {
            
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int uid = int.Parse(Session["userlogin"].ToString());
                var p = dc.tblFoods.Find(id);
                tblCart tc = new tblCart();
                tc.f_id = id;
                tc.qty = 1;
                tc.amt = p.f_price;
                tc.user_id = uid;
                dc.tblCarts.Add(tc);
                dc.SaveChanges();
                return RedirectToAction("userindex", "User");
            }


        }
        public ActionResult viewcart()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {

                int id = int.Parse(Session["userlogin"].ToString());

                var p = (
                           from c in dc.tblCarts
                           from f in dc.tblFoods
                           from u in dc.tblUsers
                           where c.f_id == f.f_id && u.user_id == id && c.user_id == id
                           select new
                           {
                               f.f_id,
                               c.cart_id,
                               f.f_image,
                               c.qty,
                               f.f_name,
                               f.f_price,
                               f.r_id
                           }).ToList();



                List<cartdetail> obj = new List<cartdetail>();
                //int total=0;
                foreach (var item in p)
                {
                    cartdetail obj1 = new cartdetail();
                    obj1.cart_id = item.cart_id;
                    obj1.food_id = item.f_id;
                    obj1.food_image = item.f_image;
                    obj1.food_qty = int.Parse(item.qty.ToString());
                    obj1.food_name = item.f_name;
                    obj1.food_price = int.Parse(item.f_price.ToString());
                    //total += obj1.food_price;
                    obj1.rid = int.Parse(item.r_id.ToString());
                    obj.Add(obj1);
                }
                ViewData["viewcart"] = obj;



                return View();
            }
        }
        [HttpPost]
        public ActionResult viewcart(FormCollection fc)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int uid = int.Parse(Session["userlogin"].ToString());

                while (dc.tblOrders.Where(x => x.o_userid == uid && x.o_status == "pending").Count() != 0)
                {
                    tblOrder t = dc.tblOrders.Where(x => x.o_userid == uid).FirstOrDefault();
                    dc.tblOrders.Remove(t);
                    dc.SaveChanges();
                }
                string oid, qty, tot, rid;
                tblOrder od = new tblOrder();



                int orderid = 0;
                int cntorder = dc.tblOrders.Count();
                if (cntorder == 0)
                {
                    orderid = 401;
                }
                else
                {

                    int value = int.Parse(dc.tblOrders
                                .OrderByDescending(p => p.serial_no)
                                .Select(r => r.o_id)
                                .First().ToString());
                    // var p = (from n in dc.order_dtls select new { n.order_id }).LastOrDefault();
                    orderid = value + 1;
                }
                int cnt = Convert.ToInt32(fc["record_cnt"]);
                for (int i = 0; i < cnt; i++)
                {
                    //od.order_id = orderid;
                    oid = "oid" + i;
                    rid = "rid" + i;
                    od.f_id = Convert.ToInt32(fc[oid]);
                    qty = "txtqty" + i;
                    od.o_quantity = fc[qty];
                    tot = "tot" + i;
                    od.o_price = Convert.ToInt32(fc[tot]);
                    od.o_userid = Convert.ToInt32(Session["userlogin"]);
                    od.o_date = DateTime.Now;
                    od.o_status = "Pending";
                    od.o_id = orderid;
                    od.r_id = Convert.ToInt32(fc[rid]);
                    od.address = fc["add"];
                    od.mobile = fc["mb"];
                    dc.tblOrders.Add(od);
                    dc.SaveChanges();


                }
                while (dc.tblCarts.Where(x => x.user_id == uid).Count() != 0)
                {
                    tblCart t = dc.tblCarts.Where(x => x.user_id == uid).FirstOrDefault();
                    dc.tblCarts.Remove(t);
                    dc.SaveChanges();
                }

                return RedirectToAction("makepayment", "User");
            }
        }

        [HttpGet]
        public ActionResult makepayment()
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {

                int id = int.Parse(Session["userlogin"].ToString());

                var p = (from o in dc.tblOrders
                         from f in dc.tblFoods
                         where o.f_id == f.f_id && o.o_status == "Pending" && o.o_userid == id
                         select new
                         {
                             o.o_id,
                             f.f_id,
                             f.f_name,
                             f.f_image,
                             o.o_quantity,
                             o.o_price,
                             o.o_userid
                         }).ToList();

                List<cartdetail> obj = new List<cartdetail>();

                foreach (var item in p)
                {
                    cartdetail obj1 = new cartdetail();
                    obj1.o_id = int.Parse(item.o_id.ToString());
                    obj1.food_name = item.f_name;
                    obj1.food_image = item.f_image;
                    obj1.o_quantity = (item.o_quantity).ToString();
                    obj1.o_price = (item.o_price).ToString();
                    obj.Add(obj1);
                }
                ViewData["confirm"] = obj;
                return View();
            }

        }
        [HttpPost]
        public ActionResult makepayment(FormCollection fc)
        {
            if (Session["userlogin"] == null)
            {
                return RedirectToAction("userlogin", "Home");
            }
            else
            {
                int uid = int.Parse(Session["userlogin"].ToString());

                int cnt = Convert.ToInt32(fc["record_cnt"]);

                var p = dc.tblOrders.Where(c => c.o_userid == uid).FirstOrDefault();
                int grandtotal = int.Parse(fc["gt"]);
                string mode = fc["mode"];
                var ki = dc.tblUsers.Where(c => c.user_id == uid).FirstOrDefault();
                tblPayment od = new tblPayment();


                od.order_id = p.o_id;
                od.total_amount = grandtotal;
                od.payment_mode = mode;
                od.payment_date = DateTime.Now;
                od.payment_status = "Complete";

                dc.tblPayments.Add(od);
                dc.SaveChanges();
                ViewBag.msg = "Your order successfully done....";
                //for replacing status
                //while (dc.tblOrders.Where(x => x.o_id == p.o_id && x.o_status == "Pending").Count() != 0)
                //{
                //    tblOrder t = dc.tblOrders.Where(x => x.o_id == p.o_id && x.o_status == "Pending").FirstOrDefault();
                //    t.o_status = "Pending";
                //    dc.SaveChanges();
                //}
                return RedirectToAction("userindex", "User");
            }
        }




       
        public class cat
        {
            public int f_id { get; set; }
            public int f_price { get; set; }
            public string f_name { get; set; }
            public string f_image { get; set; }

        }
        public class cat2
        {
            public int f_id { get; set; }
            public int f_price { get; set; }
            public string f_name { get; set; }
            public string f_image { get; set; }

        }
        public class cat3
        {
            public int f_id { get; set; }
            public int f_price { get; set; }
            public string f_name { get; set; }
            public string f_image { get; set; }

        }
        public class cat4
        {
            public int f_id { get; set; }
            public int f_price { get; set; }
            public string f_name { get; set; }
            public string f_image { get; set; }

        }
        public class useroffer
        {
            public int o_id { get; set; }
            public string o_name { get; set; }
            public string o_img { get; set; }
            public string product { get; set; }

            public int or_id { get; set; }
            public string qty { get; set; }
            public string total { get; set; }
            public string o_price { get; set; }
            public int cart_id { get; set; }
        }

        public class cartdetail
        {
            public int food_status { get; set; }
            public int cart_id { get; set; }
            public int food_id { get; set; }
            public string food_image { get; set; }
            public int food_qty { get; set; }
            public string food_name { get; set; }
            public int food_price { get; set; }
            public int o_id { get; set; }
            public string o_quantity { get; set; }
            public string o_price { get; set; }
            public string oderadd { get; set; }
            public int rid { get; set; }
        }
        public class oder
        {
            public int offer_id { get; set; }
            public int oder_id { get; set; }
            public int food_id { get; set; }
            public string status { get; set; }
            public string food_image { get; set; }
            public int food_qty { get; set; }
            public string food_name { get; set; }
            public int food_price { get; set; }
            public int o_quntity { get; set; }
            public int o_price { get; set; }
            public string rname { get; set; }
        }
        public class cartdetail2
        {
            public int food_status2 { get; set; }
            public int cart_id2 { get; set; }
            public int food_id2 { get; set; }
            public string food_image2 { get; set; }
            public int food_qty2 { get; set; }
            public string food_name2 { get; set; }
            public int food_price2 { get; set; }
            public int o_id2 { get; set; }
            public string o_quantity2 { get; set; }
            public string o_price2 { get; set; }

        }

       
        public class osummry
        {
            public int fid { get; set; }
            public string fname { get; set; }
            public int uid { get; set; }
            public int rid { get; set; }
            public string ostatus { get; set; }
            public string image { get; set; }
            public string rname { get; set; }

        }
    }
}
