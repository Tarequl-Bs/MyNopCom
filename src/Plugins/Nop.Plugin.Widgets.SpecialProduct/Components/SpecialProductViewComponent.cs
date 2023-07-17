using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.SpecialProducts.Models;
using Nop.Plugin.Widgets.SpecialProducts.Services;
using Nop.Services.Catalog;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.SpecialProducts.Components
{
    public class SpecialProductViewComponent : NopViewComponent
    {
        ISpecialProductService _specialProductService;
        IProductService _productService;
        public SpecialProductViewComponent(ISpecialProductService specialProductService, IProductService productService)
        {
            _specialProductService = specialProductService;
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            if (widgetZone == "admin_product_details_block")
            {
                if (additionalData is ProductModel model3)
                {
                    if (model3.Id > 0)
                    {
                        var returnModel = _specialProductService.GetSpecialProductByProductId(model3.Id);
                        if (returnModel == null)
                        {
                            returnModel = new SpecialProductModel()
                            {
                                ProductId = model3.Id,
                                IsSpecialProduct = false
                            };

                        }
                        return View("~/Plugins/Widgets.SpecialProducts/Views/SetIsSpecial.cshtml", returnModel);
                    }
                }
            }
            else if (additionalData is ProductOverviewModel model)
            {
                var returnModel = _specialProductService.GetSpecialProductByProductId(model.Id);
                return View(returnModel);
            }
            else if (additionalData is ProductDetailsModel model2)
            {
                var returnModel = _specialProductService.GetSpecialProductByProductId(model2.Id);
                return View(returnModel);
            }

            return Content("");
        }
    }
}
