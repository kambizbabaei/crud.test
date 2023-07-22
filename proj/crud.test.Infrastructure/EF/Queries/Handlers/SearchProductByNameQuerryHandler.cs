using crud.test.Abstraction.Queries;
using crud.test.Application.Dtoes;
using crud.test.Application.Queries;
using crud.test.Application.Services;

namespace crud.test.Infrastructure.EF.Queries.Handlers;

public class SearchProductByNameQuerryHandler : IQueryHandler<SearchProductByNameQuery, List<ProductDto>>
{
    private readonly IProductReadServices _readServices;

    public SearchProductByNameQuerryHandler(IProductReadServices repository)
    {
        _readServices = repository;
    }

    public async Task<List<ProductDto>> HandleAsync(SearchProductByNameQuery command)
    {
        var products = (await _readServices.GetAllProducts()).Where(x => x.Name.Contains(command.SearchTerm)).ToList();
        return products;
    }
}