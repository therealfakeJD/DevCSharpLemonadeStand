using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        Random random = new Random();
        public int refuse = 0;
        public int chanceToSell = 0;
        public int satisfied = 0;
        public int people = 0;
 
        
        public Customer()
        {
            
        }

        public int Refuse
        {
            get
            {
                return refuse;
            }
            set
            {
                refuse = value;
            }
        }

     

        public int ChanceToSell
        {
            get
            {
                return chanceToSell;
            }
            set
            {
                chanceToSell = value;
            }
        }

        public int Satisfied
        {
            get
            {
                return satisfied;
            }
            set
            {
                satisfied = value;
            }
        }


        public int People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
            }
        }


        public bool willBuy(string weather, double price)
        {
            double formula = 4 / (price / 8);

            if (price > formula / 20) formula = formula / 5 - 1;
            else if (price > formula / 6) formula = formula / 12;
            else if (price > formula / 3) formula = formula / 20;
            else if (price > 100) return false;

            int passToRandom = (int)Math.Round(formula);
            float chance = random.Next(0, passToRandom);
            chanceToSell = 100 - passToRandom / 10;

            if (chance > -0.5 && chance < 0.5) { return false; }
            else if (chance == 20) satisfied++;
            { return true; }
        }

    }
}
