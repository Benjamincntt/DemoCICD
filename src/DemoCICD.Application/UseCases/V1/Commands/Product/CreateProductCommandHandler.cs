using Application.Abstractions.Message;
using DemoCICD.Domain.Shared;

namespace Application.UseCases.V1.Commands.Product;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    public Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}