using System;
using System.Collections.Generic;
using Xunit;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Alura.CoisasAFazer.Core.Models;
using Moq;
using System.Linq;

namespace Alura.CoisasAFazer.Testes
{
    public class GerenciaPrazoDasTarefasHandlerExecute
    {
        [Fact]
        public void QuandoPassarDoPrazoDeveColocarTarefasEmAtraso()
        {
            //arrange: determinada massa de tarefas na base, algumas com prazo vencido
            var massaInicial = new List<Tarefa>
            {
                //atrasadas a partir de 1/1/2019
                new Tarefa(1, "Tirar lixo", new Categoria("Casa"), new DateTime(2018,12,31), null, StatusTarefa.Criada),
                new Tarefa(4, "Fazer o almoço", new Categoria("Casa"), new DateTime(2017,12,1), null, StatusTarefa.Criada),
                new Tarefa(9, "Ir à academia", new Categoria("Saúde"), new DateTime(2018,12,31), null, StatusTarefa.Criada),
                new Tarefa(7, "Concluir o relatório", new Categoria("Trabalho"), new DateTime(2018,5,7), null, StatusTarefa.Pendente),
                new Tarefa(10, "Beber água", new Categoria("Saúde"), new DateTime(2018,12,31), null, StatusTarefa.Criada),
                //dentro do prazo em 1/1/2019
                new Tarefa(8, "Comparecer à reunião", new Categoria("Trabalho"), new DateTime(2018,11,12), new DateTime(2018,11,30), StatusTarefa.Concluida),
                new Tarefa(2, "Arrumar a cama", new Categoria("Casa"), new DateTime(2019,4,5), null, StatusTarefa.Criada),
                new Tarefa(3, "Escovar os dentes", new Categoria("Higiene"), new DateTime(2019,1,2), null, StatusTarefa.Criada),
                new Tarefa(5, "Comprar presente pro João", new Categoria("Compras"), new DateTime(2019,10,8), null, StatusTarefa.Criada),
                new Tarefa(6, "Comprar ração", new Categoria("Compras"), new DateTime(2019,11,20), null, StatusTarefa.Criada),
            };
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("Testes de Integração")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);
            repo.IncluirTarefas(massaInicial.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019,1,1));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefas = repo.ObtemTarefas(t => t.Status == StatusTarefa.EmAtraso);
            Assert.Equal(5, tarefas.Count());
        }

        [Fact]
        public void AoExecutarDeveAtualizarTarefasNoRepo()
        {
            //arrange/setup do mock
            var dataHoraAtual = new DateTime(2019, 1, 1);
            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;
            var comando = new GerenciaPrazoDasTarefas(dataHoraAtual);
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            mock.Verify(r => r.AtualizarTarefas(It.IsAny<Tarefa[]>()), Times.Once());
        }
    }
}
