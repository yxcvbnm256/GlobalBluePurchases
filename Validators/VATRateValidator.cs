using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalBluePurchases.Validators
{
    /// <summary>
    /// Validation attribute for VAT Rate. Created because within a real API, VAT Rate could be used multiple times. 
    /// </summary>
    public class VATRateAttribute : ValidationAttribute
    {
        /// <summary>
        /// base constructor with error
        /// </summary>
        public VATRateAttribute() : base("The VAT rate field must be 10, 13 or 20.") 
        {
        }

        /// <summary>
        /// Validates whether VAT Rate is a valid value.
        /// </summary>
        /// <param name="value">VAT Rate</param>
        /// <returns></returns>
        public override bool IsValid(object value) => value is int valAsInt && (valAsInt == 10 || valAsInt == 13 || valAsInt == 20);
    }
}
