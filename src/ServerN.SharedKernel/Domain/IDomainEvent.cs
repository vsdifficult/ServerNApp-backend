namespace Solution.SharedKernel.Domain; 

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
    
    Guid EventId { get; }
}
