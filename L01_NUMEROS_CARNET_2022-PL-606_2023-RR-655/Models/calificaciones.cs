using System.ComponentModel.DataAnnotations;

namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models
{
    public class calificaciones
    {
        [Key]
        public int CalificacionId { get; set; }
        public int PublicacionId { get; set; }  
        public int UsuarioId { get; set; }  
        public int CalificacionValor { get; set; }  
    }
}
