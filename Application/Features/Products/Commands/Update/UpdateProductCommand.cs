using Application.Repositories;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommand: IRequest
{
 public Guid ProductId { get; set; }  
 public string Name { get; set; }
 public decimal Price { get; set; }
 public int Quantity { get; set; }
 public string Description { get; set; }
 
 public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
 {
  private readonly IValidator<UpdateProductCommand> _validator;
  private readonly IProductRepository _productRepository;

  public UpdateProductCommandHandler(
   IValidator<UpdateProductCommand> validator,
   IProductRepository productRepository)
  {
   _validator = validator;
   _productRepository = productRepository;
  }

  public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
  {
   await _validator.ValidateAndThrowAsync(command, cancellationToken);

   var product = await _productRepository.LoadAsync(command.ProductId);

   if (product != null)
   {
    product.Name = command.Name;
    product.Price = command.Price;
    product.Quantity = command.Quantity;
    product.Description = command.Description;
    product.UpdateDate = DateTime.UtcNow;

    await _productRepository.UpdateAsync(product);
   }
  }
 }
}