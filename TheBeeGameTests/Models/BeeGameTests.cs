using TheBeeGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TheBeeGame.Interfaces;
using System.Collections.Generic;

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
            var queensRule = new GameRule(0, 1, 100, 8);
            var workersRule = new GameRule(0, 5, 75, 10);
            var dronesRule = new GameRule(0, 8, 50, 12);
            settings = new GameSettings(queensRule, workersRule, dronesRule);
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
            var rule = new GameRule(0, 1, 0, 0);

            //  Act
            var result = sut.Start(new GameSettings(rule, rule, rule));

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
            var rule = new GameRule(0, 1, 0, 0);

            //  Act
            var result = sut.Start(new GameSettings(new GameRule(0, 2, 0, 0), rule, rule));

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
            var rule = new GameRule(0, 0, 0, 0);

            //  Act
            try
            {
                var result = sut.Start(new GameSettings(rule, rule, rule));
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
            var rule = new GameRule(0, 1, 0, 0);

            //  Act
            var result = sut.Start(new GameSettings(rule, new GameRule(0, 5, 0, 0), rule));

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
            var rule = new GameRule(0, 1, 0, 0);
            //  Act
            var result = sut.Start(new GameSettings(rule, rule, rule));

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
            var rule = new GameRule(0, 0, 0, 0);
            //  Act
            try
            {
                var result = sut.Start(new GameSettings(new GameRule(0, 1, 0, 0), rule, rule));
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
            var rule = new GameRule(0, 1, 0, 0);

            //  Act
            var result = sut.Start(new GameSettings(rule, rule, new GameRule(0, 8, 0, 0)));

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
            var rule = new GameRule(0, 1, 0, 0);

            //  Act
            var result = sut.Start(new GameSettings(rule, new GameRule(0, 2, 0, 0), rule));

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
            var rule = new GameRule(0, 1, 0, 0);

            //  Act
            try
            {
                var result = sut.Start(new GameSettings(rule, rule, new GameRule(0, 0, 0, 0)));
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

#if DEBUG

        [TestMethod, TestCategory("BeeGame"), TestCategory("Randomness - NEVER INTO PRODUCTION - WILL FAIL OFTEN"), Owner("Ricardo Melo Joia")]
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
            Console.WriteLine(string.Join(",", temp.ToList()));
            Assert.IsFalse(
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[1])) &&
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[2])) &&
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[3])) &&
                (sut.Hive.IndexOf(temp[0]) == sut.Hive.IndexOf(temp[4])));
        }

#endif

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

        [TestMethod, TestCategory("BeeGame"), Owner("Ricardo Melo Joia")]
        public void Called_HitBee_onHit_untill_zero_should_NOT_remove_from_hive()
        {
            //  Arrange
            var sut = new BeeGame().Start(settings);

            //  Act
            int hivePopulation = sut.Hive.Count();
            var bee = sut.Hive.FirstOrDefault(b => b.GetType().Equals(typeof(Queen)));
            do
            {
                bee.Hit();

            } while (bee.LifeSpan > 0);

            sut.Hive = bee.CheckStatus(bee, sut.Hive);

            //  Assert
            Console.WriteLine(bee.GetType().Name);
            Assert.AreNotEqual(hivePopulation, sut.Hive.Count());
        }

        [TestMethod, TestCategory("BeeGame"), Owner("Ricardo Melo Joia")]
        public void Called_HitBee_onHit_untill_zero_should_remove_from_hive()
        {
            //  Arrange
            var sut = new BeeGame().Start(settings);

            //  Act
            int hivePopulation = sut.Hive.Count();
            var bee = sut.Hive.FirstOrDefault(b => !b.GetType().Equals(typeof(Queen)));
            do
            {
                bee.Hit();

            } while (bee.LifeSpan > 0);

            sut.Hive = bee.CheckStatus(bee, sut.Hive);

            //  Assert
            Console.WriteLine(bee.GetType().Name);
            Assert.AreEqual((hivePopulation - 1), sut.Hive.Count());
        }

        [TestMethod, TestCategory("BeeGame"), Owner("Ricardo Melo Joia")]
        public void Called_HitBee_onHit_Queen_untill_zero_should_Game_Over()
        {
            //  Arrange
            var sut = new BeeGame().Start(settings);

            //  Act
            var bee = sut.Hive.FirstOrDefault(b => b.GetType().Equals(typeof(Queen)));
            do
            {
                bee.Hit();

            } while (bee.LifeSpan > 0);

            sut.Hive = bee.CheckStatus(bee, sut.Hive);

            //  Assert
            Console.WriteLine(bee.GetType().Name);
            Assert.AreEqual(0, sut.Hive.Count());
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("QueenBees") Owner("Ricardo Melo Joia")]
        public void GetLifeSpan_Queen_Should_Return_Valid()
        {
            //  Arrange
            var sut = new BeeGame();
            var hive = new List<IBee>
            {
                new Queen(new Bee(10,0))
            };

            //  Act
            var result = sut.GetLifeSpan(typeof(Queen), hive);

            //  Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("QueenBees"), Owner("Ricardo Melo Joia")]
        public void GetLifeSpan_Queen_Should_Return_Invalid()
        {
            //  Arrange
            var sut = new BeeGame();
            var hive = new List<IBee>
            {
                new Worker(new Bee(10,0))
            };

            //  Act
            var result = sut.GetLifeSpan(typeof(Queen), hive);

            //  Assert
            Assert.AreNotEqual(10, result);
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("WorkerBees"), Owner("Ricardo Melo Joia")]
        public void GetLifeSpan_Worker_Should_Return_Valid()
        {
            //  Arrange
            var sut = new BeeGame();
            var hive = new List<IBee>
            {
                new Worker(new Bee(10,0))
            };

            //  Act
            var result = sut.GetLifeSpan(typeof(Worker), hive);

            //  Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("WorkerBees"), Owner("Ricardo Melo Joia")]
        public void GetLifeSpan_Worker_Should_Return_Invalid()
        {
            //  Arrange
            var sut = new BeeGame();
            var hive = new List<IBee>
            {
                new Queen(new Bee(10,0))
            };

            //  Act
            var result = sut.GetLifeSpan(typeof(Worker), hive);

            //  Assert
            Assert.AreNotEqual(10, result);
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("DroneBees"), Owner("Ricardo Melo Joia")]
        public void GetLifeSpan_Drone_Should_Return_Valid()
        {
            //  Arrange
            var sut = new BeeGame();
            var hive = new List<IBee>
            {
                new Drone(new Bee(10,0))
            };

            //  Act
            var result = sut.GetLifeSpan(typeof(Drone), hive);

            //  Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod, TestCategory("BeeGame"), TestCategory("DroneBees"), Owner("Ricardo Melo Joia")]
        public void GetLifeSpan_Drone_Should_Return_Invalid()
        {
            //  Arrange
            var sut = new BeeGame();
            var hive = new List<IBee>
            {
                new Queen(new Bee(10,0))
            };

            //  Act
            var result = sut.GetLifeSpan(typeof(Drone), hive);

            //  Assert
            Assert.AreNotEqual(10, result);
        }
    }
}