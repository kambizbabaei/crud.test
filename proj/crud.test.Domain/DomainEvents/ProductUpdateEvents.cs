using crud.test.Abstraction.Domain;
using crud.test.Domain.Domain;

namespace crud.test.Domain.DomainEvents;

public record ProductUpdatedEvent(Product ProductLastState, Product ProductNewState) : IDomainEvent;