using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OHD.Data;
using OHD.Models;
using System.Linq;

namespace OHD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatusComplainController : Controller
    {
        private readonly ODHContext context;
        private readonly IWebHostEnvironment iWebHost;

        public StatusComplainController(ODHContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.tblStatus.ToList();
            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(tblStatus model)
        {
            //___________ Create ___________
            context.tblStatus.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var selectedRecord = context.tblStatus.Find(id);
            return View(selectedRecord);
        }
        [HttpPost]
        public IActionResult Edit(tblStatus model)
        {
            context.tblStatus.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult delete(int id)
        {
            var Year = context.tblStatus.Find(id);


            context.tblStatus.Remove(Year);
            context.SaveChanges();
            TempData["error"] = "Removed Successfuly!";
            return RedirectToAction("Index");
        }

    }
}
