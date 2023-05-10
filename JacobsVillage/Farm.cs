using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobsVillage
{
    public class Farm : IBuilding
    {
        private readonly string name;
        private readonly int woodCost;
        private readonly int metalCost;
        private int daysWorkedOn;
        private int daysToComplete;
        private bool complete;

        public Farm(string name)
        {
            this.name = name;
            this.woodCost = 5;
            this.metalCost = 2;
            this.daysWorkedOn = 0;
            this.daysToComplete = 5;
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
