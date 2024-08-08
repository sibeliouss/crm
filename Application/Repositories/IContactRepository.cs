
using Application.Features.Dtos;
using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface IContactRepository : IRepository<Contact>
{
    Task<IList<Contact>> ListAsync(ContactDto criteria);
    Task<IPagedList<Contact>> ListAsync(ContactDto criteria, int pageSize, int pageNumber);
}


