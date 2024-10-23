namespace CrudTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Altere o nome da propriedade conforme necessário
        public string Descricao { get; set; } // Altere o nome da propriedade conforme necessário
        public bool Completo { get; set; } // Altere o nome da propriedade conforme necessário
        public DateTime DataCriacao { get; set; } = DateTime.Now; // Altere o nome da propriedade conforme necessário
    }
}
