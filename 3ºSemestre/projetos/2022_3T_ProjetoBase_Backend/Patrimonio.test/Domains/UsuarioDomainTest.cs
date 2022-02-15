



using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.test.Domains
{
    public class UsuarioDomainTest
    {
       [Fact]//Descrição

       public void Deve_Retornar_Usuario()
        {
            //PRÉ-Condiçãoa
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456789";
            //Procedimento
            bool resultado = true;

            if(usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            //Resultado Esperado

            Assert.True(resultado);




        }
    }
}
