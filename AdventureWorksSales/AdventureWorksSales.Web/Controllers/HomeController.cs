using AdventureWorkSales.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
   
    public class HomeController : Controller
    {
        private IAdventureWorkService _services;
        public HomeController()
        {
            _services =  new AdventureWorkService(null);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var total = await _services.GetSalesCount();
                var highestTotal = await HighestLineTotal();
                var frontBrakes = await FrontBrakeSales();
                ViewBag.Total = total;
                ViewBag.HighestTotal = highestTotal;
                ViewBag.FrontBrakes = frontBrakes;
                return View("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
  
        private async Task<int> HighestLineTotal()
        {
            try
            {
                var result = await _services.HighestLineTotal();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> FrontBrakeSales()
        {
            try
            {
                return await _services.GetFrontBakesSales();
                
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}