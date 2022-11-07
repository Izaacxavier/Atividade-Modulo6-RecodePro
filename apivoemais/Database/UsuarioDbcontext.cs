using apivoemais.Model;
using Microsoft.EntityFrameworkCore;

namespace apivoemais.Database
{
    public class UsuarioDbcontext : DbContext
    {
       public UsuarioDbcontext(DbContextOptions<UsuarioDbcontext>
        options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder){
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.id);
            usuario.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataDeNascimento).HasColumnName("data_de_nascimento").IsRequired();
            usuario.Property(x => x.Telefone).HasColumnName("telefone").IsRequired();
            usuario.Property(x => x.Email).HasColumnName("email").IsRequired();
            usuario.Property(x => x.Senha).HasColumnName("senha").IsRequired();
        }

    }
}