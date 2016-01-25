using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBeeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBeeGame.Models.Tests
{
    [TestClass()]
    public class BeeGameTests
    {
        [TestInitialize]
        public void SetupTests()
        {
            // Setup
        }

        [TestMethod()]
        public void Given_GetTitle_Should_return_valid()
        {
            //  Arrange
            var sut = new BeeGame();

            //  Act
            var result = sut.GetTitle();

            //  Assert
            Assert.AreEqual("The Bee Game", result);
        }

        [TestMethod()]
        public void Given_GetTitle_Should_return_Invalid()
        {
            //  Arrange
            var sut = new BeeGame();

            //  Act
            var result = sut.GetTitle();

            //  Assert
            Assert.AreNotEqual("zee Bee Gameeeez", result);
        }


        [TestMethod]
        public void Given_SpawnHive_Should_return_one_QueenBee_Valid()
        {
            //  Arrange
            var sut = new BeeGame(1, 0, 0);

            //  Act
            var result = sut.SpawnHive();

            //  Assert
            Assert.AreEqual(1, result.QueenBees.Count());
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Given_SpawnHive_no_parameters_Should_return_one_QueenBee_null()
        {
            //  Arrange
            var sut = new BeeGame();

            //  Act
            var result = sut.SpawnHive();

            //  Assert
            Assert.AreEqual(1, result.QueenBees.Count());
        }

    }
}