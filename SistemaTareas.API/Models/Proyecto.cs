namespace SistemaTareas.API.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; } // ID del usuario propietario del proyecto
        // Navegación
        public Usuario? Usuario { get; set; }
        public List<Tarea>? Tareas { get; set; } = new List<Tarea>();
    }
}
