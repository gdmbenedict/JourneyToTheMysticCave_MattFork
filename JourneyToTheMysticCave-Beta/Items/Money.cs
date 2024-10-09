using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Money : Item
    {
        public Money(int count, char character, string name, LegendColors legendColors, Player player) :
            base(count, character, name, legendColors, player)
        { }

        public override void Update()
        {
            if (player.pos.x == pos.x && player.pos.y == pos.y)
            {
                //player can only collect one money at a time
                player.money += 1;
                TryCollect();
            }
                
        }

        public override string Use()
        {
            player.money += 1;
            string message = player.name + " found some " + name + " and put it in their pocket.";
            return message;
        }
    }
}
