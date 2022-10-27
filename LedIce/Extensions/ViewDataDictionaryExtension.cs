using LedIce.Data.DTO;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LedIce.Extensions;

public static class ViewDataDictionaryExtension
{
    public static void SetMeta(this ViewDataDictionary viewData, PageMeta page)
    {
        viewData["Title"] = page.Title;
        viewData["Description"] = page.Description;
        viewData["Keyword"] = page.Keyword;
    }
}
