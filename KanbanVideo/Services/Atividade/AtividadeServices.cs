using KanbanVideo.Data;
using KanbanVideo.Dto;
using KanbanVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanVideo.Services.Atividade
{
    public class AtividadeServices : IAtividadeInterface
    {
        private readonly AppDbContext _Context;
        public AtividadeServices( AppDbContext context )
        {
            _Context = context;
        }
        public async Task<List<AtividadeModel>> BuscarAtividade()
        {
            try
            {
                var atividades = await _Context.atividade.Include(x => x.Status).ToListAsync();
                return atividades;
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StatusModel>> BuscarStatus()
        {

            try
            {
                var status = await _Context.status.ToListAsync();
                return status;
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> CadastrarAtividade(CadastroAtividadeDto cadastroAtividadeDto)
        {
            try
            {

                Random rand = new Random();

                var atividade = new AtividadeModel()
                {
                    Titulo = cadastroAtividadeDto.Titulo,
                    Descricao = cadastroAtividadeDto.Descricao,
                    StatusId = cadastroAtividadeDto.StatusId,
                    Matricula = rand.Next(1000, 100000)
                };
                _Context.atividade.Add(atividade);
                await _Context.SaveChangesAsync();

                return atividade ;

            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> Deletar(int atividadeId)
        {
            try
            {
                var atividade = await _Context.atividade.FindAsync(atividadeId);
                _Context.Remove(atividade);
                await _Context.SaveChangesAsync();

                return atividade;
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> MudarCard(int atividadeId)
        {
            try
            {
                var atividade = await _Context.atividade.FindAsync(atividadeId);
                atividade.StatusId++;

                _Context.Update(atividade);
                await _Context.SaveChangesAsync();
                return atividade;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> MudarCardAnterior(int atividadeId)
        {
            try
            {
                var atividade = await _Context.atividade.FindAsync(atividadeId);
                atividade.StatusId--;

                _Context.Update(atividade);
                await _Context.SaveChangesAsync();
                return atividade;
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
