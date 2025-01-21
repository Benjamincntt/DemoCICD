using DemoCICD.Application.Abstractions.Message;
using DemoCICD.Domain.Shared;

namespace DemoCICD.Application.UseCases.V1.Queries;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductResponse>
{
    public Task<Result<GetProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}