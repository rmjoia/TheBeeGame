using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class BeeGame : IBeeGame
    {
        private readonly string _gameTitle;
        private Hive _hive;

        public BeeGame()
        {
            _gameTitle = "The Bee Game";
            _hive = new Hive();
        }

        public IList<IBee> Hive { get; set; }

        public string GetTitle()
        {
            return _gameTitle;
        }

        public BeeGame Start(GameSettings settings)
        {
            if (settings.GetQueens() == 0) throw new ArgumentException("Queen Bees Quantity Can't be 0");
            if (settings.GetWorkers() == 0) throw new ArgumentException("Worker Bees Quantity Can't be 0");
            if (settings.GetDrones() == 0) throw new ArgumentException("Drone Bees Quantity Can't be 0");

            Hive = _hive.PopulateHive(settings);

            return this;
        }

        public BeeGame HitBee(BeeGame game)
        {
            var bee = _hive.GetRandomBee(game.Hive);

            bee.Hit();

            return game;
        }
    }
}