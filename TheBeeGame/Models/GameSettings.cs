using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBeeGame.Models
{
    public class GameSettings
    {
        GameRule QueenBees;
        GameRule WorkerBees;
        GameRule DroneBees;

        public GameSettings(GameRule queenBees, GameRule workerBees, GameRule droneBees)
        {
            QueenBees = queenBees;
            WorkerBees = workerBees;
            DroneBees = droneBees;
        }

        public GameRule GetQueensConfig()
        {
            return QueenBees;
        }

        public GameRule GetWorkersConfig()
        {
            return WorkerBees;
        }

        public GameRule GetDronesConfig()
        {
            return DroneBees;
        }
    }
}