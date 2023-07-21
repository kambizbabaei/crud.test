using crud.test.Domain.Repositories;
using Test.abstraction.Commands;

namespace crud.test.Application.Commands.Handlers;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(UpdateProductCommand command)
    {
        var product = await _repository.GetAsync(command.UpdateFields.Id);
        // todo: exception 
        await _repository.UpdateAsync(command.UpdateFields);
    }
}