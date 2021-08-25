using System;

namespace Alura.CoisasAFazer.Core.Models
{
    /// <summary>
    /// Representa uma classificação dada a <see cref="Tarefa"/>.
    /// </summary>
    public class Categoria
    {
        public Categoria(string descricao)
        {
            Descricao = descricao;
        }

        public Categoria(int id, string descricao) : this(descricao)
        {
            Id = id;
        }

        /// <summary>
        /// Identificador da categoria
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Descricao { get; private set; }
    }
}
