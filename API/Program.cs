using AutoMapper;
using Employees.Aplicacion.mapeo;
using Employees.Aplicacion.servicio;

using Employees.Aplicacion.servicio.servicios;
using Employees.Aplicacion.servicio.IServicios;
using Employees.Dominio.interfaces;
using Employees.Infraestructura.Contexto;   
using Employees.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Configure the HTTP request pipeline.



//database configuracion
//builder.Services.AddScoped<EmployeesDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//automapper configuration
builder.Services.AddAutoMapper(cfg => {


    
    cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA4NjExMjAwIiwiaWF0IjoiMTc3NzA4OTc4MyIsImFjY291bnRfaWQiOiIwMTlkYzJiNWI2Mzg3OGNjYWQ1M2MzNTBmNGVlM2E2NCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa3ExY3c5c3IwNWF5NHQzajFxNjBxcmUxIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.TZH4P0FD75Jd9qg2GbS4iQwHr5V-zB5ciaO4JKyolwNVntvQqeZFHutJglNDEjEipeZxzY6lx5_BABCDRSBX9tUwDLCJRoAf9VzXFyKON1jZTmaSReuzTUR8cErgw5sNMHdd7D6YmO2CtQeGDkxbeUGW2u608JazhwiR4JuoUNdP03WTEsIR3TeVeB79m89nsaxFsedOjJE4V0HiVSNOpemWRpV_8qVsfSlKwEu1Ipf3Ek8Tst7U-jd2CgaduJ6NlQL7CaNF7rfImteUF2wID2YgBWiFN3AMsusdZJ69M_xpEh5X4dmO2wlJo8h5VWQvIOjoelxyBIz8phGnNcbUpw";

    cfg.AddProfile<MappingProfile>();
   // cfg.AddProfile<IEmpleadoMapping>();
});
//repositorio y unit of work
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//mapeo de servicios
// === LADO DE LECTURA ===
builder.Services.AddScoped<IEmpresaReadService, EmpresaReadService>(); 
builder.Services.AddScoped<IPeriodoReadService, PeriodoReadService>();
builder.Services.AddScoped<IRegistroJornadaReadService, RegistroJornadaReadService>();
builder.Services.AddScoped<IUsuarioReadService, UsuarioReadService>();
builder.Services.AddScoped<IVacacionReadService, VacacionReadService>();

// === LADO DE ESCRITURA ===
builder.Services.AddScoped<IEmpresaWriteService, EmpresaWriteService>();
builder.Services.AddScoped<IPeriodoWriteService, PeriodoWriteService>();
builder.Services.AddScoped<IRegistroJornadaWriteService, RegistroJornadaWriteService>();
builder.Services.AddScoped<IUsuarioWriteService, UsuarioWriteService>();
builder.Services.AddScoped<IVacacionWriteService, VacacionWriteService>();
//fin mapeo de servicios
//
builder.Services.AddControllers();

builder.Services.AddDbContext<EmployeesDbContext>(options =>
    options.UseInMemoryDatabase("EmployeesDb"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
