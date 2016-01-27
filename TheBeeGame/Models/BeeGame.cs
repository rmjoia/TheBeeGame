using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class BeeGame : IBeeGame
    {
        private readonly string GameTitle ;

        int QueenBeesQuantity;
        int WorkerBeesQuantity;
        int DroneBeesQuantity;

        public BeeGame()
        {
            GameTitle = "The Bee Game";
        }

        public BeeGame(int queens, int workers, int drones) : this()
        {
            QueenBeesQuantity = queens;
            WorkerBeesQuantity = workers;
            DroneBeesQuantity = drones;
        }

        public IList<IBee> Hive { get; set; }

        public string GetTitle()
        {
            return GameTitle;
        }

        public BeeGame SpawnHive()
        {
            if (QueenBeesQuantity == 0) throw new ArgumentException("Queen Bees Quantity Can't be 0");
            if (WorkerBeesQuantity == 0) throw new ArgumentException("Worker Bees Quantity Can't be 0");
            if (DroneBeesQuantity == 0) throw new ArgumentException("Drone Bees Quantity Can't be 0");

            var game = new BeeGame(queens: QueenBeesQuantity, workers: WorkerBeesQuantity, drones: DroneBeesQuantity) {
                Hive = new List<IBee>()
            };

            game.Hive = PopulateHive(game);

            return game;
        }

        private IList<IBee> PopulateHive(BeeGame game)
        {
            var hivePopulation = (QueenBeesQuantity + WorkerBeesQuantity + DroneBeesQuantity);
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var hive = new IBee[hivePopulation];

            //TODO: Use a availableSlot Array splicing used units

            GenerateBees(beeType: typeof(Queen), container: hive, bee: new Bee(100, 8), beesNumber:QueenBeesQuantity);
            GenerateBees(beeType: typeof(Worker), container: hive, bee: new Bee(75, 10), beesNumber: WorkerBeesQuantity);
            GenerateBees(beeType: typeof(Drone), container: hive, bee: new Bee(50, 12), beesNumber: DroneBeesQuantity);

            return hive;
        }

        private void GenerateBees(Type beeType, IBee[] container, IBee bee, int beesNumber)
        {
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            do
            {
                var queenPosition = random.Next(0, container.Length);

                if (container[queenPosition] == null)
                {
                    container[queenPosition] = (IBee)Activator.CreateInstance(beeType, bee);

                }

            } while (GetBeesNumber(container, beeType) < beesNumber);
        }

        private int GetBeesNumber(IBee[] hive, Type beeType)
        {
            return hive.Where(b => b != null && b.GetType().Equals(beeType)).Select(b => b).Count();
        }

    }
}