using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Alura.CoisasAFazer.WebApp.Models
{
    public class CadastraTarefaVM
    {
        public string Titulo { get; set; }
        public int IdCategoria { get; set; }
        public DateTime Prazo { get; set; }
    }
}
