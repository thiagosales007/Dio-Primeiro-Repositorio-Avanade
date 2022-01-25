using Bogus;
using DIO.Series.Interfaces;
using DIO.Series.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DIO.Series.Web.Tests
{
    public class SerieControllerTests
    {
        private Faker<SerieModel> ConstruirFakeSerieModel()
        {
            return new Faker<SerieModel>()
                .RuleFor(_ => _.Titulo, _ => _.Name.FirstName());
        }

        [Fact(DisplayName = "DADA uma serie valida QUANDO inserimos ENTAO chamar o repositorio para inserir.")]
        public void Insere_Sucesso()
        {
            //Arrange (Preparar)
            SerieModel model = ConstruirFakeSerieModel().Generate();

            //Crio um repositorio MOCK
            var repositorio = new Mock<IRepositorio<Serie>>();
            //Definio que sempre ao chamar o ProximoId vai retornar 1
            repositorio.Setup(_ => _.ProximoId()).Returns(1);
            //Criando o controller
            var controller = new SerieController(repositorio.Object);
            
            //Act (Agir)
            //Inserindo uma serie
            controller.Insere(model);

            //Assert (Validar)
            //validando que o metodo Insere do repositorio foi chamado exatamente 1 vez.
            repositorio.Verify(_ => _.Insere(It.Is<Serie>(_ => _.Id == 1 && _.retornaTitulo() == model.Titulo)), Times.Once);
        }
    }
}
