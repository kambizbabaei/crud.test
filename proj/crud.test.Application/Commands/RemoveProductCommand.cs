using crud.test.Abstraction.Commands;

namespace crud.test.Application.Commands;

public record RemoveProductCommand(Guid Id) : ICommand;