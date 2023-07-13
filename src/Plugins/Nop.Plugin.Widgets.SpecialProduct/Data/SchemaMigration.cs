using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.SpecialProducts.Domain;

namespace Nop.Plugin.Pickup.PickupInStore.Data
{
    [NopMigration("2023/07/13 00:00:03", "Widgets.SpecialProduct base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<SpecialProduct>();
        }
    }
}