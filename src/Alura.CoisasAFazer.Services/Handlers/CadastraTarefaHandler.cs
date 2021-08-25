using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using System;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.Services.Handlers
{
    public class CadastraTarefaHandler
    {
        IRepositorioTarefas _repo;
        ILogger<CadastraTarefaHandler> _logger;

        public CadastraTarefaHandler(IRepositorioTarefas repositorio, ILogger<CadastraTarefaHandler> logger)
        {
            _repo = repositorio;
            _logger = logger;
        }

        public CommandResult Execute(CadastraTarefa comando)
        {
            try
            {
                var tarefa = new Tarefa
                (
                    id: 0,
                    titulo: comando.Titulo,
                    prazo: comando.Prazo,
                    categoria: comando.Categoria,
                    concluidaEm: null,
                    status: StatusTarefa.Criada
                );
                    _logger.LogDebug($"Persistindo a tarefa... {tarefa.Titulo}");
                    _repo.IncluirTarefas(tarefa);
                    return new CommandResult(true);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new CommandResult(false);        
            }                       
        }
    }
}
