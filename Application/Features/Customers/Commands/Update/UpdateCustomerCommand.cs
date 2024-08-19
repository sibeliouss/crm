using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Customers.Commands.Update;
//UpdateCustomer prop. record olarak da tanımlanabilir.
public class UpdateCustomerCommand : IRequest
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IValidator<UpdateCustomerCommand> _validator;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(
            IValidator<UpdateCustomerCommand> validator,
            ICustomerRepository customerRepository, IMapper mapper)

        {
            _mapper = mapper;
            _validator = validator;
            _customerRepository = customerRepository;
        }

        public async Task Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(command, cancellationToken);

            var customer = await _customerRepository.LoadAsync(command.CustomerId);
            _mapper.Map(command, customer);
            if (customer != null)
            {
                customer.UpdateDate = DateTime.UtcNow;

                await _customerRepository.UpdateAsync(customer);
            }
        }
    } 
}