namespace Application.Features.Dtos;

public abstract class ContactDto
{
    public Guid? CustomerId { get; set; }
    public string? Email { get; set; }
}