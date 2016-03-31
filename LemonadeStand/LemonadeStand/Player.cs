using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player : Inventory
    {
        public string playerName;


        public Player()
        {
            getPlayerName();


        }

        public string getPlayerName()
        {
            Console.WriteLine("Welcome to Lemonade Stand");
            Console.WriteLine(" Enter Player Name:");
            playerName = Console.ReadLine();
            Console.WriteLine("Player Name: {0}", playerName);
            return playerName;
        }


    
    }
}

