using System;

namespace patternObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        interface IObserver
        {
            void Update(Object ob);
        }

        interface IObservable
        {
            void AddObserver(IObserver o);
            void RemoveObserver(IObserver o);
            void NotifyObservers();
        }


    }
}
