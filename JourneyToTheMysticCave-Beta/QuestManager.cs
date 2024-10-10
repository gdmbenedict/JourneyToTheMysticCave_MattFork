using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class QuestManager
    {
        public List<Quest> quests = new List<Quest>();
        public GameStats gameStats = new GameStats();
        public Map map = new Map();

        public void Init(GameStats gameStats, Map map)
        {
            this.gameStats = gameStats;
            this.map = map;
        }

        //Method that updates quests
        public void Update()
        {
            for (int i =0; i<quests.Count; i++)
            {
                quests[i].Update();
            }
        }

        //Method that draws the Quest UI to the screen
        public void Draw()
        {
            int columnPos = map.GetMapColumnCount() + 30;
            int rowPos = 0;//map.GetMapRowCount() +1;

            //Writing Title
            Console.SetCursorPosition(columnPos, rowPos++);
            Console.Write("QUEST LOG");

            //Top bound
            Console.SetCursorPosition(columnPos, rowPos++);
            Console.Write("+------------------------+");

            //filling contents
            for (int i =0; i < quests.Count; i++)
            {
                //quest name
                Console.SetCursorPosition(columnPos, rowPos++);
                Console.Write(quests[i].name + ":");

                //quest description
                Console.SetCursorPosition(columnPos, rowPos++);
                Console.Write("Goal: " + quests[i].description);

                //progress
                Console.SetCursorPosition(columnPos, rowPos++);
                if (quests[i].complete)
                {
                    Console.Write("*Quest Complete*");
                }
                else
                {
                    Console.Write(quests[i].tasksCompleted + "/" + quests[i].completionNumber);
                }

                //splitting bar
                if (i +1 < quests.Count)
                {
                    Console.SetCursorPosition(columnPos, rowPos++);
                    Console.Write("=========================+");
                }
            }

            //Top bound
            Console.SetCursorPosition(columnPos, rowPos++);
            Console.Write("+------------------------+");

        }
    }

    
}
