using System;
using System.Collections.Generic;

namespace patternObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyData currencyData = new CurrencyData();

            CurrentRateDisplay currentDisplay = new CurrentRateDisplay(currencyData);

            CurrencyStatics statisticsDisplay = new CurrencyStatics(currencyData);

            currencyData.setCurrency(80, 75, 200);
            currencyData.setCurrency(64, 54, 105);
            currencyData.setCurrency(65, 85, 74);
            currencyData.setCurrency(10, 75, 54);
            currencyData.setCurrency(20, 20, 20);
            currencyData.setCurrency(35, 65, 78);
            currencyData.setCurrency(22, 12, 32);
            currencyData.setCurrency(1, 1, 1);


            Console.ReadLine();
        }

        interface IObserver
        {
            void Update(decimal euro, decimal dollar, decimal sterling);
        }

        interface Subject
        {
            abstract void AddObserver(IObserver o);
            abstract void RemoveObserver(IObserver o);
            abstract void NotifyObservers();
        }

        interface DisplayElement
        {
            public void display();

        }

        class CurrencyData : Subject
        {
            private List<IObserver> observers;
            private decimal DollarRate;
            private decimal EuroRate;
            private decimal SterlingRate;

            public CurrencyData()
            {
                observers = new List<IObserver>();
            }

            public void AddObserver(IObserver o)
            {
                observers.Add(o);
            }

            public void NotifyObservers()
            {
                foreach(var o in observers)
                {
                    o.Update(EuroRate, DollarRate, SterlingRate);
                }
            }

            public void RemoveObserver(IObserver o)
            {
                observers.Remove(o);
            }

            public void currencyChanged()
            {
                NotifyObservers();
            }

            public void setCurrency(decimal euro, decimal dollar, decimal sterling)
            {
                this.DollarRate = dollar;
                this.EuroRate = euro;
                this.SterlingRate = sterling;
                currencyChanged();
            }

        }


        class CurrentRateDisplay : IObserver, DisplayElement
        {
            private decimal DollarRate;
            private decimal EuroRate;
            private decimal SterlingRate;

            public CurrentRateDisplay(Subject currencyData)
            {
                currencyData.AddObserver(this);
            }

            public void Update(decimal euro, decimal dollar, decimal sterling)
            {
                this.DollarRate = dollar;
                this.EuroRate = euro;
                this.SterlingRate = sterling;
                display();
            }

            public void display()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dollar: {0} \nEuro: {1}\nPound sterling: {2}\n", DollarRate, EuroRate, SterlingRate);
                Console.ResetColor();
            }
        }

        class CurrencyStatics : IObserver, DisplayElement
        {
            private decimal DollarRate;
            private decimal EuroRate;
            private decimal SterlingRate;
            private decimal[] dollarArray = new decimal[7];
            private decimal[] euroArray = new decimal[7];
            private decimal[] sterlingArray = new decimal[7];
            private int counterDays = 0;

            public CurrencyStatics(Subject currencyData)
            {
                currencyData.AddObserver(this);
            }

            public void Update(decimal euro, decimal dollar, decimal sterling)
            {
                this.DollarRate = dollar;
                this.EuroRate = euro;
                this.SterlingRate = sterling;

                if(counterDays > 6)
                {
                    counterDays = 0;
                }
                euroArray[counterDays] = euro;
                dollarArray[counterDays] = dollar;
                sterlingArray[counterDays] = sterling;
                counterDays++;


                display();
            }

            public void display()
            {
                decimal averageEuro = 0;
                decimal averageDollar = 0;
                decimal averageSterling = 0;
                int day = 0;
                
                foreach (decimal currencyDay in euroArray)
                {
                    if(currencyDay == 0)
                    {
                        break;
                    }
                    else
                    {
                        day++;
                        averageEuro += (int)currencyDay;
                    }
                }
                foreach (decimal currencyDay in dollarArray)
                {
                    if (currencyDay == 0)
                    {
                        break;
                    }
                    else
                    {
                        averageDollar += (int)currencyDay;
                    }
                }
                foreach (decimal currencyDay in sterlingArray)
                {
                    if (currencyDay == 0)
                    {
                        break;
                    }
                    else
                    {
                        averageSterling += (int)currencyDay;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dollar average of week: {0} \nEuro average of week: {1}\nPound sterling average of week: {2}\n", averageDollar / day, averageEuro / day, averageSterling / day);
                Console.ResetColor();
            }
        }

    }
}
