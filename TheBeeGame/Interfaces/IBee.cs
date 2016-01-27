using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBeeGame.Interfaces
{
    public interface IBee
    {
        int LifeSpan { get; }
        int DamageOnHit { get; }
    }
}
