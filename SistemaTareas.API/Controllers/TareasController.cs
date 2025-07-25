using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaTareas.API.Models;
using System.Data.Common;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        public DbConnection connection;

        public TareasController(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var tareas = connection.Query<Tarea>("SELECT * FROM tareas").ToList();
            return tareas;
        }

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var tarea = connection.QuerySingle<Tarea>("SELECT * FROM tareas WHERE id = @id", new { Id = id });
            return tarea;
        }

        [HttpPost]
        public dynamic Post([FromBody] Tarea tarea)
        {
            connection.Execute(
               "INSERT INTO tareas (id,Titulo, Estado, FechaVencimiento,UsuarioId,ProyectoId) " +
               "VALUES (@id,@titulo, @estado, @fechaVencimiento,@usuarioId,@proyectoId)",
               new
               {
                   id = tarea.Id,
                   titulo = tarea.Titulo,
                   estado = tarea.Estado,
                   fechaVencimiento = tarea.FechaVencimiento,
                   usuarioId = tarea.UsuarioId,
                   proyectoId= tarea.ProyectoId
               });
            return tarea;
        }

        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Tarea tarea)
        {
            connection.Execute(
                "UPDATE tareas SET Titulo = @Titulo, Estado=@Estado, FechaVencimiento=@FechaVencimiento,UsuarioId = @UsuarioId, ProyectoId = @ProyectoId WHERE id = @id", tarea);
            return tarea;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute(
                "DELETE FROM proyectos WHERE id = @id", new { Id = id });
        }
    }
}
