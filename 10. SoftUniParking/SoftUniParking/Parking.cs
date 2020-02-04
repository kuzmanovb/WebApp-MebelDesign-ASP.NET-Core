using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacityParking)
        {
            this.capacity = capacityParking;
            cars = new List<Car>();
        }

        public int Count
        {
            get 
            {
                return cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            bool flag = false;
            foreach (var item in cars)
            {
                var curentNumber = item.RegistrationNumber;
                if (curentNumber == car.RegistrationNumber)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                return $"Car with that registration number, already exists!";
            }
            if (capacity == cars.Count)
            {
                return $"Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                var curentNumber = cars[i].RegistrationNumber;
                if (curentNumber == registrationNumber)
                {
                    cars.RemoveAt(i);
                    return $"Successfully removed { registrationNumber}";
                }

            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            Car carForGive = null;
            for (int i = 0; i < cars.Count; i++)
            {
                var curentNumber = cars[i].RegistrationNumber;
                if (curentNumber == registrationNumber)
                {
                    carForGive = cars[i];
                    break;
                }

            }
            return carForGive;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].RegistrationNumber == number)
                    {
                        cars.RemoveAt(i);
                        break;
                    }
                }
            }



        }
    }
}
