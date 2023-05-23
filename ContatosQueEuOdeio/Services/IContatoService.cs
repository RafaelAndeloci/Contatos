using ContatosQueEuOdeio.Models;

namespace ContatosQueEuOdeio.Services
{
    public interface IContatoService : IService<Contato>
    {
        public ICollection<Contato> FindFromCliente(Cliente cliente);
    }
}
