using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Payments.CashOnDelivery.Models
{
    public record CODModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Payment.CashOnDelivery.DescriptionText")]
        public string DescriptionText { get; set; }

        [NopResourceDisplayName("Plugins.Payment.CashOnDelivery.AdditionalFee")]
        public decimal AdditionalFee { get; set; }

        [NopResourceDisplayName("Plugins.Payment.CashOnDelivery.AdditionalFeePercentage")]
        public bool AdditionalFeePercentage { get; set; }

        [NopResourceDisplayName("Plugins.Payment.CashOnDelivery.ShippableProductRequired")]
        public bool ShippableProductRequired { get; set; }

    }
}