using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        Random r = new Random();
        public Weather()
        {
            getWeather();
        }

        public string getWeather()
        {
            string conditions = null;
            
            List<string> conditionsList = new List<string>
            {
                "Sunny/Hot",
                "Rainy/OverCast",
                "Thunderstorms",
                "Strong Winds",
                "Fog/Low Visibility", 
                "Excessive Heat and Humidity",
                "Clear skies cooler conditions",
                "Cloudy skies cooler conditions",
                "Sunny and mild",

            };

            for (int counter = 0; counter < conditionsList.Count; counter++)
            {
                conditions = conditionsList[r.Next(0, conditionsList.Count)];

            }

            return conditions;
        }

        public string getWeather2()
        {
            string conditions2 = null;

            List<string> conditions2List = new List<string>
            {
                "Sunny / Mild",
                "Sunny and Windy / Mild Temps",
                "Possible Thunderstorms",
                "Freezing Rain and Wind",
                "Thunderstorms with possible hail",
                "Excessive Heat and Humidity",
                "Light Rain and Fog",
            };
            for (int counter = 0; counter < conditions2List.Count; counter++)
            {
                conditions2 = conditions2List[r.Next(0, conditions2List.Count)];
            }
            return conditions2;
        }

      

            /*
            switch (random)
            {
                case 0:
                    Console.WriteLine(conditions[0]);
                    break;

                case 1:
                    Console.WriteLine(conditions[1]);
                    break;

                case 2:
                    Console.WriteLine(conditions[2]);
                    break;

                case 3:
                    Console.WriteLine(conditions[3]);
                    break;

                case 4:
                    Console.WriteLine(conditions[4]);
                    break;
            }
            return ToString();
            */
        }


    }

