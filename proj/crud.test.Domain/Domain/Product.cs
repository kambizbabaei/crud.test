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
    public ProductId Id { get; private set; }


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
    

    public void UpdateStatus(Product updatedProduct)
    {
        var lastState = GetCopy();
        IsAvailable = updatedProduct.IsAvailable;
        ManufactureEmail = updatedProduct.ManufactureEmail;
        ManufacturePhone = updatedProduct.ManufacturePhone;
        Name = updatedProduct.Name;
        ProduceDate = updatedProduct.ProduceDate;
        AddEvent(new ProductUpdatedEvent(lastState, this));
    }

    private Product GetCopy()
    {
        return new Product(Id, IsAvailable, ManufactureEmail, ManufacturePhone, ProduceDate, Name);
    }
}