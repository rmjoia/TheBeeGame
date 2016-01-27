using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Drone : Bee
    {
        public Drone(IBee bee):base(bee)
        {

        }
    }
}