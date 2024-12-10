using MediatorDesignPattern.MediatorPattern.Commands;
using MediatR;

namespace MediatorDesignPattern.MediatorPattern.Handlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly ApplicationDbContext _context;

        public RemoveProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Products.Find(request.Id);
            _context.Products.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
