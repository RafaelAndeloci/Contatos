using ContatosQueEuOdeio.Models;

namespace ContatosQueEuOdeio.Services
{
    public class DBContextContato : IContatoService
    {
        private ContatosContext _context;

        public DBContextContato(ContatosContext context)
        {
            _context = context;
        }

        public void Create(Contato contato, int idCliente)
        {
            _context.Clientes
                .Find(idCliente)
                .Contatos
                .Add(contato);
                
            _context.SaveChanges();
        }

        public void Delete(Contato contato)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }

        public Contato? Find(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Contato contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();
        }
    }
}
