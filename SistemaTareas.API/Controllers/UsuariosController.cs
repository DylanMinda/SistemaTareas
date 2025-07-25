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
    public class UsuariosController : ControllerBase
    {
        public DbConnection connection;

        public UsuariosController(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

             connection = new SqlConnection(connectionString);
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
            var usuario = connection.QuerySingle<Usuario>("SELECT * FROM usuarios WHERE id = @id", new { id = id });
            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public dynamic Post([FromBody] Usuario usuario)
        {
            connection.Execute(
               "INSERT INTO usuarios (id,nombre, email, password) " +
               "VALUES (@id,@nombre, @email, @password)",
               new
               {
                   id = usuario.Id,
                   nombre = usuario.nombre,
                   email = usuario.email,
                   password = usuario.password
               });
            return usuario;
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Usuario usuario)
        {
            connection.Execute(
                "UPDATE usuarios SET Nombre = @Nombre, Email = @Email, Password = @Password  WHERE id = @id", usuario);
            return usuario;
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute(
                "DELETE FROM usuarios  WHERE id = @id", new { id = id });
        }
    }
}
