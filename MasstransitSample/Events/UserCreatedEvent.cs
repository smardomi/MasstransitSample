namespace MasstransitSample.Events
{
    public class UserCreatedEvent
    {
        public UserCreatedEvent()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
