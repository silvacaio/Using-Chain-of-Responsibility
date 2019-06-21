
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Jobs.Powers.GetPower;

namespace SuperHeroes.Test.Jobs.GetPowers
{
    [TestClass]
    public class BatmanPowerTest
    {
        public BatmanPower _powerTest;
        public IPowerContext _context;

        public BatmanPowerTest()
        {
            _powerTest = new BatmanPower(null);
            _context = new PowerContext();
        }

        [TestMethod]
        public void GetPowerBatman_LowerCase_Success()
        {
            //Arrange
            string superHero = "Batman";
            _context.Create(superHero);

            //Act
            var result = _powerTest.GetPower(_context);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Success.NameHero, superHero);
        }

        [TestMethod]
        public void GetPowerBatman_UpperCase_Success()
        {
            //Arrange
            string superHero = "BATMAN";
            _context.Create(superHero);

            //Act
            var result = _powerTest.GetPower(_context);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Success.NameHero, superHero);
        }

        [TestMethod]
        public void GetPowerBatman_AnotherHero_Error()
        {
            //Arrange
            string superHero = "Hulk";
            _context.Create(superHero);

            //Act
            var result = _powerTest.GetPower(_context);

            //Assert
            Assert.IsTrue(result.IsError);            
        }
    }
}
