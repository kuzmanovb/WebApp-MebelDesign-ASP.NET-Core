using System;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private double ADD_FUEL_FOR_AIR = 1.6;
        private double CAPACITY_FUEL_AFTER_LOST = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        public override string Drive(double distance)
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

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + (liters * CAPACITY_FUEL_AFTER_LOST) > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters * CAPACITY_FUEL_AFTER_LOST;
        }
    }
}
