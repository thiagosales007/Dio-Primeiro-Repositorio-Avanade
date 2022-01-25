using System;
using Xunit;

namespace DIO.Series.Tests
{
    public class SerieRepositorioTests
    {
        [Fact(DisplayName = "DADA uma serie válida QUANDO inserimos ENTAO persistir serie")]
        public void Insere_Sucesso()
        {
            var repositorio = new SerieRepositorio();

            repositorio.Insere(new Serie(1, Genero.Aventura, "TITULO", "", 2021));

            var seriePersistida = repositorio.RetornaPorId(1);

            Assert.NotNull(seriePersistida);
            Assert.Equal("TITULO", seriePersistida.retornaTitulo());
        }
    }
}
