using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using VehicleApi.Repositories.Interfaces;
using VehicleApi.Services;

namespace VehicleApi.Services.UnitTest
{
    [TestClass]
    public class VehicleServiceTests
    {
        public VehicleServiceTests()
        {

        }

        [TestMethod]
        public void Validate_Vehicle_Create_Succeeds()
        {
            //ARRANGE
            var _repositoryMock = new Mock<VehicleApi.Repositories.Interfaces.IVehicleRepository>();
            var v = new Models.Vehicle() { Id = 1, Make = "Test", Model = "ABCS", Year = 2015 };
            _repositoryMock.Setup(a => a.Create(v)).Returns(Task.FromResult(true));

            //ACT
            var vehicleService = new VehicleApi.Services.VehicleService(_repositoryMock.Object);
            var a = vehicleService.Create(v).Result;
            
            //ASSERT
            Assert.IsNotNull(a);

        }

        [TestMethod]
        public void Validate_Vehicle_Create_Fails()
        {
            //ARRANGE
            var _repositoryMock = new Mock<VehicleApi.Repositories.Interfaces.IVehicleRepository>();
            var v = new Models.Vehicle() { Id = 1, Make = "Test", Model = "ABCS", Year = 2015 };
            _repositoryMock.Setup(a => a.Create(v)).Returns(Task.FromResult(false));

            //ACT
            var vehicleService = new VehicleApi.Services.VehicleService(_repositoryMock.Object);
            var a = vehicleService.Create(v).Result;

            //ASSERT
            Assert.IsNull(a);

        }



        [TestMethod]
        public void Validate_Vehicle_Update_Succeeds()
        {
            //ARRANGE
            var _repositoryMock = new Mock<VehicleApi.Repositories.Interfaces.IVehicleRepository>();
            var v = new Models.Vehicle() { Id = 1, Make = "Test", Model = "ABCS", Year = 2015 };
            _repositoryMock.Setup(a => a.Update(v)).Returns(Task.FromResult(true));

            //ACT
            var vehicleService = new VehicleApi.Services.VehicleService(_repositoryMock.Object);
            var a = vehicleService.Update(v).Result;

            //ASSERT
            Assert.IsNotNull(a);

        }

        [TestMethod]
        public void Validate_Vehicle_Update_Fails()
        {
            //ARRANGE
            var _repositoryMock = new Mock<VehicleApi.Repositories.Interfaces.IVehicleRepository>();
            var v = new Models.Vehicle() { Id = 1, Make = "Test", Model = "ABCS", Year = 2015 };
            _repositoryMock.Setup(a => a.Update(v)).Returns(Task.FromResult(false));

            //ACT
            var vehicleService = new VehicleApi.Services.VehicleService(_repositoryMock.Object);
            var a = vehicleService.Update(v).Result;

            //ASSERT
            Assert.IsNull(a);

        }
    }
}
