using System.ComponentModel.DataAnnotations;

namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models
{
    public class publicaciones
    {
        [Key]
        public int PublicacionId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }  
    }
}
