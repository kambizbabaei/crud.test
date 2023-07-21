using crud.test.Application.Dtoes;
using crud.test.Infrastructure.EF.Models;

namespace crud.test.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static ProductDto AsDto(this ProductReadModel readModel)
    {
        return new ProductDto
        {
            Id = readModel.Id,
            Name = readModel.Name,
            IsAvailable = readModel.IsAvailable,
            ManufactureEmail = readModel.ManufactureEmail,
            ManufacturePhone = readModel.ManufacturePhone,
            ProduceDate = readModel.ProduceDate
        };
    }
}