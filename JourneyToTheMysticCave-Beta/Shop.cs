using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Shop : Item
    {
        private Item[] inventory;
        private int[] prices;

        public Shop(int count, char character, string name, LegendColors legendColors, Player player) : base(count, character, name, legendColors, player)
        {
           this.name = pickRandomName();
        }

        //Method that picks a random name from a list of names
        private string pickRandomName()
        {
            Random rand = new Random();
            string name;

            switch (rand.Next(0, 16))
            {
                case 0:
                    name = "Jeff";
                    break;

                case 1:
                    name = "Sam";
                    break;

                case 2:
                    name = "John";
                    break;

                case 3:
                    name = "Matt";
                    break;

                case 4:
                    name = "Nora";
                    break;

                case 5:
                    name = "Emma";
                    break;

                case 6:
                    name = "Liam";
                    break;

                case 7:
                    name = "Olivia";
                    break;

                case 8:
                    name = "Sofia";
                    break;

                case 9:
                    name = "Alice";
                    break;

                case 10:
                    name = "Lily";
                    break;

                case 11:
                    name = "Jacob";
                    break;

                case 12:
                    name = "Ethan";
                    break;

                case 13:
                    name = "Ellie";
                    break;

                case 14:
                    name = "Adam";
                    break;

                case 15:
                    name = "Abby";
                    break;

                default:
                    name = "???";
                    break;
            }

            return name;
        }

        private void populateShop()
        {

        }

        public void Use()
        {
            //filling requirements of the item class
        }
    }
}
