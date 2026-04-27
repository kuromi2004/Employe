namespace Employees.Aplicacion.servicio.IServicios
{
    public interface IWriteServiceAsync<TEntity, TDto> 
        where TEntity : class
        where TDto : class

    {
        Task AddAsync(TDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(TDto dto);
    }
}