using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMysticCave_Beta
{
    internal class Quest
    {
        public bool complete = false;
        public string name;
        public string description;
        public string questTarget;
        public int completionNumber;
        public int tasksCompleted;

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
