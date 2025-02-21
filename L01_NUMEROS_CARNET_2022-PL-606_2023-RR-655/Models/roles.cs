using System.ComponentModel.DataAnnotations;

namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models
{
    public class roles
    {
        [Key]
        public int RolId { get; set; }
        public string Rol { get; set; }
    }
}
