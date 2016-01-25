using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Queen : BaseBee
    {

        public Queen(IBee bee) : base(bee)
        {

        }
    }
}