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
            var contatos = _context.Contatos.Where(contato => contato.IdCliente == cliente.Id);
            _context.Contatos.RemoveRange(contatos);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public Cliente? Find(Cliente cliente)
        {
            return _context.Clientes.Include("Contatos").First(x => x.Id == cliente.Id);
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
