using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeoFriendlyUrls.Models;

namespace SeoFriendlyUrls.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(_dbContext.Products);
        }

        public ActionResult Details(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }
    }
}