using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public Bee(IBee bee) : base()
        {
            LifeSpan = bee.LifeSpan;
            DamageOnHit = bee.DamageOnHit;
        }

        public Bee(GameRule rule) : base()
        {
            LifeSpan = rule.LifeSpan;
            DamageOnHit = rule.Damage;
        }

        public int LifeSpan { get; private set; }
        public int DamageOnHit { get; private set; }

        public virtual int Hit()
        {
            var damageResult = LifeSpan - DamageOnHit;

            if (damageResult <= 0)
            {
                LifeSpan = 0;
                return 0;
            }
            else
            {
                LifeSpan -= DamageOnHit;
                return damageResult;
            }
        }

    }
}