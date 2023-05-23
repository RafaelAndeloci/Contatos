using ContatosQueEuOdeio.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatosQueEuOdeio.Services
{
    public class DBContextContato : IContatoService
    {
        private ContatosContext _context;

        public DBContextContato(ContatosContext context)
        {
            _context = context;
        }

        public void Create(Contato entity)
        {
            _context.Contatos.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Contato entity)
        {
            _context.Contatos.Remove(entity);
            _context.SaveChanges();
        }

        public Contato? Find(Contato entity)
        {
            return _context.Contatos.FirstOrDefault(
                ct => ct.Id == entity.Id && ct.IdCliente == entity.IdCliente);
        }

        public ICollection<Contato> FindAll()
        {
            return _context.Contatos.ToList();
        }

        public ICollection<Contato> FindFromCliente(Cliente cliente)
        {
            return _context
                .Contatos
                .Include("IdClienteNavigation")
                .Where(ct => ct.IdCliente == cliente.Id)
                .ToList();
        }

        public void Update(Contato contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();
        }
    }
}
