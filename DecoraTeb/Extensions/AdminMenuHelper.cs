using Microsoft.AspNetCore.Mvc.Rendering;

namespace DecoraTeb.Extensions;

public static class AdminMenuHelper
{
    public static string IsActive(this IHtmlHelper html, string page)
    {
        var currentPage = html.ViewContext.RouteData.Values["page"]?.ToString();

        if (string.IsNullOrEmpty(currentPage))
            return "";

        return currentPage.StartsWith(page, StringComparison.OrdinalIgnoreCase)
            ? "active"
            : "";
    }

    public static string IsOpen(this IHtmlHelper html, string page)
    {
        var currentPage = html.ViewContext.RouteData.Values["page"]?.ToString();

        if (string.IsNullOrEmpty(currentPage))
            return "";

        return currentPage.StartsWith(page, StringComparison.OrdinalIgnoreCase)
            ? "menu-open"
            : "";
    }
}
