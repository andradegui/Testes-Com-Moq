using System;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Core.Commands;

namespace Alura.CoisasAFazer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //problemas e desvantagens:
            //- preciso apontar para um servidor banco de dados para fazer meu teste [NÃO RESOLVIDO...]
            //- estou amarrado a um recurso caro e lento
            //- por ser caro e lento será dividido entre devs e um dev pode atrapalhar os testes do outro
            //- se meu teste for caro e lento eu vou diminuir seu uso

            //solução: possibilitar trocar/alternar o banco de dados; como?
            //- usando o princípio interface/implementação; já estamos fazendo isso através da interface IRepositorioTarefas (check)
            //- abdicando da responsabilidade de criar o objeto, mas mantendo a dependência;  construtor com argumentos informando quais objetos são necessários
            //- já que precisamos passar uma implementação podemos criar nossas próprias classes mais baratas e rápidas!

            var comando = new CadastraTarefa("Estudar Xunit", new Core.Models.Categoria("Estudo"), new DateTime(2019, 12, 31));
            var repo = new RepoFakeTarefas();
            var handler = new CadastraTarefaHandler(repo, null);

            handler.Execute(comando);

            foreach (var tarefa in repo.ObtemTarefas(t => t.Categoria.Descricao == "Estudo"))
            {
                Console.WriteLine(tarefa);
            }
        }
    }
}
