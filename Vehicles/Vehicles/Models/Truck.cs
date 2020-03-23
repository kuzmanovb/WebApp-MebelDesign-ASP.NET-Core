using Vehicles.Interface;

namespace Vehicles.Models
{
    public class Truck : IVehicles
    {
        private double ADD_FUEL_FOR_AIR = 1.6;
        private double CAPACITY_FUEL_AFTER_LOST = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
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
                return "Truck needs refueling";
            }
            else
            {
                this.FuelQuantity -= needFuel;
                return $"Truck travelled {distance} km";
            }
        }

        public void Refuel(double liters)
        {
            this.FuelQuantity += liters * CAPACITY_FUEL_AFTER_LOST;
        }
    }
}
