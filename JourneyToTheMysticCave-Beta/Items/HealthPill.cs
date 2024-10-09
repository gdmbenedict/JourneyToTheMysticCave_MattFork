using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta.Items
{
    internal class HealthPill : Item
    {
        public int healIncrease;

        public HealthPill(int count, char character, string name, int healIncrease, LegendColors legendColors, Player player) :
            base(count, character, name, legendColors, player)
        {
            this.healIncrease = healIncrease;
        }

        public override void Update()
        {
            if (player.pos.x == pos.x && player.pos.y == pos.y)
            {
                TryCollect();
                player.healthSystem.maxHealth += healIncrease;
                player.healthSystem.Heal(player.healthSystem.maxHealth);
            }
        }

        public override string Use()
        {
            player.healthSystem.maxHealth += healIncrease;
            player.healthSystem.Heal(player.healthSystem.maxHealth);
            string message = player.name + " used a " + name + " and gained " + healIncrease + " additional Hp.";
            return message;
        }
    }
}
