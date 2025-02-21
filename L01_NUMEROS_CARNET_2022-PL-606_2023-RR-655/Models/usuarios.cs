using System.ComponentModel.DataAnnotations;

namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models
{
    public class usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public int RolId { get; set; }  
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
