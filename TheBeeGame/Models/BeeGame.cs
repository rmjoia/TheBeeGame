using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Enums;
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

        public int MyProperty { get; set; }

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

            for (int i = 0; i < game.QueenBeesQuantity; i++)
            {
                game.Hive.Add(new Queen(new Bee(100, 8)));
            }

            for (int i = 0; i < game.WorkerBeesQuantity; i++)
            {
                game.Hive.Add(new Worker(new Bee(75, 10)));
            }

            for (int i = 0; i < game.DroneBeesQuantity; i++)
            {
                game.Hive.Add(new Drone(new Bee(50, 12)));
            }

            return game;
        }

    }
}