using Dapper;
using Microsoft.AspNetCore.Mvc;
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

            connection = new MySqlConnector.MySqlConnection(connectionString);
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
            var tarea = connection.QuerySingle<Tarea>("SELECT * FROM tareas WHERE Id = @Id", new { Id = id });
            return tarea;
        }

        [HttpPost]
        public dynamic Post([FromBody] dynamic tarea)
        {
            connection.Execute(
               "INSERT INTO tareas (Id,Titulo, UsuarioId,ProyectoId) " +
               "VALUES (@Id,@Titulo, @UsuarioId,@ProyectoId)",
               new
               {
                   Id = tarea.Id,
                   Titulo = tarea.Titulo,
                   UsuarioId = tarea.UsuarioId,
                   ProyectoId= tarea.ProyectoId
               });
            return tarea;
        }

        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Tarea tarea)
        {
            connection.Execute(
                "UPDATE tareas SET Titulo = @Titulo, UsuarioId = @UsuarioId, ProyectoId = @ProyectoId WHERE Id = @Id", tarea);
            return tarea;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute(
                "DELETE FROM proyectos WHERE Id = @Id", new { Id = id });
        }
    }
}
