using System;

namespace C_sharp_HW_Classes
{
    internal class Program
    {
        class Lighter
        {
            private string brand = "Non-branded";
            private double gas = 0;
            private bool isGasFull = false;
            private bool isGasEmpty = true;
            private int gasTankVolume = 50;
            private static double consumption = 0.03;
            private string gasType = "Propane";
            private static bool isOn;
            private static bool isOff;
            //методы доступа к приватным полям
            public double Gas { get { return gas; } set { gas = value; } }
            public bool IsGasFull { get { return isGasFull; } set { isGasFull = value; } }
            public bool IsGasEmpty { get { return isGasEmpty; } set { isGasEmpty = value; } }
            public int GasTankVolume { get { return gasTankVolume; } set { gasTankVolume = value; } }
            public static double Consumption { get { return consumption; } }
            public static bool IsOn { get { return isOn; } set { isOn = value; } }
            public static bool IsOff { get { return isOff; } set { isOff = value; } }
            public string GasType { get { return gasType; } set { gasType = value; } }
            public string Brand { get { return brand; } set { brand = value; } }
            //Методы управления классом
            public void Cons()
            {
                if (IsOn == false) Console.WriteLine("Lighter isn't on");
                else
                {
                    Gas -= Consumption;
                    if (Gas == 0 || Gas < 0)
                    {
                        Gas = 0;
                        IsGasEmpty = true;
                    }
                }
            }
            public void Refill(ref int fillVolume)
            {
                if (fillVolume + Gas > GasTankVolume)
                {
                    Gas = GasTankVolume;
                    IsGasFull = true;
                }
                else Gas += fillVolume;
            }
            public void Start()
            {
                IsOn = true;
                IsOff = false;
                Console.WriteLine($"Lighter {Brand} is On");
            }
            public void Stop()
            {
                IsOff = true;
                IsOn = false;
                Console.WriteLine($"Lighter {Brand} is Off");
            }
            public void Print()
            {
                Console.WriteLine($"Зажигалка бренда:{Brand} , обьемом {GasTankVolume}cc , " +
                    $"с газом {GasType} в количестве {Gas}cc");

            }
            // Конструкторы
            static Lighter() // Static constructor
            {
                IsOn = false;
                IsOff = true;
            }
            public Lighter()
            {

            }
            public Lighter(string brand, double gas, int gasTankVolume, string gasType)
            {
                Brand = brand;
                Gas = gas;
                GasTankVolume = gasTankVolume;
                GasType = gasType;
            }
            public Lighter(string brand)
            {
                Brand = brand;
            }





        }

        public static void Main(string[] args)
        {
            int addFuel = 20;
            Lighter bik = new Lighter("Bik", 10, 40, "Butane");
            Lighter zippo = new Lighter("zippo");
            Lighter Cricet = new Lighter();
            Lighter[] arrOfLighters = new Lighter[]
            {
                bik,
                zippo, 
                Cricet, 
                new Lighter("Spichki"), 
                new Lighter()
            };
            foreach (Lighter light in arrOfLighters)
            {
                light.Print();
                light.Refill(ref addFuel);
                light.Print();
            }

        }

    }
}
