using GlobalBluePurchases.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GlobalBluePurchases.Models
{
    /// <summary>
    /// Purchase information object. As an input, one and only one value from AddedTax, PriceWithoutVAT and PriceWithVAT can be set. VATRate has to be set.
    /// As an output all the missing information are computed.
    /// </summary>
    [DataContract]
    public class Purchase
    {
        /// <summary>
        /// VAT Rate (percentage). Has to be set. Allowed values: 10, 13, 20.
        /// </summary>
        [DataMember(Name = "vatRate")]
        [Required]
        [VATRate]
        public int VATRate { get; set; }

        /// <summary>
        /// Added tax for purchased item. If set, has to be over 0.
        /// </summary>
        [Range(Double.Epsilon, Double.MaxValue, ErrorMessage = "Value has to be greater than 0.")]
        public double? AddedTax { get; set; }

        /// <summary>
        /// Item's price without VAT. If set, has to be over 0.
        /// </summary>
        [Range(Double.Epsilon, Double.MaxValue, ErrorMessage = "Value has to be greater than 0.")]
        public double? PriceWithoutVAT { get; set; }

        /// <summary>
        /// Item's price with VAT. If set, has to be over 0.
        /// </summary>
        [Range(Double.Epsilon, Double.MaxValue, ErrorMessage = "Value has to be greater than 0.")]
        public double? PriceWithVAT { get; set; }

        /// <summary>
        /// Checks which information about a purchase is present.
        /// </summary>
        /// <returns> If multiple values (PriceWithVAT, PriceWithoutVAT, AddedTax) are set, return false, otherwise return true.</returns>
        public PurchaseTypeEnum CheckInput()
        {
            if (AddedTax > 0 && !PriceWithoutVAT.HasValue && !PriceWithVAT.HasValue)            
                return PurchaseTypeEnum.AddedTax;                            
            else if (PriceWithVAT > 0 && !AddedTax.HasValue && !PriceWithoutVAT.HasValue)            
                return PurchaseTypeEnum.PriceWithVAT;                            
            else if (PriceWithoutVAT > 0 && !AddedTax.HasValue && !PriceWithVAT.HasValue)            
                return PurchaseTypeEnum.PriceWithoutVAT;            
            return PurchaseTypeEnum.None;
        }

    }

    /// <summary>
    /// Enum that says which information about purchase is set. 
    /// </summary>
    public enum PurchaseTypeEnum
    {
        /// <summary>
        /// Error value
        /// </summary>
        None = 0,
        /// <summary>
        /// Added tax is set - compute others.
        /// </summary>
        AddedTax,
        /// <summary>
        /// Price without VAT is set - compute others.
        /// </summary>
        PriceWithoutVAT,
        /// <summary>
        /// Price with VAT is set - compute others.
        /// </summary>
        PriceWithVAT
    }
}
