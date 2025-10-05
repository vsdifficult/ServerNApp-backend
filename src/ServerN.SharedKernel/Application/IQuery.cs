using MediatR;

namespace SeverN.SharedKernel.Application;  

public interface IQuery<TResponse> : IRequest<TResponse>
{
}