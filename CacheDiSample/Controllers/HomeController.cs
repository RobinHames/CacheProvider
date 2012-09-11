using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CacheDiSample.Domain.Repositories;
using CacheDiSample.Domain.Model;

namespace CacheDiSample.Controllers
{

    public class HomeController : Controller
    {
        private readonly IBlogRepository blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            if (blogRepository == null)
                throw new ArgumentNullException("blogRepository");

            this.blogRepository = blogRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var blogs = blogRepository.GetAll();

            return View(new Models.HomeModel { Blogs = blogs });
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
