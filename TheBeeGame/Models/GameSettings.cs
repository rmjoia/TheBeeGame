using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBeeGame.Models
{
    public class GameSettings
    {
        int QueenBeesQuantity;
        int WorkerBeesQuantity;
        int DroneBeesQuantity;

        public GameSettings(int queens, int workers, int drones)
        {
            QueenBeesQuantity = queens;
            WorkerBeesQuantity = workers;
            DroneBeesQuantity = drones;
        }

        public int GetQueens()
        {
            return QueenBeesQuantity;
        }

        public int GetWorkers()
        {
            return WorkerBeesQuantity;
        }

        public int GetDrones()
        {
            return DroneBeesQuantity;
        }
    }
}