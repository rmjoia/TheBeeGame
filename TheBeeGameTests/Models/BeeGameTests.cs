using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBeeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models.Tests
{
    [TestClass()]
    public class BeeGameTests
    {
        private BeeGame sut;
        private GameSettings settings;

        [TestInitialize]
        public void SetupTests()
        {
            sut = new BeeGame();
            settings = new GameSettings(1, 5, 8);
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
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(new GameSettings(1, 1, 1));

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
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(new GameSettings(2, 1, 1));

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
            var sut = new BeeGame();

            //  Act
            try
            {
                var result = sut.Start(new GameSettings(0, 0, 0));
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
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(new GameSettings(1,5,1));

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
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(new GameSettings(1, 1, 1));

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
            var sut = new BeeGame();

            //  Act
            try
            {
                var result = sut.Start(new GameSettings(1, 0, 0));
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
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(new GameSettings(1, 1, 8));

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
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(new GameSettings(1, 2, 1));

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
            var sut = new BeeGame();

            //  Act
            try
            {
                var result = sut.Start(new GameSettings(1, 1, 0));
            }
            catch (Exception e)
            {
                //  Assert
                Assert.AreEqual("Drone Bees Quantity Can't be 0", e.Message);
                throw;
            }
        }

        [TestMethod, TestCategory("BeeGame"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_Should_return_bees_number_valid()
        {
            //  Arrange
            var sut = new BeeGame();

            //  Act
            var result = sut.Start(settings);

            var queens = result.Hive
                .Where(b => b.GetType().Equals(typeof(Queen)))
                .Select(b => b);

            var workers = result.Hive
                .Where(b => b.GetType().Equals(typeof(Worker)))
                .Select(b => b);

            var drones = result.Hive
                .Where(b => b.GetType().Equals(typeof(Drone)))
                .Select(b => b);

            //  Assert
            Assert.AreEqual(14, result.Hive.Count());
            Assert.AreEqual(1, queens.Count());
            Assert.AreEqual(5, workers.Count());
            Assert.AreEqual(8, drones.Count());
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("Randomness - Things may happen"), Owner("Ricardo Melo Joia")]
        public void Given_SpawnHive_valid_Should_Hit_random_bee()
        {
            //  Arrange
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var sut = new BeeGame().Start(settings);
            var temp = new IBee[5];
            var hive = new Hive();

            //  Act
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = hive.GetRandomBee(sut.Hive);
            }

            //  Assert
            Assert.IsFalse(
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[1])) &&
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[2])) &&
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[3])) &&
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[4])));

            Console.WriteLine(string.Join(",", temp.ToList()));
        }

        [TestMethod, TestCategory("BeeGame"), Owner("Ricardo Melo Joia")]
        public void Called_HitBee_Should_decrease_bee_lifespan()
        {
            //  Arrange
            var sut = new BeeGame().Start(settings);
            var startScore = sut.Hive.Select(b => b.LifeSpan).Sum();

            //  Act
            var teste = sut.HitBee(sut);
            var newScore = sut.Hive.Select(b => b.LifeSpan).Sum();

            //  Assert
            Assert.AreNotEqual(newScore, startScore);
        }
    }
}