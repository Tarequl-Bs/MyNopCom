using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.SpecialProducts.Models;
using Nop.Plugin.Widgets.SpecialProducts.Services;
using Nop.Services.Catalog;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.SpecialProducts.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsSpecialProductsController : BasePluginController
    {
        ISpecialProductService _specialProductService;
        IProductService _productService;
        public WidgetsSpecialProductsController(ISpecialProductService specialProductService, IProductService productService)
        {
            _specialProductService = specialProductService;
            _productService = productService;
        }

        public void ChangeIsSpecialStatus(int productId, string isSpecialProduct)
        {
            if (productId > 0)
            {
                var product = _productService.GetProductByIdAsync(productId);

                if (product != null)
                {
                    var isSpecial = isSpecialProduct=="true"? true: false;
                    var sProduct = new SpecialProductModel()
                    {
                        ProductId = productId,
                        IsSpecialProduct = isSpecial
                    };
                    _specialProductService.SetSpecialProduct(sProduct);
                }
            }
        }
        
    }
}
