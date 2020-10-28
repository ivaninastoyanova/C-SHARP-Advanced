using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray(); //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                Car car = new Car(model,fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string command = Console.ReadLine(); //Drive {carModel} {amountOfKm}"
            while (command!="End")
            {
                 string[] splitted = command.Split().ToArray();
                 string carModel = splitted[1];
                 int amountOfKm = int.Parse(splitted[2]);
                 Car car = cars.FirstOrDefault(x => x.Model == carModel);
                 car.CheckIfCarCanTravelDistance(amountOfKm);
                    
                 command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                //"{model} {fuelAmount} {distanceTraveled}"
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
