using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LemonadeStand
{


    class Inventory : Store
    {
        public Random rnd = new Random();
        public Weather weather1 = new Weather();
        public List<string> days = new List<string>();
        private Customer customer = new Customer();
        public string weather;
        public double money = 50.00;
        public int lemons = 0;
        public int sugar = 0;
        public int lemonJuice = 0;
        public int cubes = 0;
        public double cupPrice = 1.00;
        public int lemonsUsed = 0;
        public int cubeUsed = 0;
        public int sugarUsed = 0;
        public int lemonJuiceUsed = 0;
        public int peopleServed = 0;
        public int pitchers = 0;

        public Inventory()
        {

        }


        public int LemonsUsed
        {
            get { return lemonsUsed; }
            set { lemonsUsed = value; }
        }

        public int CubeUsed
        {
            get { return cubeUsed; }
            set { cubeUsed = value; }
        }

        public int SugarUsed
        {
            get { return sugarUsed; }
            set { sugarUsed = value; }
        }

        public int LemonJuiceUsed
        {
            get { return lemonJuiceUsed; }
            set { lemonJuiceUsed = value; }
        }


        public void buyLemons()
        {
            Console.WriteLine("Lemon Price: $" + lemonPrice + " -- How many lemons would you like to buy?");
            try
            {
                int lemonsBuying = Convert.ToInt32(Console.ReadLine());
                if (money > lemonPrice*lemonsBuying)
                {
                    money = money - lemonPrice*lemonsBuying;
                    lemons += lemonsBuying;
                }
                else if (money < lemonPrice*lemonsBuying)
                {
                    Console.WriteLine("You don't have enough money to buy product!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be positive integer");
                buyLemons();
            }

        }

        public void buySugar()
        {
            Console.WriteLine("Sugar Price: $" + sugarPrice + " -- How much sugar would you like to buy?");
            try
            {
                int sugarBuying = Convert.ToInt32(Console.ReadLine());
                if (money > sugarPrice*sugarBuying)
                {
                    money = money - sugarPrice*sugarBuying;
                    sugar += sugarBuying;
                }
                else if (money < sugarPrice*sugarBuying)
                {
                    Console.WriteLine("You don't have enough money to buy product!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be a positive integer");
                buySugar();
            }

        }

        public void buyLemonJuice()
        {
            Console.WriteLine("Lemon Juice Price: $" + lemonJuicePrice +
                              " -- How much lemon juice would you like to buy?");
            try
            {
                int lemonJuiceBuying = Convert.ToInt32(Console.ReadLine());
                if (money > lemonJuicePrice*lemonJuiceBuying)
                {
                    money = money - lemonJuicePrice*lemonJuiceBuying;
                    lemonJuice += lemonJuiceBuying;
                }
                else if (money < lemonJuicePrice*lemonJuiceBuying)
                {
                    Console.WriteLine("You don't have enough money to buy product!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be a positive integer");
                buyLemonJuice();
            }

        }

        public void buyIce()
        {
            Console.WriteLine("Ice Price: $" + icePrice + " -- How much ice would you like to buy?");
            try
            {
                int iceBuying = Convert.ToInt32(Console.ReadLine());
                if (money > icePrice*iceBuying)
                {
                    money = money - icePrice*iceBuying;
                    cubes += iceBuying;
                }
                else if (money < icePrice*iceBuying)
                {
                    Console.WriteLine("You don't have enough money to buy product!");
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be a positive integer");
                buyIce();
            }

        }

        public void printInventory()
        {
            Console.WriteLine("Lemons: " + lemons + "\nSugar: " + sugar + "\nLemon Juice: " + lemonJuice + "\nIce: " +
                              cubes + "\n Money Left: " + money);
        }

        public double makeLemonade()
        {
            buyInventory();
            double cash;

            int minPeople = 0;
            int maxPeople = 0;

            int lemonsPerPitcher = 3;
            int cubesPerPitcher = 2;
            int sugarPerPitcher = 2;
            int lemonJuicePerPitcher = 3;

            weather = weather1.getWeather();

            if (weather.Contains("Rain") || weather.Contains("Thunderstorms"))
            {
                minPeople = 40; maxPeople = 60; 
                
            }
            else if (weather1.getWeather().Contains("Sunny") || weather1.getWeather().Contains("Heat"))
            {
                minPeople = 61; maxPeople = 100; 
            }

            customer.people = rnd.Next(minPeople, maxPeople);
            int temp = 0;

            for (int i = 0; i < customer.people; i++)
            {
                if (customer.willBuy(weather, cupPrice))
                {
                    temp++;
                }
                //-----------------------------
                else
                {
                    customer.refuse++;
                }
            }
            int peopleServed = temp;

            if (lemons >= lemonsPerPitcher  &&
                cubes >= cubesPerPitcher &&
                sugar >= sugarPerPitcher &&
                lemonJuice >= lemonJuicePerPitcher)
            {
                lemons -= lemonsPerPitcher;
                cubes -= cubesPerPitcher;
                sugar -= sugarPerPitcher;
                lemonJuice -= lemonJuicePerPitcher;

                pitchers += 1;
            }
            if (lemons <= lemonsPerPitcher ||
                     cubes <= cubesPerPitcher ||
                     sugar <= sugarPerPitcher ||
                     lemonJuice <= lemonJuicePerPitcher)
            {
                buyInventory();
            }

            if (pitchers < peopleServed)
            {
                peopleServed = pitchers;
                lemonsUsed += pitchers*(lemonsPerPitcher/1);
                cubeUsed += pitchers*(cubesPerPitcher/1);
                sugarUsed += pitchers*(sugarPerPitcher/1);
                lemonJuiceUsed += pitchers*(lemonJuicePerPitcher/1);
                Console.WriteLine("You couldn't serve " + (customer.people - peopleServed) +
                                  " people because you didn't have enough supplies");
            }
            else
            {
                lemonsUsed += (customer.people - peopleServed)*(lemonsPerPitcher/1);
                cubeUsed += (customer.people - peopleServed)*(cubesPerPitcher/1);
                sugarUsed += (customer.people - peopleServed)*(sugarPerPitcher/1);
                lemonJuiceUsed += (customer.people - peopleServed)*(lemonJuicePerPitcher/1);
            }

            Console.WriteLine("Lemons Used: " + lemonsUsed);
            Console.WriteLine("Cubes Used: " + cubeUsed);
            Console.WriteLine("Sugar Used: " + sugarUsed);
            Console.WriteLine("Lemon Juice Used: " + lemonJuiceUsed);

            cash = cupPrice*peopleServed;
            return cash;
        }



        public void buyInventory()
        {
            buyLemons();
            buySugar();
            buyLemonJuice();
            buyIce();
            Console.WriteLine("*********************");
            printInventory();
            Console.WriteLine("*********************");
        }

    }
}



/*
        public void addLemons()
        {
            List<Item> lemons = new List<Item>();
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
            lemons.Add(new Item("Lemon", .89));
        }

        public void addSugar()
        {
            List<Item> sugar = new List<Item>();
            sugar.Add(new Item("Pound of Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
            sugar.Add(new Item("Sugar", .65));
        }

        public void addLemonJuice()
        {
            List<Item> lemonJuice = new List<Item>();
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
            lemonJuice.Add(new Item("Bottle of Lemon Juice", 4.80));
        }

        public void addIce()
        {
            List<Item> ice = new List<Item>();
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
            ice.Add(new Item("Bag of Ice", 1.40));
        }
        */






        /*
                    public int getLemonsLeft()
                    {
                        return lemonsLeft;
                    }

                    public int getSugarLeft()
                    {
                        return sugarLeftIbs;
                    }

                    public int getLemonJuiceLeft()
                    {
                        return lemonJuiceLeftBottles;
                    }

                    public int getIceLeft()
                    {
                        return iceLeftBags;
                    }
            */
