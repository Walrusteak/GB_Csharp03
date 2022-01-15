using System.Collections;

namespace Task01
{
    public static class BuildingFactory
    {
        private static readonly Hashtable _buildings;

        static BuildingFactory() => _buildings = new Hashtable();

        public static Building CreateBuilding() => CreateBuilding(5, 1, 3, 1);

        public static Building CreateBuilding(float height, int floorCount, int flatCount, int entranceCount)
        {
            Building building = new()
            {
                Height = height,
                FloorCount = floorCount,
                FlatCount = flatCount,
                EntranceCount = entranceCount
            };
            _buildings.Add(building.Number, building);
            return building;
        }

        public static Building GetBuilding(int number) => _buildings.ContainsKey(number) ? (Building)_buildings[number] : null;

        public static bool RemoveBuilding(int number)
        {
            if (_buildings.ContainsKey(number))
            {
                _buildings.Remove(number);
                return true;
            }
            return false;
        }
    }
}
