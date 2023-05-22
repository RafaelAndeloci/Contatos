using ContatosQueEuOdeio.Models;

namespace ContatosQueEuOdeio.Services
{
    public interface IClienteService
    {
        public void Create(Cliente cliente);
        public void Update(Cliente cliente);
        public void Delete(Cliente cliente);
        public Cliente? Find(int id);
        public ICollection<Cliente> FindAll();
    }
}
