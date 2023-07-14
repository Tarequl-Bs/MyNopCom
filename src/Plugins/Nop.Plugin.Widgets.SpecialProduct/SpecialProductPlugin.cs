using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Nop.Plugin.Widgets.SpecialProducts.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.SpecialProducts
{
    public class SpecialProductPlugin : BasePlugin, IWidgetPlugin
    {
        protected readonly ILocalizationService _localizationService;
        public SpecialProductPlugin(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
        public bool HideInWidgetList => true;
        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(SpecialProductViewComponent);
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.ProductDetailsOverviewTop, PublicWidgetZones.ProductBoxAddinfoBefore, AdminWidgetZones.ProductDetailsBlock });
        }

        public override async Task InstallAsync()
        {
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.SpecialProduct.Fields.IsSpecialProduct"] = "IsSpecialProduct",
                ["Plugins.Widgets.SpecialProduct.Fields.IsSpecialProduct.Hint"] = "Specify Is Special Product."
            });

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.SpecialProducts");

            await base.UninstallAsync();
        }
    }
}