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
            var hivePopulation = (settings.GetQueensConfig().Elements+ settings.GetWorkersConfig().Elements + settings.GetDronesConfig().Elements);
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var hive = new IBee[hivePopulation];

            //TODO: Use a availableSlot Array splicing used units

            GenerateBees(beeType: typeof(Queen), container: hive, rule: settings.GetQueensConfig());
            GenerateBees(beeType: typeof(Worker), container: hive, rule: settings.GetWorkersConfig());
            GenerateBees(beeType: typeof(Drone), container: hive, rule: settings.GetDronesConfig());

            return hive;
        }

        private void GenerateBees(Type beeType, IBee[] container, GameRule rule)
        {
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            do
            {
                var queenPosition = random.Next(0, container.Length);

                if (container[queenPosition] == null)
                {
                    container[queenPosition] = (IBee)Activator.CreateInstance(beeType, new Bee(rule));

                }

            } while (GetBeesNumber(container, beeType) < rule.Elements);
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