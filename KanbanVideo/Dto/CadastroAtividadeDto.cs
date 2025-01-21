using System.ComponentModel.DataAnnotations;

namespace KanbanVideo.Dto
{
    public class CadastroAtividadeDto
    {
        [Required(ErrorMessage = "Digite o titulo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Digite o Descrição")]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        [Required(ErrorMessage = "Selecione um status")]
        public int StatusId { get; set; }
    }
}
