using crud.test.Abstraction.Queries;
using crud.test.Application.Dtoes;

namespace crud.test.Application.Queries;

public class GetProductByIdQuery : IQuery<ProductDto>
{
    public Guid Id { get; set; }
}