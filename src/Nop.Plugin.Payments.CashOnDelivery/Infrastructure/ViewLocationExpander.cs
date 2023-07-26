using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.Payments.CashOnDelivery.Infrastructure
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        private const string THEME_KEY = "nop.themename";

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName == "Admin")
            {
                viewLocations = new[] {
                    $"~/Plugins/Payments.CashOnDelivery/Areas/Admin/Views/Shared/{{0}}.cshtml",
                    $"~/Plugins/Payments.CashOnDelivery/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);
            }
            else
            {
                viewLocations = new[] {
                    $"~/Plugins/Payments.CashOnDelivery/Views/Shared/{{0}}.cshtml",
                    $"~/Plugins/Payments.CashOnDelivery/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);

                if (context.Values.TryGetValue(THEME_KEY, out string theme))
                {
                    viewLocations = new[] {
                        $"~/Plugins/Payments.CashOnDelivery/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                        $"~/Plugins/Payments.CashOnDelivery/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                        $"~/Plugins/Payments.CashOnDelivery/Themes/{theme}/Views/{{0}}.cshtml"
                    }.Concat(viewLocations);
                }
            }

            return viewLocations;
        }
    }
}
