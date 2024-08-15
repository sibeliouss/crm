using Application.Repositories;
using Domain.Entities;
using Domain.Pages;
using MediatR;

namespace Application.Features.Products.Queries;

public class ListProductQuery : IRequest<IPagedList<Product>> 
{
   //opsiyonel
   public string? Name { get; set; }
   public int? PageSize { get; set; }
   public int? PageNumber { get; set; }
   
   public class ListProductQueryHandler : IRequestHandler<ListProductQuery, IPagedList<Product>>
   {
      private readonly IProductRepository _productRepository;

      public ListProductQueryHandler(IProductRepository productRepository)
      {
         _productRepository = productRepository;
      }

      public Task<IPagedList<Product>> Handle(ListProductQuery query, CancellationToken cancellationToken)
      {
         var criteria = new ProductCriteria()
         {
            Name = query.Name,
         };

         var pageSize = query.PageSize ?? int.MaxValue;
         var pageNumber = query.PageNumber ?? 1;

         return _productRepository.ListAsync(criteria, pageSize, pageNumber);
      }
   }
}