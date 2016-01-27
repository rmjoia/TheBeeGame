using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Queen : Bee
    {

        public Queen(IBee bee) : base(bee)
        {

        }
    }
}