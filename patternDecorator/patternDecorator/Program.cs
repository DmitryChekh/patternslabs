using System;

namespace patternDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Trip trip = new TripToRussia();
            Console.WriteLine(trip.getDescription() + " " + trip.cost() + " $");

            Trip trip1 = new TripToParis();
            trip1 = new Airplane(trip1);
            trip1 = new OceanView(trip1);
            trip1 = new SevenDays(trip1);
            Console.WriteLine(trip1.getDescription() + " " + trip1.cost() + " $");

            Trip trip2 = new TripToMexica();
            trip2 = new Bus(trip2);
            trip2 = new Lux(trip2);

            Console.WriteLine(trip2.getDescription() + " " + trip2.cost() + " $");





            Console.ReadKey();
        }

        abstract class Trip
        {
            public string description = "Unknown";
            public virtual string getDescription()
            {
                return description;
            }
            public abstract double cost();
        }

        abstract class TripTransport : Trip
        {
            public new abstract string getDescription();
        }

        abstract class TripClass : Trip
        {
            public new abstract string getDescription();
        }

        abstract class TripDuration : Trip
        {
            public new abstract string getDescription();
        }

        abstract class TripRoomPosition : Trip
        {
            public new abstract string getDescription();
        }


        abstract class TripExcursion : Trip
        {
            public new abstract string getDescription();
        }




        class TripToParis : Trip
        {
            public TripToParis()
            {
                description = "Paris";
            }
            public override double cost()
            {
                return 130000; 
            }
        }

        class TripToMexica : Trip
        {
            public TripToMexica()
            {
                description = "Mexica";
            }
            public override double cost()
            {
                return 100000;
            }
        }

        class TripToRussia : Trip
        {
            public TripToRussia()
            {
                description = "Russia";
            }
            public override double cost()
            {
                return 10000;
            }
        }



        class Airplane : TripTransport
        {
            Trip trip;

            public Airplane(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {
  
                return trip.getDescription() + " Airplane";
            }

            public override double cost()
            {
                return trip.cost() + 3000;
            }
        }

        class Bus : TripTransport
        {
            Trip trip;

            public Bus(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + " Bus";
            }

            public override double cost()
            {
                return trip.cost() + 1000;
            }
        }

        class Train: TripTransport
        {
            Trip trip;

            public Train(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + " Airplane";
            }

            public override double cost()
            {
                return trip.cost() + 2000;
            }
        }



        class Econom : TripClass
        {
            Trip trip;

            public Econom(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "Econom";
            }

            public override double cost()
            {
                return trip.cost() + 200;
            }
        }

        class Lux : TripClass
        {
                    
            Trip trip;

            public Lux(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "Lux";
            }

            public override double cost()
            {
                return trip.cost() + 500;
            }
        }
    

        class SevenDays : TripDuration
        {
            Trip trip;

            public SevenDays(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "7 days";
            }

            public override double cost()
            {
                return trip.cost() + 700;
            }
        }

        class FourteenDays : TripDuration
        {
            Trip trip;

            public FourteenDays(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "14 days";
            }

            public override double cost()
            {
                return trip.cost() + 1400;
            }
        }

        class TwentyDays : TripDuration
        {
            Trip trip;

            public TwentyDays(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "20 days";
            }

            public override double cost()
            {
                return trip.cost() + 2000;
            }
        }


        class OceanView : TripRoomPosition
        {
            Trip trip;

            public OceanView(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "Ocean view";
            }

            public override double cost()
            {
                return trip.cost() + 900;
            }
        }

        class SimpleView : TripRoomPosition
        {
            Trip trip;

            public SimpleView(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "Simple view";
            }

            public override double cost()
            {
                return trip.cost() + 100;
            }
        }



        class Museum : TripExcursion
        {
            Trip trip;

            public Museum(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "Museum excursion";
            }

            public override double cost()
            {
                return trip.cost() + 666;
            }
        }

        class NationalPark: TripExcursion
        {
            Trip trip;

            public NationalPark(Trip tr)
            {
                this.trip = tr;
            }
            public override string getDescription()
            {

                return trip.getDescription() + "National park";
            }

            public override double cost()
            {
                return trip.cost() + 999;
            }
        }


    }
}
