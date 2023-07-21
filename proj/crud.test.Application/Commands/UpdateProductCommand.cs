using crud.test.Domain.Domain;
using Test.abstraction.Commands;

namespace crud.test.Application.Commands;

public record UpdateProductCommand(Product UpdateFields, Guid Userid) : ICommand;