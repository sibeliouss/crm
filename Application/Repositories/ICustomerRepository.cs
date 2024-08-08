using Application.Features.Dtos;
using Domain.Entities;
using Domain.Pages;

namespace Application.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IList<Customer>> ListAsync(CustomerDto criteria);
    Task<IPagedList<Customer>> ListAsync(CustomerDto criteria, int pageSize, int pageNumber);
}

