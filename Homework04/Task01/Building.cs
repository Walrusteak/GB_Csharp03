namespace Task01
{
    public sealed class Building
    {
        private static int _counter = 0;
        private readonly int _number;
        private float _height;
        private int _floorCount;
        private int _flatCount;
        private int _entranceCount;

        internal Building() => _number = _counter++;

        public int Number => _number;

        public float Height
        {
            get => _height;
            set => _height = value;
        }

        public int FloorCount
        {
            get => _floorCount;
            set => _floorCount = value;
        }

        public int FlatCount
        {
            get => _flatCount;
            set => _flatCount = value;
        }

        public int EntranceCount
        {
            get => _entranceCount;
            set => _entranceCount = value;
        }

        public float CalcFloorHeight() => _height / _floorCount;

        public int CalcFlatsInEntrance() => _flatCount / _entranceCount;

        public int CalcFlatsOnFloor() => _flatCount / _floorCount;

        public override string ToString()
        {
            return $@"Building #{_number}
Height: {_height}
Floors: {_floorCount}
Flats: {_flatCount}
Entrances: {_entranceCount}";
        }
    }
}
