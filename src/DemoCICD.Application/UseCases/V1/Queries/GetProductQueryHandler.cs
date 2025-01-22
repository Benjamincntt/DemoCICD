using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Contract.Shared;

namespace DemoCICD.Application.UseCases.V1.Queries;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductResponse>
{
    public Task<Result<GetProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}