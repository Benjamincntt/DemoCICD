using DemoCICD.Application.Abstractions.Message;

namespace DemoCICD.Application.UseCases.V1.Queries;

public sealed class GetProductQuery : IQuery<GetProductResponse>
{
    public string Name { get; set; }
}