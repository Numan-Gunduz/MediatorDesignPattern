using MediatorDesignPattern.MediatorPattern.Queries;
using MediatorDesignPattern.MediatorPattern.Results;
using MediatR;

namespace MediatorDesignPattern.MediatorPattern.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetProductByIdQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _applicationDbContext.Products.FindAsync(request.Id);
            return new GetProductByIdQueryResult
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductStock = values.ProductStock,
                ProductPrice = values.ProductPrice,
                ProductCategory = values.ProductCategory,
                ProductSTockType = values.ProductSTockType 
                
            };
        }
    }
}
