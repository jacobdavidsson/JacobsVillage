using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobsVillage
{
    public class Village
    {
        private int food = 10;
        private int wood = 0;
        private int metal = 0;
        private int metalPerDay = 0;
        private int woodPerDay = 0;
        private int foodPerDay = 0;
        private int daysGone = 0;
        private List<Worker> workers;
        private List<IBuilding> buildings;
        private List<IBuilding> projects;

        public Village()
        {
            this.food = 10;
            this.wood = 0;
            this.metal = 0;
            this.metalPerDay = 0;
            this.woodPerDay = 0;
            this.foodPerDay = 0;
            this.daysGone = 0;
            this.workers = new List<Worker>();
            this.buildings = new List<IBuilding>();
            this.projects = new List<IBuilding>();

            House house1 = new House("House");
            House house2 = new House("House");
            House house3 = new House("House");

            buildings.Add(house1);
            buildings.Add(house2);
            buildings.Add(house3);
        }

        public int getFood() { return food; }
        public void setFood(int food) { this.food = food; }
        public int getWood() { return wood; }
        public void setWood(int wood) { this.wood = wood; }
        public int getMetal() { return metal; }
        public void setMetal(int metal) { this.metal = metal; }
        public int getMetalPerDay() { return metalPerDay; }
        public void setMetalPerDay(int metalPerDay) { this.metalPerDay = metalPerDay; }
        public int getWoodPerDay() { return woodPerDay; }
        public void setWoodPerDay(int woodPerDay) { this.woodPerDay = woodPerDay; }
        public int getFoodPerDay() { return foodPerDay; }
        public void setFoodPerDay(int foodPerDay) { this.foodPerDay = foodPerDay; }
        public int getDaysGone() { return daysGone; }
        public void setDaysGone(int daysGone) { this.daysGone = daysGone; }
        public List<Worker> getWorkers() { return workers; }
        public void setWorkers(List<Worker> workers) { this.workers = workers; }
        public List<IBuilding> getBuildings() { return buildings; }
        public void setBuildings(List<IBuilding> buildings) { this.buildings = buildings; }
        public List<IBuilding> getProjects() { return projects; }
        public void setProjects(List<IBuilding> projects) { this.projects = projects; }


        public delegate void WorkerDelegate();

        public void AddWorker(string name, string occupation, Village.WorkerDelegate workerDelegate)
        {
            if (workers.Count() < (buildings.Count() * 2))
            {
                workers.Add(new Worker(name, occupation, workerDelegate));
            }
        }

        public WorkerDelegate addRandomWorker(Random random)
        {
            int randomNumber = random.Next(4);
            switch (randomNumber)
            {
                case 0:
                    return () => AddWood();
                case 1:
                    return () => AddFood();
                case 2:
                    return () => AddMetal();
                case 3:
                    return () => Build();
            }
            return null;
        }

        public void AddProject(IBuilding building)
        {
            if (building.enoughResources(wood, metal))
            { 
                projects.Add(building);
                wood = wood - building.getWoodCost();
                metal = metal - building.getMetalCost();
            }
        }

        public void Day() 
        {
            daysGone++;
            foreach (Worker worker in workers) 
            {
                FeedWorkers(worker);
                worker.DoWork();
            }
            BuryDead();
        }

        public void FeedWorkers(Worker worker)
        {
            if (food > 0)
            {
                worker.Feed();
                food--;
            }
            else 
            {
                worker.AddHungryDay();
            }
        }

        public void AddFood() 
        {
            food += 5;
            foreach (IBuilding building in buildings)
            {
                if (building is Farm)
                {
                    food += 10;
                }
            }
        }

        public void AddMetal() 
        {
            metal += 1;
            foreach (IBuilding building in buildings)
            {
                if (building is Quarry)
                {
                    metal += 2;
                }
            }
        }

        public void AddWood() 
        {
            wood += 1;
            foreach (IBuilding building in buildings)
            {
                if (building is Woodmill)
                {
                    wood += 2;
                }
            }
        }

        public void Build()
        {
            if (projects.Count > 0)
            {
                IBuilding building = projects[0];

                if (building.getDaysToComplete() > 0)
                {
                    building.removeOneDayToComplete();
                }
                else
                {
                    buildings.Add(building);
                    projects.Remove(building);
                    building.setComplete(daysGone);
                }
            }
        }

        public void BuryDead()
        {
            for (int i = workers.Count - 1; i >= 0; i--)
            {
                Worker worker = workers[i];
                if (!worker.getAlive())
                {
                    workers.RemoveAt(i);
                }
            }
            if (workers.Count == 0)
            {
                Console.WriteLine("Game Over");
            }
        }

                public Boolean CastleisBuilt()
        {
            foreach (IBuilding building in buildings)
            {
                if (building is Castle)
                    {  return true; }
            }
            return false;
        }
    }
}
