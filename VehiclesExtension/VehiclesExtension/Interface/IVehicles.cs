namespace VehiclesExtension.Interface
{
    public interface IVehicles
    {
        public double FuelQuantity { get;}
        public double FuelConsumption { get;}
        public double TankCapacity { get;}

        public string Drive(double distance);
        public void Refuel(double liters);
    }
}
