using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.EDM;
using System.IO;
using PagedList;
namespace Project.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        RestaurantDBEntities dc = new RestaurantDBEntities();

        public ActionResult datapicker()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult adminindex()
        
        {
            
                var p = (from n in dc.tblUsers select n.user_id).Count();
                var p1 = (from n in dc.tblOrders where n.o_status == "Completed" select n).Count();
                var p2 = (from n in dc.tblRestuarantRegistrations where n.r_status == "Approve" select n).Count();


                ViewData["p2"] = p2;
                ViewData["p1"] = p1;
                ViewData["p"] = p;
                return View();
            
        }
        
        //category section
        public ActionResult category(int page = 1, int pageSize =4) 
        {
            
                List<tblCategory> categorylist = dc.tblCategories.ToList();
                PagedList<tblCategory> model = new PagedList<tblCategory>(categorylist, page, pageSize);
                var data = dc.tblCategories.ToList();
                ViewData["cat"] = data;
                return View(model);
            
        }
       
        public ActionResult addcategory()
        {
            
                return View();
            
        }
        [HttpPost]

        public ActionResult addcategory(FormCollection fc ,HttpPostedFileBase file)
        {
            
                tblCategory cat = new tblCategory();
                if (file != null)
                {
                    string file1 = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/catimg"), file1);
                    file.SaveAs(path);
                    cat.category_image = file1;
                }

                string cname = fc["cname"];
                string ccode = fc["ccode"];
                string price = fc["cprice"];

                cat.category_name = cname;
                cat.category_code = ccode;
                cat.category_price = price;


                dc.tblCategories.Add(cat);
                dc.SaveChanges();


                return View();
            
        }

        public ActionResult edit_category(int id)
        {
          
                var p = dc.tblCategories.Find(id);
                ViewData["cat1"] = p;
                return View();
            
        }

        [HttpPost]
        public ActionResult edit_category(FormCollection fc)
        {
            
                string catname = fc["c_name"];
                string catcode = fc["c_code"];
                string catimg = fc["c_img"];
                string catprice = fc["c_price"];
                int cid = int.Parse(fc["c_id"]);
                var p = dc.tblCategories.Find(cid);


                p.category_name = catname;
                p.category_code = catcode;
                p.category_image = catimg;
                p.category_price = catprice;

                dc.SaveChanges();

                return Redirect(Url.Action("category", "Admin"));
            
        }

        public ActionResult delete_category(int id)
        {
            
                var p = dc.tblCategories.Find(id);
                dc.tblCategories.Remove(p);
                dc.SaveChanges();
                return RedirectToAction("category", "Admin");
            
            
        }

        public ActionResult detail_category(int id)
        {
                var i = dc.tblCategories.Find(id);
                ViewData["dtl"] = i;
                return View();
            
        }


        //subcategory section
        public ActionResult subcategory(int page =1, int pageSize = 4)
        {
            
                List<tblSubcategory> subcategorylist = dc.tblSubcategories.ToList();
                PagedList<tblSubcategory> model = new PagedList<tblSubcategory>(subcategorylist, page, pageSize);


                var p = (from n in dc.tblSubcategories
                         from l in dc.tblCategories
                         where n.c_id == l.c_id
                         select new
                         {
                             n.s_id,
                             n.subcategory_name,
                             n.subcategory_code,
                             n.subcategory_image,
                             n.subcategory_price,
                             l.category_name


                         });

                List<viewcat1> list = new List<viewcat1>();

                foreach (var item in p)
                {
                    viewcat1 obj = new viewcat1();
                    obj.subcategory_name = item.subcategory_name;
                    obj.subcategory_code = item.subcategory_code;
                    obj.subcategory_image = item.subcategory_image;
                    obj.subcategory_price = item.subcategory_price;
                    obj.category_name = item.category_name;
                    obj.s_id = item.s_id;

                    list.Add(obj);

                }
                ViewData["viewcat1"] = list;
                return View(model);
            
        }

        public ActionResult addsubcategory()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                var data = dc.tblCategories.ToList();
                ViewData["p1"] = data;

                return View();
            }
        }
        [HttpPost]

        public ActionResult addsubcategory(FormCollection fc, HttpPostedFileBase file)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                tblSubcategory cat = new tblSubcategory();
                if (file != null)
                {
                    string file1 = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/catimg/subcatimg"), file1);
                    file.SaveAs(path);
                    cat.subcategory_image = file1;
                }
                var p = (from n in dc.tblSubcategories from m in dc.tblCategories where n.c_id == m.c_id select n.c_id).FirstOrDefault();

                string catid = fc["cid"];
                string cname = fc["cname"];
                string ccode = fc["ccode"];
                string price = fc["cprice"];

                cat.subcategory_name = cname;
                cat.subcategory_code = ccode;
                cat.subcategory_price = price;
                cat.c_id = int.Parse(catid);

                dc.tblSubcategories.Add(cat);
                dc.SaveChanges();

                var data = dc.tblCategories.ToList();
                ViewData["p1"] = data;
                return View();
            }

        }

        public ActionResult editsubcategory(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                ViewData["temp"] = dc.tblCategories.ToList();
                var p = dc.tblSubcategories.Find(id);

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

                //var query = dc.tblSubcategories.Find(id);
                //ViewData["e1"] = query;


                //TempData["temp"] = dc.tblCategories.ToList();
                return View();
            }
        }

        //[HttpGet]
        //public JsonResult getdata()
        //{
        //    var p = dc.tblCategories.ToList();

        //    return Json(dc.tblCategories.ToList(),JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult editsubcategory(FormCollection fc)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {

                string catname = fc["sc_name"];
                string catcode = fc["sc_code"];
                string catimg = fc["sc_img"];
                string catprice = fc["sc_price"];
                int cid = int.Parse(fc["sc_id"]);


                int drp = int.Parse(fc["drp"]);

                var p = dc.tblSubcategories.Find(cid);

                p.subcategory_name = catname;
                p.subcategory_code = catcode;
                p.subcategory_image = catimg;
                p.subcategory_price = catprice;
                p.c_id = drp;


                dc.SaveChanges();
                return Redirect(Url.Action("subcategory", "Admin"));
            }

        }

        public ActionResult delete_subcategory(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                var p = dc.tblSubcategories.Find(id);
                dc.tblSubcategories.Remove(p);
                dc.SaveChanges();
                return RedirectToAction("subcategory", "Admin");
            }

        }

        public ActionResult detail_subcategory(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                var i = dc.tblSubcategories.Find(id);
                ViewData["dtl"] = i;

                return View();
            }
        }

        public ActionResult approvedrest()
        {
            
                ViewData["rest1"] = dc.tblRestuarantRegistrations.Where(c => c.r_status == "Approve").ToList();
                ViewData["block"] = dc.tblRestuarantRegistrations.Where(c => c.r_status == "blocked").ToList();

                return View();
            
        }
        public ActionResult delrest(int id)
        {
            
                var p = dc.tblRestuarantRegistrations.Find(id);

                p.r_status = "blocked";

                var s = dc.tblFoods.Where(c => c.r_id == id).FirstOrDefault();
                dc.tblFoods.Remove(s);



                //var a = fc["blocked"];

                dc.SaveChanges();
                return RedirectToAction("approvedrest", "Admin");
            
        }
        
        public ActionResult approve_rest()
        {
            
                ViewData["app"] = dc.tblRestuarantRegistrations.Where(c => c.r_status == "Pending").ToList();
                return View();
            
        }

        public ActionResult approve(int id)
        {
            
                var p = dc.tblRestuarantRegistrations.Find(id);
                p.r_status = "Approve";
                Session["new"] = null;
                dc.SaveChanges();
                return RedirectToAction("approve_rest", "Admin");
            

        }

        public ActionResult reject(int id)
        {
            
                var p = dc.tblRestuarantRegistrations.Find(id);
                p.r_status = "reject";
                dc.SaveChanges();
                return RedirectToAction("approve_rest", "Admin");
            

        }

        public const int PageSize = 5;
        public ActionResult totalfood(int? page)
        {

            if (Session["admin"] == null)
            {
                return RedirectToAction("adminlogin", "Home");
            }
            else
            {
                var p = (
                         from l in dc.tblCategories
                         from f in dc.tblFoods
                         from r in dc.tblRestuarantRegistrations
                         where f.c_id == l.c_id && r.r_id == f.r_id
                         select new
                         {
                             f.f_id,
                             f.f_name,
                             f.f_price,
                             f.f_date,
                             f.f_description,
                             f.r_id,
                             r.r_name,

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
                    obj.food_date = item.f_date.ToString();
                    obj.r_name = item.r_name.ToString();

                    list.Add(obj);

                }
                ViewData["p"] = list;

                //int pageSize = 3;
                //int pageNumber = (page ?? 1);

                return View();
            }
        }

        [HttpGet]
        public ActionResult vieworder()
        {
            

                var p = (from u in dc.tblUsers
                         from r in dc.tblRestuarantRegistrations
                         from o in dc.tblOrders
                         from f in dc.tblFoods
                         where o.o_userid == u.user_id && o.r_id == r.r_id && o.f_id == f.f_id
                         select new
                         {
                             u.user_name,
                             f.f_name,
                             f.f_id,
                             r.r_name,
                             f.f_image,
                             o.o_quantity,
                             o.o_date,
                             o.o_price,
                             o.o_status,

                         }).ToList();
                List<orders> obj = new List<orders>();
                foreach (var item in p)
                {
                    orders obj1 = new orders();
                    obj1.username = item.user_name;
                    obj1.foodname = item.f_name;
                    obj1.rest_name = item.r_name;
                    obj1.image = item.f_image;
                    obj1.orderquantity = Convert.ToDecimal(item.o_quantity);
                    obj1.date = Convert.ToDateTime(item.o_date);
                    obj1.orderprice = Convert.ToDecimal(item.o_price);
                    obj1.orderstatus = item.o_status;
                    obj.Add(obj1);
                }
                ViewData["drp"] = dc.tblRestuarantRegistrations.ToList();
                ViewData["orderdtls"] = obj;
                return View();
            
        }
        [HttpPost]
        public JsonResult getorders(int id)
        {
            
                var query = (from u in dc.tblUsers
                             from r in dc.tblRestuarantRegistrations
                             from o in dc.tblOrders
                             from f in dc.tblFoods
                             where o.o_userid == u.user_id && o.r_id == r.r_id && o.f_id == f.f_id && r.r_id == id
                             select new
                             {
                                 u.user_name,
                                 f.f_name,
                                 f.f_id,
                                 r.r_name,
                                 f.f_image,
                                 o.o_quantity,
                                 o.o_date,
                                 o.o_price,
                                 o.o_status,

                             }).ToList();
                return Json(query, JsonRequestBehavior.AllowGet);
            
        }
    }
    public class viewcat1
    {

        
         public string subcategory_name{get; set;}

         public string subcategory_code{get; set;}

         public string subcategory_image{get ; set;}
         
         public string subcategory_price{get; set;}

         public string category_name{get; set;}

         public int s_id { get; set; }

    }
    //public class getcatname
    //{
    //    public string categoryname { get; set; }

    //    public int cid { get; set; }

    //    public int sid { get; set; }
    //}
}
