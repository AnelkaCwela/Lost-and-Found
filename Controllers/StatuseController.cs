using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;

namespace LostNelsonFound.Controllers
{
    public class StatuseController : Controller
    {
        private readonly ICategoryLostModel _categoryLostModel;
        private readonly ICategoryModel _categoryModel;
        private readonly ICampus _campus;
        private readonly IStatuseLostModel _statuseLostModel;
        private readonly IStatuseModel _statuseModel;
       public StatuseController(IStatuseModel statuseModel,IStatuseLostModel statuseLostModel,ICampus campus,ICategoryLostModel categoryLostModel, ICategoryModel categoryModel)
        {
            _statuseModel = statuseModel;
            _statuseLostModel = statuseLostModel;
            _campus = campus;
            _categoryLostModel = categoryLostModel;
            _categoryModel = categoryModel;
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateLCategory(CategoryLostModel model)
        {
            if(ModelState.IsValid)
            {
               await _categoryLostModel.AddAsync(model);
                ViewBag.Added = "Added Succesfully";
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateFCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryModel.AddAsync(model);
                ViewBag.Added = "Added Succesfully";
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateCampuse(CampusModel model)
        {
            if (ModelState.IsValid)
            {
                await _campus.AddAsync(model);
                ViewBag.Added = "Added Succesfully";
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> FoundStatuse(StatuseModel model)
        {
            if (ModelState.IsValid)
            {
                await _statuseModel.AddAsync(model);
                ViewBag.Added = "Added Succesfully";
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LostStatuse(StatuseLostModel model)
        {
            if (ModelState.IsValid)
            {
                await _statuseLostModel.AddAsync(model);
                ViewBag.Added = "Added Succesfully";
            }
            return View();
        }
        [HttpGet]
        public IActionResult LostStatuse()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FoundStatuse()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateLCategory()
        {         
            return View();
        }
        [HttpGet]
        public IActionResult CreateFCategory()
        {     
            return View();
        }
        [HttpGet]
        public IActionResult CreateCampuse()
        {
            return View();
        }

    }
}
