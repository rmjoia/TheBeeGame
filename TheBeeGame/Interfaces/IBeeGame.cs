using System.Collections.Generic;
using TheBeeGame.Models;

namespace TheBeeGame.Interfaces
{
    interface IBeeGame
    {
        IList<IBee> Hive { get; set; }
        bool IsPlaying { get; }
        int QueensLifeSpan { get;}
        int WorkersLifeSpan { get; }
        int DronesLifeSpan { get; }
        string GetTitle();
        BeeGame Start(GameSettings settings);
    }
}
