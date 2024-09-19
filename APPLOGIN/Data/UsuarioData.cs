using APPLOGIN.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLOGIN.Data
{
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public UsuarioData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }

        public Task<List<Usuario>> ListaUsuarios()
        {
            var lista = _conexaoBD
                .Table<Usuario>()
                .ToListAsync();
            return lista;
        }

        public Task<Usuario> ObtemUsuario(string email, string senha)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(x => x.Email == email && x.Senha == senha)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public Task<Usuario> ObtemUsuario(Guid id)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return usuario;
        }
        public async Task<int> SalvaUsuario(Usuario usuario)
        {
            var usuarioIsSalvo = await ObtemUsuario(usuario.Id);

            if(usuarioIsSalvo == null)
            {
                return await _conexaoBD.InsertAsync(usuario);
            }
            else
            {
                return await _conexaoBD.UpdateAsync(usuario);
            }
        }

        public async Task<int> ExcluiUsuario(Guid id)
        {
            return await _conexaoBD.DeleteAsync(id);
        }
    }
}
