using crud.test.Abstraction.Commands;

namespace crud.test.Application.Commands;

public record CreateProductCommand(Guid id ,bool IsAvailable, string ManufactureEmail, string ManufacturePhone,
    DateTime ProduceDate, string Name) : ICommand;