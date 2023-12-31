﻿using crud.test.Application.Dtoes;
using crud.test.Application.Services;
using crud.test.Infrastructure.EF.Contexts;
using crud.test.Infrastructure.EF.Models;
using crud.test.Infrastructure.EF.Queries;
using Microsoft.EntityFrameworkCore;

namespace crud.test.Infrastructure.EF.Services;

internal sealed class ProductsReadService : IProductReadServices
{
    private readonly DbSet<ProductReadModel> _products;

    public ProductsReadService(ReadDbContext context)
    {
        _products = context.ProductReadModel;
    }

    public Task<bool> ExistsByNameAsync(string name)
    {
        return _products.AnyAsync(pl => pl.Name == name);
    }

    public async Task<List<ProductDto>> GetProductsByName(string name)
    {
        return _products.Select<ProductReadModel, ProductDto>(x => x.AsDto()).ToList();
    }

    public async Task<List<ProductDto>> GetProductsByManufactureEmail(string email)
    {
        return _products.Where(x => x.ManufactureEmail == email).Select(x => x.AsDto()).ToList();
    }

    public async Task<IQueryable<ProductDto>> GetAllProducts()
    {
        return _products.Select<ProductReadModel, ProductDto>(x => x.AsDto());
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        return (await _products.SingleOrDefaultAsync(product => product.Id == id)).AsDto();
    }
}