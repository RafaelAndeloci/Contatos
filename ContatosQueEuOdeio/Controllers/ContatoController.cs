using ContatosQueEuOdeio.Models;
using ContatosQueEuOdeio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace ContatosQueEuOdeio.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar os contatos.
    /// </summary>
    public class ContatoController : Controller
    {
        /// <summary>
        /// Contexto de Contato.
        /// </summary>
        private IContatoService _service;

        private List<SelectListItem> _redesSociais = new()
        {
            new SelectListItem() { Value = "Instagram", Text = "Instagram" },
            new SelectListItem() { Value = "TikTok", Text = "TikTok" },
            new SelectListItem() { Value = "Twitter", Text = "Twitter"},
            new SelectListItem() { Value = "Email", Text= "Email"}
        };

        /// <summary>
        /// Injeção de dependencia para os serviços utilizados
        /// </summary>
        /// <param name="service"></param>
        /// <param name="clienteService"></param>
        public ContatoController(IContatoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Action Index que leva à pagina principal de contatos
        /// </summary>
        /// <param name="idCliente">Parâmetro referente ao Cliente, para poder acessar a página Index de Contatos de um cliente específico</param>
        /// <returns>Retorna a View Index dos Contatos do Cliente</returns>
        public IActionResult Index(int idCliente)
        {
            var contatos = _service.FindFromCliente(new Cliente { Id = idCliente });

            return View((idCliente, contatos));
        }


        /// <summary>
        /// Action Criar que será responsável por exibir a view de criação de contatos 
        /// </summary>
        /// <returns>Retorna a View para criar um novo contato</returns>
        public IActionResult Criar(int idCliente)
        {
            ViewBag.IdCliente = idCliente;
            ViewBag.RedesSociais = _redesSociais;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Contato contato)
        {
            ViewBag.IdCliente = contato.IdCliente;

            if (Char.IsDigit(contato.Perfil[0]))
            {
                ModelState.AddModelError("Pefil", "Perfil não pode iniciar com digitos!");
                return RedirectToAction("Index", new { contato.IdCliente });
            }


            _service.Create(contato);
            return RedirectToAction("Index", new { contato.IdCliente } );
        }


        /// <summary>
        /// Action Editar que será responsável por editar um determinado contato.
        /// </summary>
        /// <param name="idCliente">irá especificar o contato a ser editado</param>
        /// <returns>retornará para a pagina Index de Contatos</returns>
        public IActionResult Editar(int idContato, int idCliente)
        {
            var contato = _service.Find(new Contato { Id = idContato , IdCliente = idCliente});
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(Contato contato)
        {
            ViewBag.IdCliente = contato.IdCliente;
            if (contato.Id > 0)
                _service.Update(contato);
            return RedirectToAction("Index", new { contato.IdCliente });
        }

        /// <summary>
        /// Action para levar à pagina de remoção
        /// </summary>
        /// <param name="idCliente">irá especificar o contato a ser removido</param>
        /// <returns>retornará para a pagina Index de Contatos</returns>
        public IActionResult Remover(int idContato, int idCliente)
        {
            var ct = _service.Find(new Contato { Id = idContato, IdCliente = idCliente});
            return View(ct);
        }

        /// <summary>
        /// Action HTTPPost para remover o contato de um determinado cliente.
        /// </summary>
        /// <param name="contato">o contato a ser deletado</param>
        /// <returns>Retornará para a view Index dos contatos do cliente</returns>
        [HttpPost]
        public IActionResult ConfirmarRemocao(int idContato, int idCliente)
        {
            var contato = _service.Find(new Contato { Id = idContato, IdCliente = idCliente })!;
            _service.Delete(contato);
            return Json(new { success = true });
        }
    }
}
