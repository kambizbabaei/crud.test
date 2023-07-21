using crud.test.Domain.Repositories;
using Test.abstraction.Commands;

namespace crud.test.Application.Commands.Handlers;

internal sealed class RemoveProductCommandHandler : ICommandHandler<RemoveProductCommand>
{
    private readonly IProductRepository _repository;

    public RemoveProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveProductCommand command)
    {
        var product = await _repository.GetAsync(command.Id);
        // todo: exception
        await _repository.DeleteAsync(product);
    }
}