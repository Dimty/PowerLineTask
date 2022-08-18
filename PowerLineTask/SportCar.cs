namespace PowerLineTask
{
    public class SportCar:Car
    {
        private int MaximumLoadCapacity { get; init; }
        private int LimitOfIncreasingFuelConsumption { get; init; }
        public SportCar()
        {
            AverageFuelConsumption = 12.8;
            MaximumLoadCapacity = 1;
            MaxFuelCapacity = 80;
            MaxSpeed = 150;
            LimitOfIncreasingFuelConsumption = 1;
            PowerReserveReductionFactor = 0;
            Type = TransportType.SportsCar;
        }

        public override int GetPowerReserve(int currentCargoQuantity)
        {
            if (currentCargoQuantity > MaximumLoadCapacity)
            {
                throw new Exception("The actual number of passengers exceeds the permissible limit.");
            }

            if (LimitOfIncreasingFuelConsumption < 1) throw new Exception("Invalid limit value.");
            var quantityOfModularCargo = currentCargoQuantity / LimitOfIncreasingFuelConsumption; 
            return base.GetPowerReserve(quantityOfModularCargo);
        }
    }
}