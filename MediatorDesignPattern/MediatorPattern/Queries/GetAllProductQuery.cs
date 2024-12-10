using MediatorDesignPattern.MediatorPattern.Results;
using MediatR;

namespace MediatorDesignPattern.MediatorPattern.Queries
{
    public class GetAllProductQuery:IRequest<List<GetAllProductQueryResult>>
    {
    }
}
