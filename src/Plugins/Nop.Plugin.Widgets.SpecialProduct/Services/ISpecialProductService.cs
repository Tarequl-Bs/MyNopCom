using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.SpecialProducts.Models;

namespace Nop.Plugin.Widgets.SpecialProducts.Services
{
    public interface ISpecialProductService
    {
        SpecialProductModel GetSpecialProductById(int specialProductId);

        SpecialProductModel GetSpecialProductByProductId(int productId);

        void SetSpecialProduct(SpecialProductModel specialProduct);
    }
}
