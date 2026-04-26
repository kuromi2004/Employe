using Employees.Dominio.interfaces;
using Employees.Infraestructura.Contexto;


namespace Employees.Infraestructura.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesDbContext _DbContext;

        public UnitOfWork(EmployeesDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _DbContext.SaveChangesAsync();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
               return new GenericRepository<T>(_DbContext);
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}