using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries;

public class GetProductQuery :IRequest<Product?>
{
    public Guid ProductId { get; set; }
    
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product?> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAsync(query.ProductId);
        }
    }
}