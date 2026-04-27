using AutoMapper;
using Employees.Aplicacion.servicio.IServicios;
using Employees.Dominio.interfaces;

namespace Employees.Aplicacion.servicio
{
	
	public class WriteServiceAsync<TEntity, TDto> : IWriteServiceAsync<TEntity, TDto>
		where TEntity : class
		where TDto : class
	{
		protected readonly IMapper _mapper;
		protected readonly IUnitOfWork _unitOfWork;

		public WriteServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public virtual async Task AddAsync(TDto dto)
		{
			var entity = _mapper.Map<TEntity>(dto);
			await _unitOfWork.Repository<TEntity>().AddAsync(entity);
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task UpdateAsync(TDto dto)
		{
			var entity = _mapper.Map<TEntity>(dto);
			await _unitOfWork.Repository<TEntity>().UpdateAsync(entity);
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task DeleteAsync(int id)
		{
			await _unitOfWork.Repository<TEntity>().DeleteByIdAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}