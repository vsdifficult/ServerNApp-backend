
namespace SeverN.SharedKernel.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; } 
    
    public BaseStatus Status { get; set; }
}