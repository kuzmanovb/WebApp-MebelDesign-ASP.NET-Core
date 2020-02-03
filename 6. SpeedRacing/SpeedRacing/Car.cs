using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmont, double fuelPer1Km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmont;
            this.FuelConsumptionPerKilometer = fuelPer1Km;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; } = 0;

        public bool CalculateMoveDistance (double amountOfKm)
        {
            var fuelForMove = this.FuelConsumptionPerKilometer *amountOfKm;

            if (FuelAmount >= fuelForMove)
            {
                TravelledDistance += amountOfKm;
                FuelAmount -= fuelForMove;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
