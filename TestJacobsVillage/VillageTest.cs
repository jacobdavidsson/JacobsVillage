using JacobsVillage;

namespace TestJacobsVillage
{
    [TestClass]
    public class VillageTest
    {
        [TestMethod]
        public void TestAddWorkers()
        {
            // Arrange
            Village village = new Village();

            // Act
            village.AddWorker("Bob", "Cook", village.AddFood);

            // Assert
            Assert.AreEqual(1, village.getWorkers().Count);

            // Act
            village.AddWorker("Anna", "Woodcutter", village.AddWood);

            // Assert
            Assert.AreEqual(2, village.getWorkers().Count);

            // Act
            village.AddWorker("Andy", "Metalworker", village.AddMetal);

            // Assert
            Assert.AreEqual(3, village.getWorkers().Count);
        }

        [TestMethod]
        public void TestAddWorkersNotEnoughHouses()
        {
            //Arrange
            Village village = new Village();
            village.getBuildings().Clear();

            //Act
            village.AddWorker("Bob", "Cook", village.AddFood);

            //Assert
            Assert.AreEqual(0, village.getWorkers().Count);
        }

        [TestMethod]
        public void TestAddWorkerDayFunction()
        {
            // Arrange
            Village village = new Village();
            village.AddWorker("Andy", "Metalworker", village.AddMetal);

            // Act
            village.Day();

            // Assert
            Assert.AreEqual(1, village.getDaysGone());
            Assert.AreEqual(9, village.getFood());
            Assert.AreEqual(0, village.getWood());
            Assert.AreEqual(1, village.getMetal());
        }

        [TestMethod]
        public void TestDayWithoutWorkers()
        {
            //Arrange
            Village village = new Village();

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(1, village.getDaysGone());
            Assert.AreEqual(10, village.getFood());
        }

        [TestMethod]
        public void TestDayWithWorkers()
        {
            //Arrange
            Village village = new Village();
            village.AddWorker("Bob", "Cook", village.AddFood);
            village.AddWorker("Anna", "Woodcutter", village.AddWood);
            village.AddWorker("Andy", "Metalworker", village.AddMetal);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(1, village.getDaysGone());
            Assert.AreEqual(12, village.getFood());
            Assert.AreEqual(1, village.getWood());
            Assert.AreEqual(1, village.getMetal());
        }

        [TestMethod]
        public void TestDayWithWorkersNoFood()
        {
            //Arrange
            Village village = new Village();
            village.AddWorker("Bob", "Builder", village.AddFood);
            village.AddWorker("Anna", "Woodcutter", village.AddMetal);
            village.AddWorker("Andy", "Metalworker", village.AddWood);
            village.setFood(0);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(1, village.getDaysGone());
            Assert.AreEqual(0, village.getFood());
            Assert.AreEqual(0, village.getWood());
            Assert.IsTrue(village.getWorkers().All(worker => worker.getDaysHungry() == 1));
        }

        [TestMethod]
        public void TestAddProject()
        {
            //Arrange
            Village village = new Village();
            village.setWood(3);
            village.setMetal(5);

            //Act
            IBuilding building = new Quarry("Quarry");
            village.AddProject(building);

            //Assert
            Assert.AreEqual(0, village.getWood());
            Assert.AreEqual(0, village.getMetal());
            Assert.AreEqual(1, village.getProjects().Count());
        }

        [TestMethod]
        public void TestAddProjectNoResources()
        {
            //Arrange
            Village village = new Village();
            village.setWood(0);
            village.setMetal(0);

            //Act
            IBuilding building = new Quarry("Quarry");
            village.AddProject(building);

            //Assert
            Assert.AreEqual(0, village.getProjects().Count());
        }

        [TestMethod]
        public void TestWoodIncome()
        {
            //Arrange
            Village village = new Village();
            village.AddWorker("Anna", "Woodcutter", village.AddWood);
            village.AddWorker("Bob", "Builder", village.Build);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(1, village.getWood());

            //Act
            IBuilding building = new Woodmill("Woodmill");
            village.getBuildings().Add(building);
            village.Day();

            //Assert
            Assert.AreEqual(4, village.getWood());
        }

        [TestMethod]
        public void TestMetalIncome()
        {
            //Arrange
            Village village = new Village();
            village.AddWorker("Andy", "Metalworker", village.AddMetal);
            village.AddWorker("Bob", "Builder", village.Build);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(1, village.getMetal());

            //Act
            IBuilding building = new Quarry("Quarry");
            village.getBuildings().Add(building);
            village.Day();

            //Assert
            Assert.AreEqual(4, village.getMetal());
        }

        [TestMethod]
        public void TestFoodIncome()
        {
            //Arrange
            Village village = new Village();
            village.AddWorker("Bobby", "Cook", village.AddFood);
            village.AddWorker("Bob", "Builder", village.Build);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(13, village.getFood());

            //Act
            IBuilding building = new Farm("Farm");
            village.getBuildings().Add(building);
            village.Day();

            //Assert
            Assert.AreEqual(26, village.getFood());
        }

        [TestMethod]
        public void TestDayCorrectNumOfTimes()
        {
            //Arrange
            Village village = new Village();
            IBuilding building = new House("House");
            village.getProjects().Add(building);
            village.AddWorker("Bob", "Builder", village.Build);
            village.AddWorker("Bobby", "Builder", village.Build);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(3, village.getBuildings().Count());

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(4, village.getBuildings().Count());
        }

        [TestMethod]
        public void TestWorkIfHungry()
        {
            //Arrange
            Village village = new Village();
            village.setFood(0);
            village.AddWorker("Andy", "Metalworker", village.AddMetal);

            //Act
            village.Day();

            //Assert
            Assert.AreEqual(0, village.getMetal());
        }

        [TestMethod]
        public void TestIfAliveIsFalseAfter40Days()
        {
            // Arrange
            Village village = new Village();
            village.setFood(0);
            village.AddWorker("Andy", "Metalworker", village.AddMetal);
            Worker worker = village.getWorkers().Find(w => w.getName() == "Andy");

            // Act
            for (int i = 0; i < 40; i++)
            {
                village.Day();
            }

            // Assert
            Assert.IsFalse(worker.getAlive());

            // Act
            village.setFood(1);
            village.Day();

            // Assert
            Assert.AreEqual(1, village.getFood());
            Assert.AreEqual(0, village.getWorkers().Count());
        }

        [TestMethod]
        public void TestCastleBuild()
        {
            //Arrange
            Village village = new Village();
            IBuilding building1 = new Farm("Farm");
            IBuilding building2 = new Quarry("Quarry");
            IBuilding building3 = new Woodmill("Woodmill");
            village.getProjects().Add(building1);
            village.getProjects().Add(building2);
            village.getProjects().Add(building3);
            village.AddWorker("Bob", "Builder", village.Build);
            village.AddWorker("Bobby", "Builder", village.Build);
            village.AddWorker("Oliver", "Builder", village.Build);
            village.AddWorker("Anna", "Woodcutter", village.AddWood);
            village.AddWorker("Andy", "Metalbuilder", village.AddMetal);
            village.AddWorker("Candice", "Cook", village.AddFood);

            //Act
            for (int i = 0; i < 21; i++)
            {
                village.Day();
            }

            Console.WriteLine(village.getFood());
            Console.WriteLine(village.getMetal());
            Console.WriteLine(village.getWood());

            IBuilding building4 = new Castle("Castle");
            village.getProjects().Add(building4);

            for (int i = 0; i < 17; i++)
            {
                village.Day();
            }

            //Assert
            Assert.AreEqual(38, village.getDaysGone());
        }
    }
}