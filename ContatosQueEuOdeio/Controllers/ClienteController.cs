using ContatosQueEuOdeio.Models;
using ContatosQueEuOdeio.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContatosQueEuOdeio.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ICollection<Cliente> clientes = _service.FindAll();
            return View(clientes);
        }

        public IActionResult Detalhar(int idCliente)
        {

            Cliente? cli = _service.Find(new Cliente { Id = idCliente});
            return View(cli);
        }

        [HttpGet]
        public IActionResult Editar(int idCliente)
        {

            Cliente cliente = _service.Find(new Cliente { Id = idCliente})!;
            return View("Criar", cliente);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar([Bind("Id", "Nome", "Endereco")] Cliente cliente)
        {
            if (Char.IsDigit(cliente.Nome[0]))
            {
                ModelState.AddModelError("Nome", "Nome não pode iniciar com dígito!");
                return View(cliente);
            }
            if (cliente.Id > 0)
                _service.Update(cliente);
            else
                _service.Create(cliente);
            return RedirectToAction("Index");
        }


        public IActionResult Cancelar()
        {
            return RedirectToAction("Index");
        }


        public IActionResult Remover(int idCliente)
        {
            Cliente? cli = _service.Find(new Cliente { Id = idCliente });
            return View(cli);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Remover([Bind("Id", "Nome", "Endereco")] Cliente cliente)
        {
            _service.Delete(cliente);
            return RedirectToAction("Index");
        }
    }
}
