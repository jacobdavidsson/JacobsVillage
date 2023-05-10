using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobsVillage
{
    public interface IBuilding
    {
        string getName();
        int getWoodCost();
        int getMetalCost();
        int getDaysWorkedOn();
        void setDaysWorkedOn(int daysWorkedOn);
        int getDaysToComplete();
        void removeOneDayToComplete();
        bool isComplete();
        void setComplete(int daysGone);
        bool enoughResources(int wood, int metal);
    }
}
