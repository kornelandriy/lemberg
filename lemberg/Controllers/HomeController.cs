using System;
using System.Diagnostics;
using System.Threading.Tasks;
using lemberg.Attributes;
using lemberg.Helpers;
using lemberg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lemberg.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        private readonly int pageSize;

        public HomeController(AppDbContext context)
        {
            this.context = context;
            pageSize = 10;
        }

        private int TotalPages { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1, string sortBy = "")
        {
            var peoples = await context.Peoples.Include("Mark").ToListAsync();
            TotalPages = (int) Math.Ceiling(decimal.Divide(peoples.Count, pageSize));
            var page = peoples.GetPage(pageIndex, pageSize);

            ViewData["currentPage"] = pageIndex;
            ViewData["totalPages"] = TotalPages;

            return View(page.Order(sortBy));
        }

        [HttpPost]
        [ExceptionHandler]
        public async Task<IActionResult> Index(PersonViewModel personVM)
        {
            if (ModelState.IsValid) await personVM.AddToDatabase(context);

            return RedirectToAction("Index", new {pageIndex = personVM.ReturnPage});
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}