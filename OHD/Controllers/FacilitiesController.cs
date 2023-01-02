using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OHD.Data;
using System.Linq;

namespace OHD.Controllers
{
    public class FacilitiesController : Controller
    {
        private readonly ODHContext context;
        private readonly IWebHostEnvironment iWebHost;

        public FacilitiesController(ODHContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblFacilities.ToList();
            return View(list);
        }
    }
}
