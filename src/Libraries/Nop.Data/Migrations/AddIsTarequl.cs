using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations
{
    [NopMigration("2023/07/10 00:00:00", "Product. Add IsTarequl property", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class AddIsTarequl : AutoReversingMigration
    {
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            Create.Column(nameof(Product.IsTarequl))
            .OnTable(nameof(Product))
            .AsBoolean()
            .Nullable();
        }
    }
}
