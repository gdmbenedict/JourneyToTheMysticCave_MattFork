using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal abstract class Item : GameObject
    {
        public int value;
        public bool collected = false;
        public bool pickedUp = false;
        public int count;
        public Player player;
        LegendColors legendColors;

        public Item(int count, char character, string name, LegendColors legendColors, Player player, int value)
        {
            this.count = count;
            this.character = character;
            this.name = name;
            this.legendColors = legendColors;
            this.player = player;
            this.value = value;
        }

        
        public virtual void Update() { }

        public void Draw()
        {
            if (!collected)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                legendColors.MapColor(character);
                Console.Write(character.ToString());
                Console.ResetColor();
            }
            Console.CursorVisible = false;
        }


        public virtual void TryCollect()
        {
            if (!collected)
            {
                collected = true;
                pickedUp = true;
                pos = new Point2D { x = 0, y = 0 };
            }
        }

        public abstract string Use();
    }
}
