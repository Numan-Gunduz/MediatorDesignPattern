using MediatorDesignPattern.MediatorPattern.Queries;
using MediatorDesignPattern.MediatorPattern.Results;
using MediatR;
using NuGet.Protocol.Plugins;

namespace MediatorDesignPattern.MediatorPattern.Handlers
{
    public class GetProductUpdateByIdQueryHandler : IRequestHandler<GetProductUpdateByIdQuery, UpdateProductByIdQueryResult>
    {
        private readonly ApplicationDbContext _context;

        public GetProductUpdateByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductByIdQueryResult> Handle(GetProductUpdateByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Products.FindAsync(request.Id);
            return new UpdateProductByIdQueryResult
            {
                ProductCategory = value.ProductCategory,
                ProductName = value.ProductName,
                ProductID = value.ProductID,
                ProductPrice = value.ProductPrice,
                ProductStock = value.ProductStock,
                ProductSTockType = value.ProductSTockType,

            };
        }
    }
}
