using JourneyToTheMysticCave_Beta.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Shop : Item
    {
        private string shopKeeperName;
        private Item[] inventory;
        private Gamelog gamelog;

        public Shop(GameStats stats, int count, char character, string name, LegendColors legendColors, Player player, int value, Gamelog gamelog) : base(count, character, name, legendColors, player, value)
        {
            shopKeeperName = pickRandomName();
            this.gamelog = gamelog;
            populateShop(stats, legendColors, player);

        }

        public override void Update()
        {

            if (player.pos.x == pos.x && player.pos.y == pos.y)
            {
                //bool used to interact with log function to display
                pickedUp = true;
                Debug.WriteLine(pickedUp.ToString());
            }
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

        private void populateShop(GameStats stats, LegendColors legendColors, Player player)
        {
            //setting inventory
            inventory = new Item[3]{
                    new Potion(stats.PotionCount, stats.PotionCharacter, stats.PotionName, stats.PotionHeal, legendColors, player, stats.PotionValue),
                    new Sword(stats.SwordCount, stats.SwordCharacter, stats.SwordName, stats.SwordMultiplier, legendColors, player, stats.SwordValue),
                    new HealthPill(stats.HealthPillCount, stats.HealthPillCharacter, stats.HealthPillName, stats.HealthPillIncrease, legendColors, player, stats.HealthPillValue)
                    };
        }

        //method used to interact with shop
        public override string Use()
        {
            string shopMessage;

            //Creating Shop Menu
            shopMessage = "Hello! I'm " + shopKeeperName + " the shop keeper.\n";
            shopMessage += "Here's what I'm selling:\n";

            //adding items and prices
            for (int i=0; i<inventory.Length; i++)
            {
                shopMessage += "[" + (i+1) + "]\tname: " + inventory[i].name + "\tcost: " + inventory[i].value + "\n";
            }

            shopMessage += "\nPlease press the number of your desired item.\n";

            Console.Write(shopMessage);

            ConsoleKeyInfo input = Console.ReadKey(true); //read input
            bool triedToBuyItem = false;
            string purchaseMessage = "";
            
            for (int i = 0; i < inventory.Length; i++)
            {
                //check for input number value
                if((int)char.GetNumericValue(input.KeyChar) == i + 1)
                {
                    triedToBuyItem = true;

                    if (player.money >= inventory[i].value)
                    {
                        player.money -= inventory[i].value;
                        purchaseMessage += player.name + " bought a " + inventory[i].name + " for " + inventory[i].value + " dollars.\n";
                        purchaseMessage += inventory[i].Use() + "\n";
                    }
                    else
                    {
                        purchaseMessage += player.name + " tried to buy a " + inventory[i].name + " but it was too expensive.\n";
                    }
                    
                }
            }

            if (!triedToBuyItem)
            {
                purchaseMessage += player.name + " did not buy anything.";
            }

            return purchaseMessage;
        }
    }
}
