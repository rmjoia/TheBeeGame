using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBeeGame.Models
{
    public class GameRule
    {
        public readonly int Min;
        public readonly int Elements;
        public readonly int LifeSpan;
        public readonly int Damage;

        public GameRule(int min, int elements, int lifeSpan, int damage)
        {
            Min = min;
            Elements = elements;
            LifeSpan = lifeSpan;
            Damage = damage;
        }

    }
}