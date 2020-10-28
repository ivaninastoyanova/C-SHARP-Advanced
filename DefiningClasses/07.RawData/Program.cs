using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string model = inputInfo[0];

                int engineSpeed = int.Parse(inputInfo[1]);
                int enginePower = int.Parse(inputInfo[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(inputInfo[3]);
                string cargoType = inputInfo[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(inputInfo[5]);
                int tire1Age = int.Parse(inputInfo[6]);
                Tire tire1 = new Tire(tire1Pressure, tire1Age);

                double tire2Pressure = double.Parse(inputInfo[7]);
                int tire2Age = int.Parse(inputInfo[8]);
                Tire tire2 = new Tire(tire2Pressure, tire2Age);

                double tire3Pressure = double.Parse(inputInfo[9]);
                int tire3Age = int.Parse(inputInfo[10]);
                Tire tire3 = new Tire(tire3Pressure, tire3Age);

                double tire4Pressure = double.Parse(inputInfo[11]);
                int tire4Age = int.Parse(inputInfo[12]);
                Tire tire4 = new Tire(tire4Pressure, tire4Age);

                Tire[] tires = new Tire[] { tire1, tire2, tire3, tire4 };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                var fragileCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1)).ToList();
                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                var flamableCars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
                foreach (var car in flamableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }

        }

        
    }
}
