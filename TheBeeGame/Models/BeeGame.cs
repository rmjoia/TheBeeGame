using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsPlaying { get; private set; }

        public int QueensLifeSpan { get; private set; }
        public int WorkersLifeSpan { get; private set; }
        public int DronesLifeSpan { get; private set; }

        public string GetTitle()
        {
            return _gameTitle;
        }

        public BeeGame Start(GameSettings settings)
        {
            if (settings.GetQueensConfig().Elements == settings.GetQueensConfig().Min) throw new ArgumentException("Queen Bees Quantity Can't be 0");
            if (settings.GetWorkersConfig().Elements == settings.GetWorkersConfig().Min) throw new ArgumentException("Worker Bees Quantity Can't be 0");
            if (settings.GetDronesConfig().Elements == settings.GetDronesConfig().Min) throw new ArgumentException("Drone Bees Quantity Can't be 0");

            Hive = _hive.PopulateHive(settings);
            UpdateGameStatus(Hive);
            IsPlaying = true;

            return this;
        }

        public DamageControl HitBee(IList<IBee> hive)
        {
            var bee = _hive.GetRandomBee(hive.Where(b => b.LifeSpan > 0).ToList());

            bee.Hit();

            bee.CheckStatus(bee, hive);

            UpdateGameStatus(Hive);

            return new DamageControl
            {
                Bee = bee,
                BeePosition = hive.IndexOf(bee)
            };
        }

        private void UpdateGameStatus(IList<IBee> hive)
        {
            if (hive.Sum(b => b.LifeSpan) == 0)
            {
                IsPlaying = false;
            }

            QueensLifeSpan = GetLifeSpan(typeof(Queen), hive);
            WorkersLifeSpan = GetLifeSpan(typeof(Worker), hive);
            DronesLifeSpan = GetLifeSpan(typeof(Drone), hive);

        }

        public int GetLifeSpan(Type type, IList<IBee> hive)
        {
            return hive.Where(b => b.GetType().Equals(type)).Select(b => b.LifeSpan).Sum();
        }
    }
}