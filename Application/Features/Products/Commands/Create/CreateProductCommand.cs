using Application.Repositories;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<Product>
{
   public CreateProductCommand()
   {
   }

   public CreateProductCommand(string name, string description, decimal price, int quantity) : this()
   {
      Name = name;
      Description = description;
      Quantity = quantity;
      Price = price;
   }

   public string Name { get; set; }
   public decimal Price { get; set; }
   public int Quantity { get; set; }
   public string Description { get; set; }

   public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
   {
      private readonly IValidator<CreateProductCommand> _validator;
      private readonly IProductRepository _productRepository;

      public CreateProductCommandHandler(
         IValidator<CreateProductCommand> validator,
         IProductRepository productRepository)
      {
         _validator = validator;
         _productRepository = productRepository;
      }

      public async Task<Product?> Handle(CreateProductCommand command, CancellationToken cancellationToken)
      {
         await _validator.ValidateAndThrowAsync(command, cancellationToken);

         var product = new Product(command.Name, command.Price, command.Quantity, command.Description);

         await _productRepository.CreateAsync(product);
         product = await _productRepository.LoadAsync(product.Id);

         return product;
      }
   }
}