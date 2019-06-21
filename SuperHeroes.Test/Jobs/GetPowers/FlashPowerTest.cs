
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Jobs.Powers.GetPower;

namespace SuperHeroes.Test.Jobs.GetPowers
{
    [TestClass]
    public class FlashPowerTest
    {
        public FlashPower _powerTest;
        public IPowerContext _context;

        public FlashPowerTest()
        {
            _powerTest = new FlashPower(null);
            _context = new PowerContext();
        }

        [TestMethod]
        public void GetPowerFlash_LowerCase_Success()
        {
            //Arrange
            string superHero = "flash";
            _context.Create(superHero);

            //Act
            var result = _powerTest.GetPower(_context);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Success.NameHero, superHero);
        }

        [TestMethod]
        public void GetPowerFlash_UpperCase_Success()
        {
            //Arrange
            string superHero = "FLASH";
            _context.Create(superHero);

            //Act
            var result = _powerTest.GetPower(_context);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Success.NameHero, superHero);
        }

        [TestMethod]
        public void GetPowerFlash_AnotherHero_Error()
        {
            //Arrange
            string superHero = "Batman";
            _context.Create(superHero);

            //Act
            var result = _powerTest.GetPower(_context);

            //Assert
            Assert.IsTrue(result.IsError);            
        }
    }
}
