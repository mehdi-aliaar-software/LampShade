using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductRepository : RepositoryBase<int, Product>, IProductRepository
{
    private readonly ShopContext _context;

    public ProductRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public EditProduct GetDetails(int id)
    {
        var product = _context.Products.Select(x=> new EditProduct { 
            Id=x.Id,
            Name=x.Name, Description=x.Description, CategoryId=x.CategoryId, Code=x.Code,  Keywords=x.Keywords,
            MetaDescription=x.MetaDescription, Picture=x.Picture, PictureAlt=x.PictureAlt, PictureTitle=x.PictureTitle,
            ShortDescription=x.ShortDescription, UnitPrice=x.UnitPrice, Slug=x.Slug
        } ) .FirstOrDefault(p => p.Id == id);
        return product;
    }

    public List<ProductViewModel> Search(ProductSearchModel searchModel)
    {
        var query = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Category = x.Category.Name,
            CategoryId = x.CategoryId,
            Picture = x.Picture,
            Code = x.Code,
            UnitPrice = x.UnitPrice,
            CreationDate=x.CreationDate.ToString()
        });

        if (! string.IsNullOrWhiteSpace (  searchModel.Name))
        {
            query= query.Where(x => x.Name.Contains(searchModel.Name));
        }

        if (!string.IsNullOrWhiteSpace(searchModel.Code))
        {
            query = query.Where(x => x.Code.Contains(searchModel.Code));
        }

        if (searchModel.CategoryId!=0)
        {
            query = query.Where(x => x.CategoryId ==searchModel.CategoryId);
        }

        return query.OrderByDescending(x => x.Id).ToList();

    }
}