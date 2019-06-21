using Convert.Domain.Interfaces.Powers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Jobs.Powers;
using SuperHeroes.Domain.Models;

namespace SuperHeroes.Test.Jobs
{
    [TestClass]
    public class PowerJobTest
    {
        public PowerJob _jobTest;
        public PowerJobContext _jobContextJob;

        public Mock<IPower> _power;
        public Mock<IPowerContext> _powerContext;

        public PowerJobTest()
        {
            _powerContext = new Mock<IPowerContext>();
            _power = new Mock<IPower>(null);

            _jobContextJob = new PowerJobContext();
            _jobTest = new PowerJob(_power.Object, _powerContext.Object);
        }

        [TestMethod]
        public void GetPower_ExistSuperHero_Success()
        {
            //Arrange
            string superHero = "Flash";

            _jobContextJob.SuperHero = superHero;

            _powerContext.Setup(s => s.Create(_jobContextJob.SuperHero));
            _power.Setup(s => s.GetPower(_powerContext.Object)).Returns(new Power(superHero, "Speed", 700));

            //Act
            var result = _jobTest.GetPower(_jobContextJob);

            //Assert

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Success.NameHero, superHero);
        }


        [TestMethod]
        public void GetPower_NotExistSuperHero_Error()
        {
            //Arrange
            string superHero = "Flash";

            _jobContextJob.SuperHero = superHero;

            _powerContext.Setup(s => s.Create(_jobContextJob.SuperHero));
            _power.Setup(s => s.GetPower(_powerContext.Object)).Returns("Não encontrado");

            //Act
            var result = _jobTest.GetPower(_jobContextJob);

            //Assert

            Assert.IsTrue(result.IsError);
        }


        [TestMethod]
        public void GetPower_NotExistSuperHero_CallNextRule()
        {
            //Arrange
            string superHero = "Flash";

            _jobContextJob.SuperHero = superHero;

            _powerContext.Setup(s => s.Create(_jobContextJob.SuperHero));
            _power.Setup(s => s.GetPower(_powerContext.Object)).Returns(Result<Power>.ICantResolver());

            //Act
            var result = _jobTest.GetPower(_jobContextJob);

            //Assert

            Assert.IsTrue(result.IsAnotherRule);
            Assert.IsFalse(result.IsError);
            Assert.IsFalse(result.IsSuccess);
        }
    }
}
