using Vehicles.Interface;

namespace Vehicles.Models
{
    public class Car : IVehicles
    {
        private double ADD_FUEL_FOR_AIR = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public string Drive(double distance)
        {
            var needFuel = distance * (this.FuelConsumption + ADD_FUEL_FOR_AIR);
            if (needFuel > this.FuelQuantity)
            {
                return "Car needs refueling";
            }
            else
            {
                this.FuelQuantity -= needFuel;
                return $"Car travelled {distance} km";
            }
        }

        public void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
