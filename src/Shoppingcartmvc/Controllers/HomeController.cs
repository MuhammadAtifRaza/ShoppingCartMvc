using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Shoppingcartmvc.Models;
using System.IO;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace Shoppingcartmvc.Controllers
{
    public class HomeController : Controller
    {
        ShoppingcartdbContext context = null;
        IHostingEnvironment env = null;
        public HomeController(ShoppingcartdbContext _context, IHostingEnvironment _env)
        {
            context = _context;
            env = _env;

        }
        #region user managmment
        public IActionResult DashBoard()
        {
            if (HttpContext.Session.Get("User") == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.abc3 = context.User.ToList<User>().Count;
            ViewBag.abc = context.Category.ToList<Category>().Count;
            ViewBag.abc1 = context.Subcategory.ToList<Subcategory>().Count;
            ViewBag.abc2 = context.Product.ToList<Product>().Count;
            return View();
        }



        public IActionResult AllUser()

        {
            IList<User> User = context.User.ToList<User>();


            return View(User);

        }

        public string DeleteUser(int UserID )

        {
            User U = new User();
            U.Id = UserID;
            try
            {
                context.User.Remove(U);
                context.SaveChanges();
                return "DONE";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    

            
        
        #endregion
            #region login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User U)
        {
            User query = context.User.Where(e => e.Username == U.Username && e.Password == U.Password).FirstOrDefault();
           HttpContext.Session.SetString("User", query.Username);
            HttpContext.Session.SetString("User", query.Password);
            if (query != null)
            {
                return RedirectToAction("DashBoard");
            }
            else
            {
                return RedirectToAction("Signup");
            }
        }





        #endregion
        #region Category

        [HttpGet]
        public IActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Category(Category c)
        {
            c.Createddate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");
            c.Modifieddate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");

            context.Category.Add(c);
            context.SaveChanges();
            ViewBag.Message = "Category Saved!!!";
            return View();
        }
        public IActionResult ViewCategory()
        {
            IList<Category> Category = context.Category.ToList<Category>();
            return View(Category);
        }


        #endregion






        #region Signup
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User s)
        {
            context.User.Add(s);
            context.SaveChanges();
            ViewBag.Message = "Sign Up Successfully";
            return View();
        }

        #endregion
        #region SubCategory

        [HttpGet]
        public IActionResult Subcategory()
        {
            IList<Category> SL = context.Category.ToList<Category>();
            ViewBag.SL = SL;
            return View();
        }

        [HttpPost]
        public IActionResult Subcategory(Subcategory s)
        {
            context.Subcategory.Add(s);
            context.SaveChanges();
            ViewBag.Message = "Sub-category Saved!!!";
            return RedirectToAction("Product");
        }

        #endregion
        #region Product

        [HttpGet]
        public IActionResult Product()
        {
            IList<Category> SL = context.Category.ToList<Category>();
            ViewBag.SL = SL;

            IList<Subcategory> CL = context.Subcategory.ToList<Subcategory>();
            ViewBag.CL = CL;
            return View();
            
        }

        [HttpPost]
        public IActionResult Product(Product P)
        {
            foreach (var file in Request.Form.Files)
            {
                var name = file.Name;
                var ext = System.IO.Path.GetExtension(file.FileName);
                var filename = DateTime.Now.ToString("ddMMyyyyhhmmss") + ext;
                string path = env.WebRootPath + "/UploadedData/pps/" + filename;

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                P.Image = filename;
                //P.Img = path;
            }

            P.Createddate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");
            P.Modifieddate = DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss");

            context.Product.Add(P);
            context.SaveChanges();
            ViewBag.Message = "Product saved!!!";
            return RedirectToAction("Product");
        }
        public IActionResult Allproducts(int page=1)
        {
            // page size = 4
            // default page no = 1
            //page 


            IPagedList<Product> data = context.Product.ToPagedList<Product>(3, page);
            //  IList<Product> Products = context.Product.ToList<Product>();
            // IList<Product> Products = context.Product.Where(m => m.Id > 1).ToList<Product>();
            return View(data);
        }


        public FileResult downloadfile(string filepath)
        {
            string ext = System.IO.Path.GetExtension(filepath);
            return File("/UploadedData/pps/" + filepath, System.Net.Mime.MediaTypeNames.Application.Octet, DateTime.Now.ToString("ddMMyyyyhhmmss") + ext);
        }




        public IActionResult showProducts(Product P, string cat,int page=1)
        {

            ViewBag.category = context.Category.ToList<Category>();
            if (cat == null)
            {

                IPagedList<Product> link1 = context.Product.ToPagedList<Product>(3, page);
               // IList<Product> link1 = context.Product.ToList<Product>();
                return View(link1);
            }
            else if (cat != null)
            {
                IPagedList<Product> link = context.Product.Where(m => m.Parentcategory == cat).ToPagedList<Product>(3, page);
                //IList<Product> link = context.Product.Where(m => m.Parentcategory == cat).ToList<Product>();

                return View(link);
            }
            return View();


        }

        [HttpGet]
        public IActionResult ProductsDetails(Product P1, int ProId)
        {

            Product Pro = context.Product.Where(m => m.Id == ProId).FirstOrDefault<Product>();
            return View(Pro);

        }

        #endregion
       












        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
