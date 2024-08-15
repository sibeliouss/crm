using Application.Repositories;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest<Customer>
{
  public CreateCustomerCommand(){}
  public CreateCustomerCommand(string name, string email, string phone, string address) :this()
  {
    Name = name;
    Email = email;
    Phone = phone;
    Address = address;
  }

  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Address { get; set; }
  
  public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
  {
    private readonly IValidator<CreateCustomerCommand> _validator;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(
      IValidator<CreateCustomerCommand> validator,
      ICustomerRepository customerRepository)
    {
      _validator = validator;
      _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
      await _validator.ValidateAndThrowAsync(command, cancellationToken);

      var customer = new Customer(command.Name, command.Email, command.Phone, command.Address);

      await _customerRepository.CreateAsync(customer);
      customer = await _customerRepository.LoadAsync(customer.Id);

      return customer;
    }
  } 
    
}