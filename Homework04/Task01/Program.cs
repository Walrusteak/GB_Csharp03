using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildingFactory.CreateBuilding();
            BuildingFactory.CreateBuilding(10, 3, 9, 1);

            Building building;
            building = BuildingFactory.GetBuilding(0);
            Console.WriteLine(building);
            Console.WriteLine();
            building = BuildingFactory.GetBuilding(1);
            Console.WriteLine(building);
            Console.WriteLine();
            BuildingFactory.RemoveBuilding(1);
            building = BuildingFactory.GetBuilding(1);
            Console.WriteLine(building);
        }
    }
}
