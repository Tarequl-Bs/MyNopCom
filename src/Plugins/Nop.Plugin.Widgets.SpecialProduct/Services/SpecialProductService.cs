using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Widgets.SpecialProducts.Domain;
using Nop.Plugin.Widgets.SpecialProducts.Models;
using Nop.Services.Catalog;

namespace Nop.Plugin.Widgets.SpecialProducts.Services
{
    public class SpecialProductService : ISpecialProductService
    {
        private readonly IRepository<SpecialProduct> _specialProductRepository;

        public SpecialProductService(IRepository<SpecialProduct> specialProductRepository)
        {
            _specialProductRepository = specialProductRepository;
        }

        public virtual SpecialProductModel GetSpecialProductById(int specialProductId)
        {
            var specialProduct = _specialProductRepository.GetById(specialProductId);
            if (specialProduct == null)
                return null;
            var specialProductModel = new SpecialProductModel()
            {
                Id = specialProduct.Id,
                ProductId = specialProduct.ProductId,
                IsSpecialProduct = specialProduct.IsSpecialProduct,
            };
            return specialProductModel;
        }

        public virtual SpecialProductModel GetSpecialProductByProductId(int productId)
        {
            var query = _specialProductRepository.Table;

            var specialProduct = query.Where(c => c.ProductId == productId).FirstOrDefault();
            if (specialProduct == null)
                return null;
            var specialProductModel = new SpecialProductModel()
            {
                Id = specialProduct.Id,
                ProductId = specialProduct.ProductId,
                IsSpecialProduct = specialProduct.IsSpecialProduct,
            };
            return specialProductModel;
        }

        public virtual void SetSpecialProduct(SpecialProductModel specialProduct)
        {
            if (specialProduct == null)
                throw new ArgumentNullException();
            if (specialProduct.ProductId == 0)
                return;
            var query = _specialProductRepository.Table;

            var sProduct = query.Where(c => c.ProductId == specialProduct.ProductId).FirstOrDefault();

            if (sProduct == null)
            {
                var specialProductt = new SpecialProduct()
                {
                    ProductId = specialProduct.ProductId,
                    IsSpecialProduct = specialProduct.IsSpecialProduct,
                };
                _specialProductRepository.Insert(specialProductt);
                return;
            }

            sProduct.IsSpecialProduct = specialProduct.IsSpecialProduct;
            _specialProductRepository.Update(sProduct);
        }
    }
}
