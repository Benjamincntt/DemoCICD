using DemoCICD.Domain.Shared;
using MediatR;

namespace Application.Abstractions.Message;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}