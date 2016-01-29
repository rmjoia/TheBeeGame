using System.Collections.Generic;
using System.Linq;
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
                foreach (var _bee in hive)
                {
                    do
                    {
                        _bee.Hit();

                    } while (_bee.LifeSpan > 0);
                }
            }

            return hive;
        }
    }
}