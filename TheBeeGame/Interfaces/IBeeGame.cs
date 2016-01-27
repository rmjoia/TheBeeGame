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
        IList<IBee> Hive { get; set; }
        string GetTitle();
        BeeGame Start(GameSettings settings);
    }
}
