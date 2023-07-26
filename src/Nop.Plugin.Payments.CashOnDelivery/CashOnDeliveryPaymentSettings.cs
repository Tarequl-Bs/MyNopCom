using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.CashOnDelivery
{
    public class CashOnDeliveryPaymentSettings : ISettings
    {
        public string DescriptionText { get; set; }
        public bool AdditionalFeePercentage { get; set; }
        public decimal AdditionalFee { get; set; }
        public bool ShippableProductRequired { get; set; }
    }
}
