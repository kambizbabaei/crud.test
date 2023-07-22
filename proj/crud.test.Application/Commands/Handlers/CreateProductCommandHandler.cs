using crud.test.Abstraction.Commands;
using crud.test.Domain.Factories;
using crud.test.Domain.Repositories;

namespace crud.test.Application.Commands.Handlers;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductFactory _productFactory;
    public readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository, IProductFactory productFactory)
    {
        _repository = repository;
        _productFactory = productFactory;
    }

    public async Task HandleAsync(CreateProductCommand command)
    {
        var p = _productFactory.Create(command.id,command.IsAvailable, command.ManufactureEmail,
            command.ManufacturePhone, command.ProduceDate, command.Name);
        var product = await _repository.AddAsync(p);
        var productEntity = await _repository.AddAsync(product);
    }
}