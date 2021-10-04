using System;
using System.Collections.Generic;
using System.Text;

namespace GubbenIRummet
{
    class Question
    {

        public string Questions { get; set; }
        public int Answers { get; set; } 

        public Question(string questions, int answers)
        {
            Questions = questions;
            Answers = answers;
        }

        public bool CheckAnswer(int answer)
        {
            bool correct;
            if (answer == Answers)
            {
                correct = true;
                return true;
            }
            else
            {
                correct = false;
                return false;
            }
        }
    }
    
    
  
}
