
using apivoemais.Database;
using apivoemais.Model;
using Microsoft.EntityFrameworkCore;

namespace apivoemais.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

         private readonly UsuarioDbcontext _context;

         public UsuarioRepository(UsuarioDbcontext context){
            _context = context;
        }
        public void AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public void DeletarUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
             return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}