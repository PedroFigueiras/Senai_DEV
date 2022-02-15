using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patrimonio.test.Controllers
{
    public class LoginControllerTests
    {


        [Fact]
        public void Deve_Retornar_Usuario_Invalido()
        {
            //Pré-Condição /ARRANGE
            var fakeRepo = new Mock<IUsuarioRepository>();
            fakeRepo
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);



            var fakeViewModel = new LoginViewModel();
            fakeViewModel.Email = "samuel@email.com";
            fakeViewModel.Senha = "xoudaxuxaparabaixinhos";

            var controller = new LoginController(fakeRepo.Object);

            //Procedimento / Act
            var resultado = controller.Login(fakeViewModel);

            //Resultado Eperado / Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_Usuario_Valido()
        {
            //Pré-Condição /ARRANGE

            var fakeUsuario = new Usuario();
            fakeUsuario.Email = "pedro@gmail.com";
            fakeUsuario.Senha = "bonitao";

            var fakeRepo = new Mock<IUsuarioRepository>();
            fakeRepo
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(fakeUsuario);
            
            var fakeViewModel = new LoginViewModel();
            fakeViewModel.Email = "samuel@email.com";
            fakeViewModel.Senha = "xoudaxuxaparabaixinhos";

            var controller = new LoginController(fakeRepo.Object);

            //Procedimento / Act
            var resultado = controller.Login(fakeViewModel);

            //Resultado Eperado / Assert
            Assert.IsType<OkObjectResult>(resultado);
        }


    }
}
