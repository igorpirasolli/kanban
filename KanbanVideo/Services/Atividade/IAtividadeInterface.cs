using KanbanVideo.Models;
using KanbanVideo.Dto;

namespace KanbanVideo.Services.Atividade
{
    public interface IAtividadeInterface
    {
        Task<List<AtividadeModel>> BuscarAtividade();
        Task<List<StatusModel>> BuscarStatus();
        Task<AtividadeModel> CadastrarAtividade(CadastroAtividadeDto cadastroAtividadeDto);

        Task<AtividadeModel> MudarCard(int atividadeId);
        Task<AtividadeModel> Deletar(int atividadeId);
        Task<AtividadeModel> MudarCardAnterior(int atividadeId);

    }
}
