using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Sword : Item
    {
        public int swordMultiplier;

        public Sword(int count, char character, string name, int swordMultiplier, LegendColors legendColors, Player player, int value) : 
            base(count, character, name, legendColors, player, value)
        {
            this.swordMultiplier = swordMultiplier;
        }

        public override void Update()
        {
            if(player.pos.x == pos.x && player.pos.y == pos.y)
            {
                TryCollect();
                player.damage += swordMultiplier;
            }
        }

        public override string Use()
        {
            player.damage += swordMultiplier;
            string message = player.name + " used a " + name + " and gained " + swordMultiplier + " attack power.";
            return message;
        }
    }
}
