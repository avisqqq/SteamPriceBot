namespace SteamPriceBot.Domain.Common
{
    public class EntityBase
    {
        public Guid Id { get; protected init; } = Guid.NewGuid();

        private readonly List<object> _domainEvents = new();
        public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(object @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();

        public override bool Equals(object? obj)
        {
            if (obj is not EntityBase other)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }
        public override int GetHashCode() => Id.GetHashCode();

    }
}
