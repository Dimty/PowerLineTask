namespace PowerLineTask
{
    public abstract class Car
    {
        protected TransportType Type { get; init; }
        
        protected int MaxSpeed { get; init; }

        protected int CurrentSpeed { get; set; }
        protected int MaxFuelCapacity { get; init; }
        protected double AverageFuelConsumption { get; init; }
        
        public int GetMaxDistanceWithFullFuel()
        {
            return (int) (MaxFuelCapacity / (AverageFuelConsumption / 100));
        }

        protected int CurrentFuelCapacity { get; set; }
        public int GetMaxDistanceWithResidualFuel()
        {
            return (int) (CurrentFuelCapacity / (AverageFuelConsumption / 100));
        }

        protected int PowerReserveReductionFactor { get; init; }
        
        public virtual int GetPowerReserve(int currentCargoQuantity)
        {
            var totalCoefficient = currentCargoQuantity * PowerReserveReductionFactor;

            var distance = GetMaxDistanceWithResidualFuel();
            return (int)(distance - (distance * ((double)totalCoefficient / 100)));
        }

        public void AddFuel(int count)
        {
            if (CurrentFuelCapacity + count > MaxFuelCapacity) CurrentFuelCapacity = MaxFuelCapacity;
            else CurrentFuelCapacity += count;
        }
    }


    public enum TransportType
    {
        PassengerCar = 0,
        Truck,
        SportsCar
    }
}