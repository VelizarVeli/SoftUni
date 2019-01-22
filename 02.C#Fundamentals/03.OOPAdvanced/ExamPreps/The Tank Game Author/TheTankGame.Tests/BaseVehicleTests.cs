namespace TheTankGame.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using Entities.Miscellaneous;
    using Entities.Parts;
    using Entities.Vehicles;
    using Entities.Vehicles.Contracts;

    [TestFixture]
    public class VehicleAssemblerTests
    {
        [Test]
        public void ValidateVehicleModel()
        {
            try
            {
                IVehicle firstVehicle = new Revenger("Gosho", 112, 12, 12, 12, 12, new VehicleAssembler());
            }
            catch (Exception ex)
            {
                var excepctedMessage = "Model cannot be null or white space!";

                Assert.AreEqual(excepctedMessage, ex.Message);
            }
        }

        [Test]
        public void ValidateVehiclePartList()
        {
            IVehicle vehicle = new Revenger("Gosho", 112, 12, 12, 12, 12, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("Top", 12, 12, 2));
            vehicle.AddArsenalPart(new ArsenalPart("Test", 22, 1, 3));
            vehicle.AddEndurancePart(new EndurancePart("Hit", 2, 52, 1));
            vehicle.AddShellPart(new ShellPart("Shelche", 2, 52, 1));

            var partsCount = vehicle.Parts.Count();
            var expectedResult = 4;

            Assert.AreEqual(expectedResult, partsCount);
        }

        [Test]
        public void ValidateVehicleToStringMethod()
        {
            IVehicle vehicle = new Revenger("Gosho", 112, 12, 12, 12, 12, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("Top", 12, 12, 2));
            vehicle.AddArsenalPart(new ArsenalPart("Test", 22, 1, 3));
            vehicle.AddEndurancePart(new EndurancePart("Hit", 2, 52, 1));
            vehicle.AddShellPart(new ShellPart("Shelche", 2, 52, 1));

            var expectedResult = "Revenger - Gosho\r\nTotal Weight: 150.000\r\nTotal Price: 129.000\r\nAttack: 17\r\nDefense: 13\r\nHitPoints: 13\r\nParts: Top, Test, Hit, Shelche";
            var actualResult = vehicle.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
