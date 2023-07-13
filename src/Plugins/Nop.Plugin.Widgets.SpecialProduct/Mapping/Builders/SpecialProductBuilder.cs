using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.SpecialProducts.Domain;
using Nop.Plugin.Widgets.SpecialProducts.Models;

namespace Nop.Plugin.Widgets.SpecialProducts.Mapping.Builders
{
    public class SpecialProductBuilder : NopEntityBuilder<SpecialProduct>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table //WithColumn(nameof(SpecialProductModel.Id)).AsInt32().PrimaryKey()
            .WithColumn(nameof(SpecialProductModel.ProductId)).AsInt32().ForeignKey<Product>(onDelete: Rule.Cascade)
            .WithColumn(nameof(SpecialProductModel.IsSpecialProduct)).AsBoolean();
        }
    }
}
