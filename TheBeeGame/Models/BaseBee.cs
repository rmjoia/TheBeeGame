using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Enums;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public abstract class BaseBee
    {
        private IBee _bee;
        public BaseBee(IBee bee)
        {
            DamageOnHit = bee.DamageOnHit;
            Job = bee.Job;
            LifeSpan = bee.LifeSpan;
        }

        public int DamageOnHit { get; private set; }

        public BeeJobs Job { get; private set; }

        public int LifeSpan { get; set; }

        public virtual int Hit()
        {
            return 0;
        }
    }
}