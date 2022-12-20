

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
                Empresa = "Clinica de saúde",
                Cargo = "Fisioterapeuta",
                Salario = 10000,
                Descricao = "Uma descrição"
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
                Descricao = "Uma descrição"
            };

            var ex = Assert.Throws<ArgumentException>(() => new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao));

            Assert.Equal("Empresa inválida!", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarVagaComCargoInvalido(string cargo)
        {
            var vagaEsperada = new
            {
                Empresa = "Clinica de saúde",
                Cargo = cargo,
                Salario = 10000,
                Descricao = "Uma descrição"
            };

            var ex = Assert.Throws<ArgumentException>(() => new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao));

            Assert.Equal("Cargo inválido!", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarVagaComDescricaoInvalida(string descricao)
        {
            var vagaEsperada = new
            {
                Empresa = "Clinica de saúde",
                Cargo = "Fisioterapeuta",
                Salario = 10000,
                Descricao = descricao
            };

            var ex = Assert.Throws<ArgumentException>(() => new Vaga(vagaEsperada.Empresa, vagaEsperada.Cargo, vagaEsperada.Salario, vagaEsperada.Descricao));

            Assert.Equal("Descrição inválida!", ex.Message);
        }
    }
}