using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.test.Controllers
{
    public class EquipamentoControllerTests
    {
        [Fact]
        public void Deve_Retornar_Equipamento_Pelo_Id()
        {
            //Pré-Condição /ARRANGE
            var fakeRepo = new Mock<IEquipamentoRepository>();


            fakeRepo
                .Setup(x => x.BuscarPorID(It.IsAny<int>()))
                .Returns((Equipamento)null);

            var fakeID = 5;

            //Procedimento / Act
            var controller = new EquipamentosController(fakeRepo.Object);

            var GetEquipamentoFake = controller.GetEquipamento(fakeID);

            bool resultado = false;
            if (GetEquipamentoFake != null)
            {
                resultado = true;
            }


            //Resultado Eperado / Assert
            Assert.True(resultado);
        }
    }
}
