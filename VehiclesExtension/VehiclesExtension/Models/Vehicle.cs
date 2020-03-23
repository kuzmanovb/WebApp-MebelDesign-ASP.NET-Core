using System;
using VehiclesExtension.Interface;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicles
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            if (fuelQuantity > TankCapacity)
            {
                this.FuelConsumption = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public abstract string Drive(double distance);

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }
    }
}
