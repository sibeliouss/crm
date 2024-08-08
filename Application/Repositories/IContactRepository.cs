using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IContactRepository : IRepository<Contact>
{
    Task<IList<Contact>> ListAsync(ContactCriteria criteria);
    Task<IPagedList<Contact>> ListAsync(ContactCriteria criteria, int pageSize, int pageNumber);
}

public class ContactCriteria
{
    public Guid? CustomerId { get; set; }
    public string? Email { get; set; }
}
