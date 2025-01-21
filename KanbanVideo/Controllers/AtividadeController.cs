using KanbanVideo.Dto;
using KanbanVideo.Services.Atividade;
using Microsoft.AspNetCore.Mvc;

namespace KanbanVideo.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly IAtividadeInterface _atividadeInterface;
        public AtividadeController(IAtividadeInterface atividadeInterface)
        {
            _atividadeInterface = atividadeInterface;
        }
        public async Task<IActionResult> Index()
        {
            var atividades = await _atividadeInterface.BuscarAtividade();
            return View(atividades);
        }
        public async Task<IActionResult> Cadastrar()
        {
            var status = await _atividadeInterface.BuscarStatus();
            
            ViewBag.Status = status;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastroAtividadeDto cadastroAtividadeDto)
        {
            
            if (ModelState.IsValid)
            {
                var atividade = await _atividadeInterface.CadastrarAtividade(cadastroAtividadeDto);
                return RedirectToAction("Index");
            }
            else
            {
                var status = await _atividadeInterface.BuscarStatus();

                ViewBag.Status = status;
                return View(cadastroAtividadeDto);
            }
            
        }

        public async Task<IActionResult> MudarCard(int id)
        {
            var atividade = await _atividadeInterface.MudarCard(id);

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var atividade = await _atividadeInterface.Deletar(id);

            return RedirectToAction("index");
        }
        public async Task<IActionResult> MudarCardAnterior(int id)
        {
            var atividade = await _atividadeInterface.MudarCardAnterior(id);

            return RedirectToAction("index");
        }


    }
}
