using Microsoft.EntityFrameworkCore;
using Stored_Procedure.Model;

namespace Stored_Procedure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
