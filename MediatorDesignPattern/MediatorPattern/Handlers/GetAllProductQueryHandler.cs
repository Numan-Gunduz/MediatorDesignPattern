using MediatorDesignPattern.MediatorPattern.Queries;
using MediatorDesignPattern.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace MediatorDesignPattern.MediatorPattern.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductQueryResult>>
    {
        //IRequestHandler istek ve yanıt parametrelerine ihtiyaç duyar.
        private readonly ApplicationDbContext _applicatonDbContext;

        public GetAllProductQueryHandler(ApplicationDbContext applicatonDbContext)
        {
            _applicatonDbContext = applicatonDbContext;
        }

        public async Task<List<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _applicatonDbContext.Products.Select(x => new GetAllProductQueryResult 
            {
                ProductCategory=x.ProductCategory,
                ProductName=x.ProductName,
                ProductID=x.ProductID,
                ProductPrice=x.ProductPrice,
                ProductStock=x.ProductStock,
                ProductSTockType=x.ProductSTockType  
            }).AsNoTracking().ToListAsync();
        }
    }
}
