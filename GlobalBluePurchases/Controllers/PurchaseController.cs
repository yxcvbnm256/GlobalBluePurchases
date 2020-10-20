using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalBluePurchases.BusinessLayer;
using GlobalBluePurchases.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBluePurchases.Controllers
{
    /// <summary>
    /// API Controller for handling purchase to compute requests
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        readonly PurchaseSolver _solver;

        /// <summary>
        /// Controller's constructor. PurchaseSolver class is injected via DI
        /// </summary>
        /// <param name="solver"></param>
        public PurchaseController(PurchaseSolver solver)
        {
            _solver = solver;
        }

        // GET: api/Purchase
        /// <summary>
        /// Method that computes missing tax information about an item purchase. One and only one value from AddedTax, PriceWithoutVAT and PriceWithVAT can be set. VATRate has to be set.
        /// </summary>
        /// <param name="input">Information about a purchase. One and only one value from AddedTax, PriceWithoutVAT and PriceWithVAT can be set.</param>
        /// <returns>Computed purchase.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Purchase), StatusCodes.Status200OK)]
        public ActionResult Get([FromQuery] Purchase input)
        {
            var purchaseType = input.CheckInput();
            if (purchaseType == PurchaseTypeEnum.None) 
            { 
                this.ModelState.AddModelError("MultipleOrNoValues", "One and only one value from addedTax, priceWithoutVat and priceWithVat has to be set.");
                return ValidationProblem();
            }                       
            return Json(_solver.Compute(input, purchaseType));
        }
    }
}
