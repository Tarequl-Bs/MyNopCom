using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.SpecialProducts.Models
{
    public record SpecialProductModel : BaseNopEntityModel
    {

        [NopResourceDisplayName("Plugins.Widgets.SpecialProduct.Fields.SpecialProduct")]
        public bool IsSpecialProduct { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.SpecialProduct.Fields.Product")]
        public int ProductId { get; set; }
    }
}
