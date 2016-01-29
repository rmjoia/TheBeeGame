using System.Collections.Generic;

namespace TheBeeGame.Interfaces
{
    public interface IBee
    {
        int LifeSpan { get; }
        int DamageOnHit { get; }
        int Hit();
        IList<IBee> CheckStatus(IBee bee, IList<IBee> hive);
    }
}
