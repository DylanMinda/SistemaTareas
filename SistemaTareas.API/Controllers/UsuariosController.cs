using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using SistemaTareas.API.Models;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public DbConnection connection;

        public UsuariosController(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            connection = new SqlServerServiceCollectionExtensions.SqlConnection(connectionString);
            connection.Open();
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var empleados = connection.Query<Usuario>("SELECT * FROM usuarios").ToList();
            return empleados;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var usuario = connection.QuerySingle<Usuario>("SELECT * FROM usuarios WHERE Id = @Id", new { Id = id });
            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public dynamic Post([FromBody] dynamic usuario)
        {
            connection.Execute(
               "INSERT INTO usuarios (Id,Nombre, Email, Password) " +
               "VALUES (@Id,@Nombre, @Email, @Password)",
               new
               {
                   Id = usuario.Id,
                   Nombre = usuario.Nombre,
                   Email = usuario.Email,
                   Password = usuario.Password
               });
            return usuario;
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Usuario usuario)
        {
            connection.Execute(
                "UPDATE usuarios SET Nombre = @Nombre, Email = @Email, Password = @Password WHERE Id = @Id", usuario);
            return usuario;
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute(
                "DELETE FROM usuarios WHERE Id = @Id", new { Id = id });
        }
    }
}
