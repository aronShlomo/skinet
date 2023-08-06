using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            addInclude(x => x.ProductType);
            addInclude(x => x.ProductBrand);
        }

        public ProductWithTypesAndBrandsSpecification(int id)
        : base(x => x.Id == id)
        {
            addInclude(x => x.ProductType);
            addInclude(x => x.ProductBrand);
        }
    }
}