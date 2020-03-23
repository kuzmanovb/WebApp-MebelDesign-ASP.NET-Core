
namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private double ADD_FUEL_FOR_AIR = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
             : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        
        public override string Drive(double distance)
        {
            var needFuel = distance * (this.FuelConsumption + ADD_FUEL_FOR_AIR);
            if (needFuel > this.FuelQuantity)
            {
                return "Bus needs refueling";
            }
            else
            {
                this.FuelQuantity -= needFuel;
                return $"Bus travelled {distance} km";
            }
        }
        public string DriveEmpty (double distance)
        {
            double needFuel = distance * this.FuelConsumption;
            if (needFuel > this.FuelQuantity)
            {
                return "Bus needs refueling";
            }
            else
            {
                this.FuelQuantity -= needFuel;
                return $"Bus travelled {distance} km";
            }
        }

    }
}
