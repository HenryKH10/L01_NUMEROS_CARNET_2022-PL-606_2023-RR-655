using System.ComponentModel.DataAnnotations;

namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models
{
    public class comentarios
    {
        [Key]
        public int ComentarioId { get; set; }
        public int PublicacionId { get; set; }  
        public string ComentarioTexto { get; set; }
        public int UsuarioId { get; set; }  
    }
}
