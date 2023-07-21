using crud.test.Domain.Domain;
using crud.test.Domain.ValueObjects.Product;

namespace crud.test.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetAsync(ProductId id);

    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);

    Task SaveChangesAsync();
}