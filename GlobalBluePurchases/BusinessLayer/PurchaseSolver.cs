using GlobalBluePurchases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalBluePurchases.BusinessLayer
{
    /// <summary>
    /// Class used for computing via dependency injection.
    /// </summary>
    public class PurchaseSolver
    {
        /// <summary>
        /// Method that computes missing fields from purchase object.
        /// </summary>
        /// <param name="purchase">Input purchase object.</param>
        /// <param name="type">Controls which properties of purchase object will be computed.</param>
        /// <returns>Computed purchase.</returns>
        public Purchase Compute(Purchase purchase, PurchaseTypeEnum type)
        {
            switch (type)
            {
                case PurchaseTypeEnum.AddedTax:
                    purchase.PriceWithoutVAT = purchase.AddedTax * 100 / purchase.VATRate;
                    purchase.PriceWithVAT = purchase.PriceWithoutVAT + purchase.AddedTax;
                    break;
                case PurchaseTypeEnum.PriceWithoutVAT:
                    purchase.AddedTax = purchase.PriceWithoutVAT * ((double)purchase.VATRate / (double)100);
                    purchase.PriceWithVAT = purchase.PriceWithoutVAT + purchase.AddedTax;
                    break;
                case PurchaseTypeEnum.PriceWithVAT:                    
                    purchase.PriceWithoutVAT = purchase.PriceWithVAT / (((double)purchase.VATRate / (double)100) + 1);
                    purchase.AddedTax = purchase.PriceWithVAT - purchase.PriceWithoutVAT;
                    break;
                default:
                    break;                
            }
            return purchase;
        }
    }
}
