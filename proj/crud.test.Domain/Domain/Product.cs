using crud.test.Abstraction.Domain;
using crud.test.Domain.DomainEvents;
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

    public Product(Product product)
    {
        IsAvailable = product.IsAvailable;
        ManufactureEmail = product.ManufactureEmail;
        ManufacturePhone = product.ManufacturePhone;
        Name = product.Name;
        ProduceDate = product.ProduceDate;
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

    public Product UpdateStatus(Product updatedProduct)
    {
        var lastState = new Product(this);
        IsAvailable = updatedProduct.IsAvailable;
        ManufactureEmail = updatedProduct.ManufactureEmail;
        ManufacturePhone = updatedProduct.ManufacturePhone;
        Name = updatedProduct.Name;
        ProduceDate = updatedProduct.ProduceDate;
        AddEvent(new ProductUpdatedEvent(lastState, this));
        return this;
    }

    public Email GetEmail()
    {
        return ManufactureEmail;
    }

    public Date GetProduceDate()
    {
        return ProduceDate;
    }
}