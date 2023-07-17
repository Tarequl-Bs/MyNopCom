using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.Widgets.SpecialProducts.Infrastructure
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
                    $"~/Plugins/Widgets.SpecialProducts/Areas/Admin/Views/Shared/{{0}}.cshtml",
                    $"~/Plugins/Widgets.SpecialProducts/Areas/Admin/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);
            }
            else
            {
                viewLocations = new[] {
                    $"~/Plugins/Widgets.SpecialProducts/Views/Shared/{{0}}.cshtml",
                    $"~/Plugins/Widgets.SpecialProducts/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);

                if (context.Values.TryGetValue(THEME_KEY, out string theme))
                {
                    viewLocations = new[] {
                        $"~/Plugins/Widgets.SpecialProducts/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                        $"~/Plugins/Widgets.SpecialProducts/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                        $"~/Plugins/Widgets.SpecialProducts/Themes/{theme}/Views/{{0}}.cshtml"
                    }.Concat(viewLocations);
                }
            }

            return viewLocations;
        }
    }
}
