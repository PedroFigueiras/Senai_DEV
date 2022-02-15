
using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.test.Utils
{
    public class CriptografiaTests
    {
        [Fact]
        public void Deve_Retornar_Hash_Em_BCrypt()
        {
            //PRÉ-CONDIÇÃO / ARRANGE
            var senha = Cripitografia.GerarHash("MinhaSenha123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            //PROCEDIMENTO / ACT
            var retorno = regex.IsMatch(senha);

            //RESULTADO ESPERADO / ASSERT
            Assert.True(retorno);
        }
            
        [Fact]

        public void Deve_Retorno_Comparacao_Valida()
        {
            // Pré-Condição
            var senha = "MinhaSenha123456789";
            var hashbanco = Cripitografia.GerarHash("MinhaSenha123456789");

            // Procedimento
            var comparacao = Cripitografia.Comparar(senha, hashbanco);

            // Resultado esperado
            Assert.True(comparacao);



        }
    }
}
