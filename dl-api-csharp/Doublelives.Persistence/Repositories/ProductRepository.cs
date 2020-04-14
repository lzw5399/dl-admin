using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doublelives.Persistence
{
    //public class ProductRepository : Repository<Product>, IProductRepository
    //{
    //    private readonly IAlbumDbContext _context;

    //    public ProductRepository(IAlbumDbContext context)
    //        : base(context)
    //    {
    //        _context = context;
    //    }

    //    public Product FindProductByZuoraId(string zuoraProductId)
    //    {
    //        return _context
    //            .Set<Product>()
    //            .Include(it => it.ProductRatePlans)
    //            .ThenInclude(it => it.ProductRatePlanCharges)
    //            .FirstOrDefault(it => it.ZuoraProductId == zuoraProductId);
    //    }

    //    public Product FindProductContainingRatePlan(string zuoraPlanId)
    //    {
    //        return _context
    //            .Set<Product>()
    //            .Include(it => it.ProductRatePlans)
    //            .ThenInclude(it => it.ProductRatePlanCharges)
    //            .FirstOrDefault(it => it.ProductRatePlans.Any(p => p.ZuoraProductRatePlanId == zuoraPlanId));
    //    }

    //    public ProductRatePlan FindRatePlanByZuoraId(string zuoraPlanId)
    //    {
    //        return AllRatePlans.FirstOrDefault(it => it.ZuoraProductRatePlanId == zuoraPlanId);
    //    }

    //    public ProductRatePlan FindOneTimeOrderPlan(string countryOrganization, string bundleKey)
    //    {
    //        return AllRatePlans.FirstOrDefault(it => it.IsOneTimeOrderOf(countryOrganization, bundleKey));
    //    }

    //    public List<Product> GetAllProducts()
    //    {
    //        return AllProducts
    //            .ToList();
    //    }

    //    public List<ProductRatePlan> GetRatePlansByZuoraIds(string[] zuoraPlanIds)
    //    {
    //        var list = new List<ProductRatePlan>();

    //        if (zuoraPlanIds != null && zuoraPlanIds.Length > 0)
    //        {
    //            list = AllRatePlans
    //                .Where(it => zuoraPlanIds.Contains(it.ZuoraProductRatePlanId))
    //                .ToList();
    //        }

    //        return list;
    //    }

    //    public List<Product> GetProductsByBundleKeys(string[] bundleKeys)
    //    {
    //        var list = new List<Product>();

    //        if (bundleKeys != null && bundleKeys.Length > 0)
    //        {
    //            list = AllProducts
    //                .Where(it => it.ProductRatePlans.Any(p => bundleKeys.Contains(p.BundlePlan)))
    //                .ToList();
    //        }

    //        return list;
    //    }

    //    public List<ProductRatePlan> GetDiscountPlans()
    //    {
    //        return AllRatePlans
    //            .Where(it => it.SubscriptionModelType == ZuoraProductSubscriptionModelType.DISCOUNT)
    //            .ToList();
    //    }

    //    private IQueryable<ProductRatePlan> AllRatePlans
    //    {
    //        get
    //        {
    //            return _context
    //                .Set<ProductRatePlan>()
    //                .Include(it => it.Product)
    //                .Include(it => it.ProductRatePlanCharges);
    //        }
    //    }

    //    private IQueryable<Product> AllProducts
    //    {
    //        get
    //        {
    //            return _context
    //                .Set<Product>()
    //                .Include(it => it.ProductRatePlans)
    //                .ThenInclude(it => it.ProductRatePlanCharges);
    //        }
    //    }

    //    IQueryable<Product> IRepository<Product>.GetAsQueryable()
    //    {
    //        throw new NotImplementedException("Should not use this method any more, it's going to be removed on interface soon.");
    //    }
    //}
}
