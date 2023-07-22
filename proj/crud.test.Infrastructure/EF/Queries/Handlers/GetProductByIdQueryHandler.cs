using crud.test.Abstraction.Queries;
using crud.test.Application.Dtoes;
using crud.test.Application.Queries;
using crud.test.Application.Services;

namespace crud.test.Infrastructure.EF.Queries.Handlers;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductReadServices _readServices;

    public GetProductByIdQueryHandler(IProductReadServices repository)
    {
        _readServices = repository;
    }

    public async Task<ProductDto> HandleAsync(GetProductByIdQuery query)
    {
        var product = await _readServices.GetAsync(query.Id);
        return product;
    }
}