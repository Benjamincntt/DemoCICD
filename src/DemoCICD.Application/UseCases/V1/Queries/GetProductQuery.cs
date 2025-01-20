using Application.Abstractions.Message;

namespace Application.UseCases.V1.Queries;

public sealed class GetProductQuery : IQuery<GetProductResponse>
{
    public string Name { get; set; }
}