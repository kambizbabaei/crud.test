using crud.test.Application.Dtoes;

namespace test.Application.Services;

public interface IProductReadServices
{
    Task<bool> ExistsByNameAsync(string name);

    Task<List<ProductDto>> GetProductsByName(string name);

    Task<IQueryable<ProductDto>> GetAllProducts();
    Task<ProductDto> GetAsync(Guid id);
}