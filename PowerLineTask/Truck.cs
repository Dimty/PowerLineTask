namespace PowerLineTask
{
    public class Truck:Car
    {
        private int MaximumLoadCapacity { get; init; }
        private int LimitOfIncreasingFuelConsumption { get; init; }

        public Truck()
        {
            AverageFuelConsumption = 23.8;
            MaximumLoadCapacity = 1000;
            MaxFuelCapacity = 170;
            MaxSpeed = 90;
            LimitOfIncreasingFuelConsumption = 200;
            PowerReserveReductionFactor = 4;
            Type = TransportType.Truck;
        }

        public override int GetPowerReserve(int currentCargoQuantity)
        {
            if (currentCargoQuantity > MaximumLoadCapacity)
            {
                throw new Exception("The actual quantity of the cargo exceeds the permissible limit.");
            }
            if (LimitOfIncreasingFuelConsumption < 1) throw new Exception("Invalid limit value.");
            var quantityOfModularCargo = currentCargoQuantity / LimitOfIncreasingFuelConsumption; 
            return base.GetPowerReserve(quantityOfModularCargo);
        }
    }
}