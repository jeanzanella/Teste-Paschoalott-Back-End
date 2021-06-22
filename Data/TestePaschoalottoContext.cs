using Microsoft.EntityFrameworkCore;
using Teste_Paschoalott_Back_End.Models;

#nullable disable

namespace Teste_Paschoalott_Back_End.Data
{
    public partial class TestePaschoalottoContext : DbContext
    {
        public TestePaschoalottoContext()
        {
        }

        public TestePaschoalottoContext(DbContextOptions<TestePaschoalottoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parcela> Parcelas { get; set; }
        public virtual DbSet<Titulo> Titulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
