using ContatosQueEuOdeio.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatosQueEuOdeio.Services
{
    public class DBContextCliente : IClienteService
    {
        private readonly ContatosContext _context;

        public DBContextCliente(ContatosContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            var contatos = _context.Contatos.Where(contato => contato.Id == cliente.Id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public Cliente? Find(int id)
        {
            return _context.Clientes.Include(p => p.Contatos).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Cliente> FindAll()
        {
            return _context.Clientes.ToList();
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }
    }
}
