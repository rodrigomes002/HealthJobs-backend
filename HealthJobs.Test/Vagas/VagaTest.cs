

using ExpectedObjects;
using HealthJobs.Domain.Vagas;

namespace HealthJobs.Test.Vagas
{
    public class VagaTest
    {
        [Fact]
        public void DeveCriarVaga()
        {
            var vagaEsperada = new
            {
                Empresa = "Clinica de sa�de",
                Cargo = "Fisioterapeuta",
                Salario = 10000,
                Descricao = "Uma descri��o"
            };

            var vaga = new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao);

            vagaEsperada.ToExpectedObject().ShouldMatch(vaga);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarVagaComEmpresaInvalida(string empresa)
        {
            var vagaEsperada = new
            {
                Empresa = empresa,
                Cargo = "Fisioterapeuta",
                Salario = 10000,
                Descricao = "Uma descri��o"
            };

            var ex = Assert.Throws<ArgumentException>(() => new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao));

            Assert.Equal("Empresa inv�lida!", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarVagaComCargoInvalido(string cargo)
        {
            var vagaEsperada = new
            {
                Empresa = "Clinica de sa�de",
                Cargo = cargo,
                Salario = 10000,
                Descricao = "Uma descri��o"
            };

            var ex = Assert.Throws<ArgumentException>(() => new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao));

            Assert.Equal("Cargo inv�lido!", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarVagaComDescricaoInvalida(string descricao)
        {
            var vagaEsperada = new
            {
                Empresa = "Clinica de sa�de",
                Cargo = "Fisioterapeuta",
                Salario = 10000,
                Descricao = descricao
            };

            var ex = Assert.Throws<ArgumentException>(() => new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao));

            Assert.Equal("Descri��o inv�lida!", ex.Message);
        }
    }
}