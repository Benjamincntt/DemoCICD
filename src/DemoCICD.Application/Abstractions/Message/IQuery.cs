using DemoCICD.Domain.Shared;
using MediatR;

namespace DemoCICD.Application.Abstractions.Message;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}