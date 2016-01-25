using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBeeGame.Models;
using System.Collections;

namespace TheBeeGame.Interfaces
{
    interface IBeeGame
    {
        IList<IBee> QueenBees { get; set; }
        IList<IBee> WorkerBees { get; set; }
        IList<IBee> DroneBees { get; set; }

        string GetTitle();
        BeeGame SpawnHive();
    }
}
