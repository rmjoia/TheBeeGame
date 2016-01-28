using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class DamageControl
    {
        public int BeePosition { get; set; }
        public IBee Bee { get; set; }
    }
}