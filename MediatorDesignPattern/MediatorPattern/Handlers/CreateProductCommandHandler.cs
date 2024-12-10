using MediatorDesignPattern.Dal;
using MediatorDesignPattern.MediatorPattern.Commands;
using MediatR;

namespace MediatorDesignPattern.MediatorPattern.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
              _context.Products.Add(new Product
            {
                ProductCategory = request.ProductCategory,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductStock = request.ProductStock,
                ProductSTockType = request.ProductSTockType,
            });
            await _context.SaveChangesAsync();  
        }
    }
}
