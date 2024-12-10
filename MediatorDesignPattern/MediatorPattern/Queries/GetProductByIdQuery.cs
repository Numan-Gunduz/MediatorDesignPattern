using MediatorDesignPattern.MediatorPattern.Results;
using MediatR;

namespace MediatorDesignPattern.MediatorPattern.Queries
{
    public class GetProductByIdQuery:IRequest<GetProductByIdQueryResult>
    {
        public GetProductByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
