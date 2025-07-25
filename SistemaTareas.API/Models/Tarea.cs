namespace SistemaTareas.API.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVencimiento{ get; set; }
        public int UsuarioId { get; set; } // ID del usuario asignado
        public int ProyectoId { get; set; } // ID del proyecto al que pertenece la tarea
        // Navegación
        public Usuario? Usuario { get; set; }
        public Proyecto? Proyecto { get; set; }
    }
}
