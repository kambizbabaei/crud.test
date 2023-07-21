using Test.abstraction.Commands;

namespace crud.test.Application.Commands;

public record RemoveProductCommand(Guid Id) : ICommand;