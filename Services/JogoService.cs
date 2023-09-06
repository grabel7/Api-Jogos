using VideoJogos.Models;

namespace VideoJogos.Services;

public static class JogoService{

    static List<Jogo> Jogos {  get; set;  }
    static int nextId = 3;

    static JogoService(){
        Jogos = new List<Jogo>{
            new() { Id = 1, Nome = "Final Fantasy XVI", EstaDisponivel= true, IdUnico = Guid.NewGuid()},
            new() { Id = 2, Nome = "Spider-Man 2", EstaDisponivel= false, IdUnico = Guid.NewGuid()}
        };
    }

    public static List<Jogo> GetAll() => Jogos;

    public static Jogo? Get(int id) => Jogos.FirstOrDefault(p => p.Id == id);

    public static void Add(Jogo jogo){
        jogo.Id = nextId++;

        Random r = new Random();
        
        if (jogo.EstaDisponivel == true)
        jogo.Compras = r.Next(10,1000);

        jogo.Criada = DateTime.Now;
        var historicoCriacao = new HistoricoAtualizacao
    {
        DataHoraAtualizacao = jogo.Criada,
        Descricao = $"Jogo criado em: {jogo.Criada}"
    };

    // Inicialize a lista de histórico se ainda não estiver
    if (jogo.HistoricoAtualizacoes == null)
    {
        jogo.HistoricoAtualizacoes = new List<HistoricoAtualizacao>();
    }

    // Adicione o registro de histórico à lista de histórico do jogo
    jogo.HistoricoAtualizacoes.Add(historicoCriacao);
        
        jogo.IdUnico = Guid.NewGuid();
        
        Jogos.Add(jogo);
        
    }

    public static void Delete(int id){
        var jogo = Get(id);
        if(jogo is null) return;

        Jogos.Remove(jogo);
    }

public static void Update(Jogo jogo)
        {
            var index = Jogos.FindIndex(j => j.Id == jogo.Id);
            if (index == -1) return;

            // Copie o jogo original para um novo objeto para preservar seu estado original
            var jogoOriginal = new Jogo
            {
                Id = jogo.Id,
                
                Nome = Jogos[index].Nome,
                EstaDisponivel = Jogos[index].EstaDisponivel,
                Compras = Jogos[index].Compras,
                Criada = Jogos[index].Criada,
                IdUnico = Jogos[index].IdUnico
            };

            // Atualize o jogo na lista
            Jogos[index] = jogo;

            // Registre a atualização no histórico
            AdicionarHistoricoAtualizacao(jogo, jogoOriginal);
        }

        // Método para adicionar um registro de histórico de atualização
        private static void AdicionarHistoricoAtualizacao(Jogo jogoAtualizado, Jogo jogoOriginal)
        {
            var index = Jogos.FindIndex(p => p.Id == jogoAtualizado.Id);
            if (index == -1) return;

            // Crie um registro de histórico
            var historico = new HistoricoAtualizacao
            {
                DataHoraAtualizacao = DateTime.Now,
                Descricao = $"Atualização de {jogoOriginal.Nome} para {jogoAtualizado.Nome}"
            };

            // Adicione o registro de histórico à lista de histórico do jogo
            if (Jogos[index].HistoricoAtualizacoes == null)
            {
                Jogos[index].HistoricoAtualizacoes = new List<HistoricoAtualizacao>();
            }

            Jogos[index].HistoricoAtualizacoes.Add(historico);
        }

}