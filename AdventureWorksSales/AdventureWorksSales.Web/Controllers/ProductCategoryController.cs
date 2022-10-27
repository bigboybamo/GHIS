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
    public class ProductCategoryController : Controller
    {
        private IAdventureWorkService _services;
        public ProductCategoryController()
        {
            _services = new AdventureWorkService(null);
        }

        // GET: ProductCategory
        public async Task<ActionResult> ProductCategory()
        {
            var productCategory = await CategoryList();
            ViewBag.Category = productCategory;
            return View("ProductCategory");
        }

        private async Task<List<dynamic>> CategoryList()
        {
            try
            {
                var  result = await _services.GetProductCategory();
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result =  await _services.GetProductCategoryById(id);
            
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductCategory model)
        {
            try
            {
                int result = await _services.UpdateProdCategory(model);
                if (result >= 1)
                {
                    ViewBag.Message = "Product Updated successfully";
                    return View("");
                }
                else
                {
                    ViewBag.Message = "Error occured";
                    return View("");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}