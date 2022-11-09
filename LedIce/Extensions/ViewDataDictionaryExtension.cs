using LedIce.DTO;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LedIce.Extensions;

public static class ViewDataDictionaryExtension
{
    public static void SetMeta(this ViewDataDictionary viewData, Meta page)
    {
        viewData["Title"] = page.Title;
        viewData["Description"] = page.Description;
        viewData["Keyword"] = page.Keywords;
    }
}
