using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.SpecialProducts.Domain
{
    public class SpecialProduct : BaseEntity
    {
        public bool IsSpecialProduct { get; set; }
        public int ProductId { get; set; }
    }
}
