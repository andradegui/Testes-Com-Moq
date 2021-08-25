using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class ConsoleReadLine
    {
        [Fact]
        public void AoDigitarTextoDeveRetornarOMesmoTexto()
        {
            //arrange
            var valorEsperado = "Teste";
            var mock = new Mock<TextReader>();
            mock.Setup(t => t.ReadLine()).Returns(valorEsperado);
            var stub = mock.Object;
            Console.SetIn(stub);

            //act
            var valorDigitado = Console.ReadLine();

            //assert
            Assert.Equal(valorEsperado, valorDigitado);
        }
    }
}
