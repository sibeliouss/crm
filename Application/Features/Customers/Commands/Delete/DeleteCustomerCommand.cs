using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.Delete;

public class DeleteCustomerCommand : IRequest
{
   public Guid CustomerId { get; set; } 
   
   public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
   {
      private readonly ICustomerRepository _customerRepository;

      public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
      {
         _customerRepository = customerRepository;
      }

      public async Task Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
      {
         var customer = await _customerRepository.LoadAsync(command.CustomerId);
         if (customer != null) await _customerRepository.DeleteAsync(customer);
      }
   }
   
}