using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.CoisasAFazer.Core.Models
{
    /// <summary>
    /// Representa uma tarefa a ser realizada.
    /// </summary>
    public class Tarefa
    {
        public Tarefa()
        {

        }

        public Tarefa(int id, string titulo, Categoria categoria, DateTime prazo, DateTime? concluidaEm, StatusTarefa status)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Categoria = categoria;
            this.Prazo = prazo;
            this.ConcluidaEm = concluidaEm;
            this.Status = status;
        }

        /// <summary>
        /// Identificador da tarefa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título da tarefa.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Categoria da tarefa.
        /// </summary>
        public Categoria Categoria { get; set; }

        /// <summary>
        /// Prazo da tarefa
        /// </summary>
        public DateTime Prazo { get; set; }

        /// <summary>
        /// Indica quando a tarefa foi concluída
        /// </summary>
        public DateTime? ConcluidaEm { get; set; }

        /// <summary>
        /// Estado atual da tarefa
        /// </summary>
        public StatusTarefa Status { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Titulo}, {Categoria.Descricao}, {Prazo.ToString("dd/MM/yyyy")}";
        }
    }
}
