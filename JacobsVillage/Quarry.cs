﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobsVillage
{
    public class Quarry : IBuilding
    {
        private readonly string name;
        private readonly int woodCost;
        private readonly int metalCost;
        private int daysWorkedOn;
        private int daysToComplete;
        private bool complete;

        public Quarry(string name)
        {
            this.name = name;
            this.woodCost = 3;
            this.metalCost = 5;
            this.daysWorkedOn = 0;
            this.daysToComplete = 7;
            this.complete = false;
        }

        public bool enoughResources(int wood, int metal)
        {
            if (wood >= woodCost && metal >= metalCost)
            {
                return true;
            }
            return false;
        }

        public int getDaysToComplete()
        {
            return daysToComplete;
        }

        public int getDaysWorkedOn()
        {
            return daysWorkedOn;
        }

        public int getMetalCost()
        {
            return metalCost;
        }

        public string getName()
        {
            return name;
        }

        public int getWoodCost()
        {
            return woodCost;
        }

        public bool isComplete()
        {
            return complete;
        }

        public void removeOneDayToComplete()
        {
            daysToComplete--;
        }

        public void setComplete(int daysGone)
        {
        }

        public void setDaysWorkedOn(int daysWorkedOn)
        {
            this.daysToComplete = daysWorkedOn;
        }
    }
}
