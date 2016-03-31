using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Week
    {
        
        public Weather weather = new Weather();
        public Weather weather1 = new Weather();
        public Inventory inventory = new Inventory();
        public List<string> week = new List<string>();
        public List<string> days = new List<string>(); 
        public string weatherForTheWeek;
        public string day;
        public Week()
        {
            
            
        }

        
        public void getWeek()
        {
            week.Add("Monday: " + weather.getWeather());
            week.Add("Tuesday: " + weather.getWeather());
            week.Add("Wednesday: " + weather.getWeather());
            week.Add("Thursday: " + weather.getWeather());
            week.Add("Friday: " + weather.getWeather());
            week.Add("Saturday: " + weather.getWeather());
            week.Add("Sunday: " + weather.getWeather());
        }

        public void getWeek2()
        {
            days.Add("Monday: " + weather1.getWeather2());
            days.Add("Tuesday: " + weather1.getWeather2());
            days.Add("Wednesday: " + weather1.getWeather2());
            days.Add("Thursday: " + weather1.getWeather2());
            days.Add("Friday: " + weather1.getWeather2());
            days.Add("Saturday: " + weather1.getWeather2());
            days.Add("Sunday: " + weather1.getWeather2());
        }

        public void printWeek()
        {
            Console.WriteLine("You need to decide how much lemonade to make on each day to keep your customers happy and your wallet full");
            Console.WriteLine("You will have to opportunity to see the forecast and then decide how much lemonade you would like to make for that day");
            Console.WriteLine("However, be careful because the weather could absolutely change on the day you make lemonade");
            Console.WriteLine("Please press enter to start");
            Console.ReadLine();
            Console.WriteLine("ForeCast For the Week...");
            for (int counter = 0; counter < week.Count; counter++)
            {
                Console.WriteLine(week[counter], weather.getWeather());
            }
        }

        public void getDay()
        {
            for (int counter = 0; counter < days.Count; counter++)
            {
                day = days[counter];
                Console.WriteLine(day);
            }


        }
    }
}
