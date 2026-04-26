namespace Employees.Aplicacion.servicio.IServicios
{
    public interface IWriteServiceAsync<TEntity, TDto> 
        where TEntity : class
        where TDto : class

    {
        Task AddAsync(TDto dto);
        Task DeleteAsync(TDto dto);
        Task UpdateAsync(TDto dto);
    }
}