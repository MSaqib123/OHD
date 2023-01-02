using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OHD.Data;
using OHD.Data.ViewModels;
using OHD.Models;
using System;
using System.IO;
using System.Linq;

namespace OHD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilitesController : Controller
    {
        private readonly ODHContext context;
        private readonly IWebHostEnvironment iWebHost;

        public FacilitesController(ODHContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        #region MultipleImageProducts
        public IActionResult Index()
        {
            //_____________________ 1st Step _________________________
            //var list = context.TblFacilities.ToList();
            //return View(list);
            VMFacility vm = new VMFacility();
            vm.tblFacility = new TblFacilities();
            vm.tblFacilityImages = new TblFacilityImages();
            vm.tblFacility_List = context.TblFacilities.ToList();
            vm.tblFacilityImages_List = context.TblFacilityImages.Include(x => x.tblFacility).ToList();
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VMFacility model)
        {
            //____________ 1. Single Image _________
            var folder = "";
            if (model.tblFacility.MainBrowsImage != null)
            {
                folder = "Images/Facility/";
                folder += Guid.NewGuid().ToString() + "_" + model.tblFacility.MainBrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.tblFacility.MainBrowsImage.CopyTo(fileMode);
                }
            }

            //_____ Create ____
            model.tblFacility.FaciImage = folder;
            context.TblFacilities.Add(model.tblFacility);


            //____________ 2. Mutliple Image _________
            foreach (var item in model.Images)
            {
                string fileName = UploadFile(item);
                var facilityMultipleImage = new TblFacilityImages
                {
                    ImageUrl = fileName,
                    tblFacility = model.tblFacility,
                    FaciId = model.tblFacility.FaciId
                };
                context.TblFacilityImages.Add(facilityMultipleImage);
            }

            context.SaveChanges();

            //TempData["success"] = "Faciality Added Successfuly!";
            return RedirectToAction("Index");
        }


        //__________ Globle Function __________
        private string UploadFile(IFormFile file)
        {
            var Imagefolder = "";
            if (file != null)
            {
                Imagefolder = "Images/Facility/";
                Imagefolder += Guid.NewGuid().ToString() + "_" + file.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, Imagefolder);
                using (var xfileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    file.CopyTo(xfileMode);
                }
            }
            return Imagefolder;
        }




        public IActionResult Edit(int id)
        {
            //var selectedRecord = context.TblFacilities.Find(id);
            VMFacility vm = new VMFacility();
            vm.tblFacility = context.TblFacilities.Where(x => x.FaciId == id).FirstOrDefault();
            vm.tblFacilityImages = new TblFacilityImages();
            vm.tblFacility_List = context.TblFacilities.Where(x=>x.FaciId==id).ToList();
            vm.tblFacilityImages_List = context.TblFacilityImages.Include(x => x.tblFacility).Where(x => x.FaciId == id).ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(VMFacility model)
        {
            //____________________ Multiple Table Record Update ___________
            //__ delete Image __
            if (model.tblFacility.MainBrowsImage != null)
            {
                //_________ 1st Delete Main Images _____
                if (model.tblFacility.FaciImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.tblFacility.FaciImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }


                //_________ 3rd Add Main Image _______
                var folder = "Images/Facility/";
                folder += Guid.NewGuid().ToString() + "_" + model.tblFacility.MainBrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.tblFacility.MainBrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                model.tblFacility.FaciImage = folder;
            }

            //__ delete Multiple Image __
            if (model.Images != null)
            {
                //_________ 1 Delete Multiple Images _____
                var record = context.TblFacilityImages.Where(x => x.FaciId == model.tblFacility.FaciId);
                if (record.ToList().Count() > 0)
                {

                    foreach (var item in record)
                    {
                        var serverFolder2 = Path.Combine(iWebHost.WebRootPath, item.ImageUrl);
                        if (System.IO.File.Exists(serverFolder2))
                        {
                            System.IO.File.Delete(serverFolder2);
                        }
                    }
                    context.TblFacilityImages.RemoveRange(record.ToList());
                }

                //_________ 2 Add Main Image _______
                foreach (var item in model.Images)
                {
                    string fileName = UploadFile(item); //file Image 1 by 1
                    var facilityMultipleImage = new TblFacilityImages
                    {
                        ImageUrl = fileName,
                        tblFacility = model.tblFacility, //facility ka Saraa Record
                        FaciId = model.tblFacility.FaciId
                    };

                    context.TblFacilityImages.Add(facilityMultipleImage); //file Image 1 by 1
                }
            }


            context.TblFacilities.Update(model.tblFacility);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion


        public IActionResult delete(int id)
        {
            VMFacility vm = new VMFacility();
            vm.tblFacility = context.TblFacilities.Where(x => x.FaciId == id).FirstOrDefault();
            vm.tblFacilityImages = new TblFacilityImages();
            vm.tblFacility_List = context.TblFacilities.Where(x => x.FaciId == id).ToList();
            vm.tblFacilityImages_List = context.TblFacilityImages.Include(x => x.tblFacility).Where(x => x.FaciId == id).ToList();

            //_______ 1. Delete Main Image _________
            if (vm.tblFacility.FaciImage  != null)
            {
                var serverFolder1 = Path.Combine(iWebHost.WebRootPath, vm.tblFacility.FaciImage);
                if (System.IO.File.Exists(serverFolder1))
                {
                    System.IO.File.Delete(serverFolder1);
                }
            }
            

            //_______ 2. Delete All Images of Selected Record _________
            foreach (var item in vm.tblFacilityImages_List.ToList())
            {
                var serverFolder2 = Path.Combine(iWebHost.WebRootPath, item.ImageUrl);
                if (System.IO.File.Exists(serverFolder2))
                {
                    System.IO.File.Delete(serverFolder2);
                }
            }

            context.TblFacilities.Remove(vm.tblFacility);
            context.TblFacilityImages.RemoveRange(vm.tblFacilityImages_List);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
