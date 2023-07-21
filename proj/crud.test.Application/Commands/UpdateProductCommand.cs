using crud.test.Abstraction.Commands;
using crud.test.Domain.Domain;

namespace crud.test.Application.Commands;

public record UpdateProductCommand(Product UpdateFields, Guid Userid) : ICommand;