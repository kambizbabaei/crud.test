using crud.test.Abstraction.Queries;
using crud.test.Application.Dtoes;

namespace crud.test.Application.Queries;

public class SearchProductByNameQuery : IQuery<List<ProductDto>>
{
    public string SearchTerm { get; set; }
}