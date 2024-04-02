using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Gym.Entity
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        public string Identificacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        [AllowNull]
        public DateTime FechaNacimiento { get; set; }
        
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        [AllowNull]
        //public DateTime UltimoPago { get; set; } 

        //=
        //DateTime.Now;
        public string Eps { get; set; } = string.Empty;
        public string NombreUsuario {  get; set; } = string.Empty;
        public string Credencial { get; set; } = string.Empty;

    }
}
