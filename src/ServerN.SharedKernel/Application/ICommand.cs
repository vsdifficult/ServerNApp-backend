
using MediatR;

namespace SeverN.SharedKernel.Application;  

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest<Unit>
{
}