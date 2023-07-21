using crud.test.Domain.Domain;
using crud.test.Domain.Repositories;
using crud.test.Domain.ValueObjects.Product;
using crud.test.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace crud.test.Infrastructure.EF.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly DbSet<Product> _products;
    private readonly WriteDbContext _writeDbContext;


    public ProductRepository(DbSet<Product> products, WriteDbContext writeDbContext)
    {
        _products = products;
        _writeDbContext = writeDbContext;
    }


    public async Task<Product?> GetAsync(ProductId id)
    {
        return await _products.SingleOrDefaultAsync(product => product.Id == id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        var productEntity = await _products.AddAsync(product);
        return productEntity.Entity;
    }

    public Task UpdateAsync(Product product)
    {
        _products.Update(product);
        return Task.CompletedTask;
    }


    public Task DeleteAsync(Product product)
    {
        _products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _writeDbContext.SaveChangesAsync();
    }
}