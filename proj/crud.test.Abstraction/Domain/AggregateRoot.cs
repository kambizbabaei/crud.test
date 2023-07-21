namespace crud.test.Abstraction.Domain;

public abstract class AggregateRoot<T>
{
    private readonly List<IDomainEvent> _events = new();
    private bool _versionIncremented;
    public T Id { get; protected set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
        }

        _events.Add(@event);
    }

    public void ClearEvent()
    {
        _events.Clear();
    }


    protected void IncrementVersion()
    {
        if (_versionIncremented) return;

        Version++;
        _versionIncremented = true;
    }
}