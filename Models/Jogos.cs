namespace VideoJogos.Models;

public class Jogo {
    public int Id { get; set;}
    public string? Nome {get; set;}
    public bool EstaDisponivel { get; set; }

    public int Compras { get; set;}

     public DateTime Criada { get; set; }
     public Guid IdUnico { get; set; }

     public List<HistoricoAtualizacao> HistoricoAtualizacoes { get; set; } = new List<HistoricoAtualizacao>();
}

public class HistoricoAtualizacao
    {
        public DateTime DataHoraAtualizacao { get; set; }
        public string? Descricao { get; set; } // Opcional: para adicionar uma descrição da atualização
    }