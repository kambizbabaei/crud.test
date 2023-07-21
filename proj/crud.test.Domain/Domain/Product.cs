using crud.test.Abstraction.Domain;
using crud.test.Domain.ValueObjects.Product;

namespace crud.test.Domain.Domain;

public class Product : AggregateRoot<ProductId>
{
    private bool IsAvailable;
    private Email ManufactureEmail;
    private Phone ManufacturePhone;
    private ProductName Name;
    private Date ProduceDate;

    public Product()
    {
    }

    internal Product(ProductId id, bool isAvailable, Email manufactureEmail, Phone manufacturePhone, Date produceDate,
        ProductName name)
    {
        IsAvailable = isAvailable;
        ManufactureEmail = manufactureEmail;
        ManufacturePhone = manufacturePhone;
        ProduceDate = produceDate;
        Name = name;
        Id = id;
    }

    public ProductId Id { get; private set; }

    public Product UpdateStatus(Product updatdProduct)
    {
        IsAvailable = updatdProduct.IsAvailable;
        ManufactureEmail = updatdProduct.ManufactureEmail;
        ManufacturePhone = updatdProduct.ManufacturePhone;
        Name = updatdProduct.Name;
        ProduceDate = updatdProduct.ProduceDate;
        return this;
    }
}