using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JacobsVillage.Village;

namespace JacobsVillage
{
    public class Worker
    {
        private string name;
        private string occupation;
        private bool hungry;
        private int daysHungry;
        private bool alive;
        private Village.WorkerDelegate workerDelegate;

        public Worker(string name, string occupation, Village.WorkerDelegate workerDelegate)
        {
            this.name = name;
            this.occupation = occupation;
            this.hungry = false;
            this.daysHungry = 0;
            this.alive = true;
            this.workerDelegate = workerDelegate;
        }

        public string getName() { return name; }
        public void setName(string name) { this.name = name; }
        public string getOccupation() { return occupation; }
        public void setOccupation(string occupation) { this.occupation = occupation; }
        public bool getHungry() { return hungry; }
        public void setHungry(bool hungry) { this.hungry = hungry; }
        public int getDaysHungry() { return daysHungry; }
        public void setDaysHungry(int daysHungry) { this.daysHungry = daysHungry; }
        public bool getAlive() {  return alive; }
        public void setAlive(bool alive) {  this.alive = alive; }


        public void DoWork() 
        {
            if (!hungry)
            {
                workerDelegate();
            }
        }

        public void Feed() 
        {
            hungry = false;
            daysHungry = 0;
        }

        public void AddHungryDay()
        {
            daysHungry++;
            hungry = true;
            if (daysHungry >= 40)
            {
                alive = false;
            }
        }
    }
}
