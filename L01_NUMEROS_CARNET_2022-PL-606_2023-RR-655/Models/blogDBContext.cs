using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models
{
    public class blogDBContext: DbContext
    {
        public blogDBContext(DbContextOptions<blogDBContext> options) : base(options)
        {

        }
    }
}