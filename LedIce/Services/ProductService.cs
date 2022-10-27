using LedIce.Data;
using LedIce.Data.DTO;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services;

public class ProductService : Service
{
    public ProductService(Context context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var result = await (from p in Context.Products
                            where p.Enabled
                            orderby p.SortOrder
                            select new ProductDTO
                            {
                                Name = p.Name,
                                Description = p.Description,
                                Attributes = (from a in p.ProductAttributes
                                              where a.Attribute.Enabled
                                              orderby a.Attribute.SortOrder
                                              select new AttributeDTO
                                              {
                                                  Name = a.Attribute.Name,
                                                  Value = a.Value
                                              }).ToList()
                            }).ToListAsync();

        //var query = Context.Products
        //    .Where(p => p.Enabled)
        //    .OrderBy(p => p.SortOrder)
        //    .Select(p => new ProductDTO
        //    {
        //        Name = p.Name,
        //        Description = p.Description,
        //        Attributes = p.ProductAttributes
        //            .Where(a => a.Attribute.Enabled)
        //            .OrderBy(a => a.Attribute.SortOrder)
        //            .Select(a => new AttributeDTO
        //            {
        //                Name = a.Attribute.Name,
        //                Value = a.Value
        //            }).ToList()
        //    });

        //var result = await query.ToListAsync();

        return result;
    }
}
