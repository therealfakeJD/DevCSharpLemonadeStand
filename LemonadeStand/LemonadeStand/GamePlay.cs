using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GamePlay
    {
        public GamePlay()
        {
            Player player = new Player();
            Week week = new Week();
            week.getWeek();
            week.printWeek();
            Inventory inventory = new Inventory();
            inventory.makeLemonade();
            week.getDay();
            Console.ReadLine();
            inventory.makeLemonade();
            week.getDay();
            Console.ReadLine();







        }

        

    

    }
}
