using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Quest
    {
        public bool complete; //bool tracking if the quest is complete
        public string name; //string for the name of the quest ex: "Break The Boss"
        public string description; // string for the description of the quest ex: "Find and kill the hidden boss."
        public string questTarget; // the name of the specific item / entity that the quest is targeting
        public int completionNumber; // int tracking the number of tasks required to complete the quest
        public int tasksCompleted; // int tracking the number of tasks that have been completed

        //Constructor method for Quest type object
        public Quest(string name, string description, string questTarget, int completionNumber)
        {
            complete = false;
            this.name = name;
            this.description = description;
            this.questTarget = questTarget;
            this.completionNumber = completionNumber;
            tasksCompleted = 0;
        }

        //Update Method for item that checks if the requirements were completed
        public void Update()
        {
            if (tasksCompleted >= completionNumber)
            {
                complete = true;
            }
        }
    }
}
