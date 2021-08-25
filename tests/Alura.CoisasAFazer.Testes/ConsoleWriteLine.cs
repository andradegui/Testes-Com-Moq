using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Alura.CoisasAFazer.Core.Models;

namespace Alura.CoisasAFazer.Testes
{
    public class ConsoleWriteLine
    {
        [Fact]
        public void AoExecutarDeveChamarToStringNoObjetoMockado()
        {
            //arrange
            var mock = new Mock<Tarefa>();
            var tarefa = mock.Object;

            //act
            Console.WriteLine(tarefa);

            //assert
            mock.Verify(t => t.ToString(), Times.Once());
        }
    }
}
