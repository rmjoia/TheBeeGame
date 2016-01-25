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

        public IList<IBee> DroneBees { get; set; }

        public IList<IBee> QueenBees { get; set; }

        public IList<IBee> WorkerBees { get; set; }

        public string GetTitle()
        {
            return GameTitle;
        }

        public BeeGame SpawnHive()
        {
            if (QueenBeesQuantity == 0) throw new ArgumentException("Queen Bees Quantity Can't be 0");

            IBee QueenBee = new Bee(BeeJobs.Queen, 100, 8);

            var game = new BeeGame(queens: QueenBeesQuantity, workers: WorkerBeesQuantity, drones: DroneBeesQuantity) {
                QueenBees = new List<IBee>(),
                WorkerBees = new List<IBee>(),
                DroneBees = new List<IBee>()
            };

            for (int i = 0; i < game.QueenBeesQuantity; i++)
            {
                game.QueenBees.Add(QueenBee);
            }

            return game;
        }

    }
}