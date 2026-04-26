using Employees.Aplicacion.Handlers.Comandos;
using Employees.Aplicacion.servicio.IServicios;
using MediatR;

namespace Empleados.Aplicacion.Handlers.Handlers
{
	public class GetByIdHandler<T> : IRequestHandler<GetByIdCommand<T>> where T : class
	{
		public GetByIdHandler()
		{

		}
		public Task Handle(GetByIdCommand<T> request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}