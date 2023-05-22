using ContatosQueEuOdeio.Models;

namespace ContatosQueEuOdeio.Services
{
    public interface IContatoService
    {
        public void Create(Contato contato, int idCliente);
        public void Update(Contato contato);
        public void Delete(Contato contato);
        public Contato? Find(int id);
    }
}
