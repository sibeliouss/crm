
using System.Runtime.InteropServices;
using Application.Features.Dtos;
using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using MediatR;

namespace Application.Features.Customers.Queries;

public class ListCustomerQuery : IRequest<IPagedList<Customer>>
{ 
     public string? Name { get; set; } 
     public int? PageSize { get; set; }
     public int? PageNumber { get; set; }
     
     public sealed class ListCustomerQueryHandler : IRequestHandler<ListCustomerQuery, IPagedList<Customer>>
     {
          private readonly ICustomerRepository _customerRepository;

          public ListCustomerQueryHandler(ICustomerRepository customerRepository)
          {
               _customerRepository = customerRepository;
          }

          public Task<IPagedList<Customer>> Handle(ListCustomerQuery query, CancellationToken cancellationToken)
          {
               var criteria = new CustomerDto()
               {
                    Name = query.Name,
               };

               var pageSize = query.PageSize ?? int.MaxValue;
               var pageNumber = query.PageNumber ?? 1;

               return _customerRepository.ListAsync(criteria, pageSize, pageNumber);
          }
     }
}