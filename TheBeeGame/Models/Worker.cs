﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBeeGame.Interfaces;

namespace TheBeeGame.Models
{
    public class Worker : Bee
    {
        public Worker(IBee bee) :base(bee)
        {

        }
    }
}