using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Enums;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Bee : IBee
    {
        public Bee(int lifeSpan, int damageOnHit)
        {
            LifeSpan = lifeSpan;
            DamageOnHit = damageOnHit;
        }

        public int LifeSpan { get; private set; }
        public int DamageOnHit { get; private set; }
    }
}