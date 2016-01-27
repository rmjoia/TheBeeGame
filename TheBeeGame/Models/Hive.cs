using System;
using System.Collections.Generic;
using System.Linq;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Hive
    {
        public Hive()
        {

        }

        public IList<IBee> PopulateHive(GameSettings settings)
        {
            var hivePopulation = (settings.GetQueens() + settings.GetWorkers() + settings.GetDrones());
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var hive = new IBee[hivePopulation];

            //TODO: Use a availableSlot Array splicing used units

            GenerateBees(beeType: typeof(Queen), container: hive, bee: new Bee(100, 8), beesNumber: settings.GetQueens());
            GenerateBees(beeType: typeof(Worker), container: hive, bee: new Bee(75, 10), beesNumber: settings.GetWorkers());
            GenerateBees(beeType: typeof(Drone), container: hive, bee: new Bee(50, 12), beesNumber: settings.GetDrones());

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

        public IBee GetRandomBee(IList<IBee> hive)
        {
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            var randomBee = random.Next(0, hive.Count());

            return hive.ElementAt(randomBee);
        }
    }
}