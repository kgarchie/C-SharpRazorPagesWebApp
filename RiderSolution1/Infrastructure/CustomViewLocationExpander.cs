using Microsoft.AspNetCore.Mvc.Razor;

namespace RiderSolution1.Infrastructure;

public class CustomViewLocationExpander : IViewLocationExpander
{
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        foreach (var location in viewLocations)
        {
            yield return location;
        }
        yield return "Pages/{1}/{0}.cshtml";
        yield return "Pages/Shared/{0}.cshtml";
    }

    public void PopulateValues(ViewLocationExpanderContext context) { }
}