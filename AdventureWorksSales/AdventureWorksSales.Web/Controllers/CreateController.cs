using AdventureWorkSales.Repository.Services;
using AdventureWorksSales.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace AdventureWorksSales.Web.Controllers
{
    public class CreateController : Controller
    {
        private IAdventureWorkService _services;
        public CreateController()
        {
            _services = new AdventureWorkService(null);
        }
        // GET: Create
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCategory model)
        {
            try
            {
                int result = await _services.CreateProdCategory(model);
                if (result >= 1)
                {
                    ViewBag.Message = "Category added Successfully";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Error occured";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}