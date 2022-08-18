namespace PowerLineTask
{
    public class Auto:Car
    {
        private int MaximumLoadCapacity { get; init; }
        private int LimitOfIncreasingFuelConsumption { get; init; }

        public Auto()
        {
            AverageFuelConsumption = 10.1;
            MaximumLoadCapacity = 4;
            MaxFuelCapacity = 50;
            MaxSpeed = 110;
            LimitOfIncreasingFuelConsumption = 1;
            PowerReserveReductionFactor = 6;
            Type = TransportType.PassengerCar;
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