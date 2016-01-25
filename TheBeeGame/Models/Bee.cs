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
        public Bee(BeeJobs job, int lifeSpan, int damageOnHit)
        {
            Job = job;
            LifeSpan = lifeSpan;
            DamageOnHit = damageOnHit;
        }

        public BeeJobs Job { get; private set; }
        public int LifeSpan { get; private set; }
        public int DamageOnHit { get; private set; }
    }
}