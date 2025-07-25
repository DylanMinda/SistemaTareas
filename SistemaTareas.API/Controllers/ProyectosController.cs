using Dapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTareas.API.Models;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        public DbConnection connection;

        public ProyectosController(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            connection = new MySqlConnector.MySqlConnection(connectionString);
            connection.Open();
        }

        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var proyectos = connection.Query<Proyecto>("SELECT * FROM proyectos").ToList();
            return proyectos;
        }

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var proyecto = connection.QuerySingle<Proyecto>("SELECT * FROM proyectos WHERE Id = @Id", new { Id = id });
            return proyecto;
        }

        [HttpPost]
        public dynamic Post([FromBody] dynamic proyecto)
        {
            connection.Execute(
               "INSERT INTO proyectos (Id,Nombre, UsuarioId) " +
               "VALUES (@Id,@Nombre, @UsuarioId)",
               new
               {
                   Id = proyecto.Id,
                   Nombre = proyecto.Nombre,
                   UsuarioId = proyecto.UsuarioId
               });
            return proyecto;
        }

        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Proyecto proyecto)
        {
            connection.Execute(
                "UPDATE proyectos SET Nombre = @Nombre, UsuarioId = @UsuarioId WHERE Id = @Id", proyecto);
            return proyecto;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute(
                "DELETE FROM proyectos WHERE Id = @Id", new { Id = id });
        }
    }
}
