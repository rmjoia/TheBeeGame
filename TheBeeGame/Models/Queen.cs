using System.Collections.Generic;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Queen : Bee
    {
        public Queen(IBee bee) : base(bee)
        {

        }

        public override IList<IBee> CheckStatus(IBee bee, IList<IBee> hive)
        {
            if (bee.LifeSpan == 0)
            {
                hive = new List<IBee>();
            }

            return hive;
        }
    }
}