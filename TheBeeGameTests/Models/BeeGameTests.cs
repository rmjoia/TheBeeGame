using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBeeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TheBeeGame.Models.Tests
{
    [TestClass()]
    public class BeeGameTests
    {
        private BeeGame sut;

        [TestInitialize]
        public void SetupTests()
        {
            sut = new BeeGame();
        }

        [TestMethod(), TestCategory("Title"), Owner("Ricardo Melo Joia")]
        public void Given_GetTitle_Should_return_valid()
        {
            //  Arrange

            //  Act
            var result = sut.GetTitle();

            //  Assert
            Assert.AreEqual("The Bee Game", result);
        }

        [TestMethod(), TestCategory("Title"), Owner("Ricardo Melo Joia")]
        public void Given_GetTitle_Should_return_Invalid()
        {
            //  Arrange

            //  Act
            var result = sut.GetTitle();

            //  Assert
            Assert.AreNotEqual("zee Bee Gameeeez", result);
        }


        [TestMethod, TestCategory("QueenBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_one_QueenBee_Valid()
        {
            //  Arrange
            var sut = new BeeGame(1, 1, 1);

            //  Act
            var result = sut.SpawnHive();

            var queen = result.Hive
                .Where(b => b.GetType().Equals(typeof(Queen)))
                .Select(b => b);

            //  Assert
            Assert.AreEqual(1, queen.Count());
        }

        [TestMethod, TestCategory("QueenBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_two_QueenBees_Invalid()
        {
            //  Arrange
            var sut = new BeeGame(2, 1, 1);

            //  Act
            var result = sut.SpawnHive();

            var queen = result.Hive
                .Where(b => b.GetType().Equals(typeof(Queen)))
                .Select(b => b);

            //  Assert
            Assert.IsTrue(queen.Count() != 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException)), TestCategory("QueenBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_no_parameters_Should_return_one_QueenBee_null()
        {
            //  Arrange
            var sut = new BeeGame(0,0,0);

            //  Act
            try
            {
                var result = sut.SpawnHive();
            }
            catch (Exception e)
            {
                //  Assert
                Assert.AreEqual("Queen Bees Quantity Can't be 0", e.Message);
                throw;
            } 
        }

        [TestMethod, TestCategory("WorkerBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_five_WorkerBees_Valid()
        {
            //  Arrange
            var sut = new BeeGame(1, 5, 1);

            //  Act
            var result = sut.SpawnHive();

            var workers = result.Hive
                .Where(b => b.GetType().Equals(typeof(Worker)))
                .Select(b => b);

            //  Assert
            Assert.AreEqual(5, workers.Count());
        }

        [TestMethod, TestCategory("WorkerBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_one_WorkerBees_Invalid()
        {
            //  Arrange
            var sut = new BeeGame(1, 1, 1);

            //  Act
            var result = sut.SpawnHive();

            var workers = result.Hive
                .Where(b => b.GetType().Equals(typeof(Worker)))
                .Select(b => b);

            //  Assert
            Assert.IsTrue(workers.Count() != 5);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException)), TestCategory("WorkerBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_no_parameters_Should_return_WorkerBee_null()
        {
            //  Arrange
            var sut = new BeeGame(1, 0, 0);

            //  Act
            try
            {
                var result = sut.SpawnHive();
            }
            catch (Exception e)
            {
                //  Assert
                Assert.AreEqual("Worker Bees Quantity Can't be 0", e.Message);
                throw;
            }
        }

        [TestMethod, TestCategory("DroneBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_eight_DroneBees_Valid()
        {
            //  Arrange
            var sut = new BeeGame(1, 1, 8);

            //  Act
            var result = sut.SpawnHive();

            var drones = result.Hive
                .Where(b => b.GetType().Equals(typeof(Drone)))
                .Select(b => b);

            //  Assert
            Assert.AreEqual(8, drones.Count());
        }

        [TestMethod, TestCategory("DroneBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_one_DroneBees_Invalid()
        {
            //  Arrange
            var sut = new BeeGame(1, 2, 1);

            //  Act
            var result = sut.SpawnHive();

            var drones = result.Hive
                .Where(b => b.GetType().Equals(typeof(Drone)))
                .Select(b => b);

            //  Assert
            Assert.IsTrue(drones.Count() != 5);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException)), TestCategory("DroneBees"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_no_parameters_Should_return_DroneBee_null()
        {
            //  Arrange
            var sut = new BeeGame(1, 1, 0);

            //  Act
            try
            {
                var result = sut.SpawnHive();
            }
            catch (Exception e)
            {
                //  Assert
                Assert.AreEqual("Drone Bees Quantity Can't be 0", e.Message);
                throw;
            }
        }
    }
}