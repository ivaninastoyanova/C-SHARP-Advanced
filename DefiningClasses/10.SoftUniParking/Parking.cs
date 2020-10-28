using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars = new List<Car>();
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }


        public int Count
             => this.cars.Count;

        public string AddCar(Car car)
        {
            if(cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else
            {
                if(cars.Count>= capacity)
                {
                    return "Parking is full!";
                }
                else
                {
                    cars.Add(car);
                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if(!cars.Any(x =>x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car car = cars.FirstOrDefault(r => r.RegistrationNumber == registrationNumber);
                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(r => r.RegistrationNumber == registrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                var car = cars.FirstOrDefault(x => x.RegistrationNumber == regNum);
                cars.Remove(car);
            }
        }
    }
}
