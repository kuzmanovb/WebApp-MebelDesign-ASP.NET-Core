
namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private double ADD_FUEL_FOR_AIR = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        public override string Drive(double distance)
        {
            double needFuel = distance * this.FuelConsumption + ADD_FUEL_FOR_AIR;
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

    }
}
