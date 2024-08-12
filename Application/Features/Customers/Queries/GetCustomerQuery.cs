using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries;

public class GetCustomerQuery : IRequest<Customer?>
{
    public Guid CustomerId { get; set; }
    
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAsync(query.CustomerId);
        }
    }
    
}