using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    public class Test
    {
        public List<string[]> Tasks { get; }
        public List<int> Points { get; }

        public List<int> Difficulty { get; }

        public List<string> RightAnswers { get; set; }

        public List<string> SearchedWords { get; set; }

        public Test ()
	    {
            Tasks = new List<string[]>();
            Points = new List<int>();
            RightAnswers = new List<string>();
            Difficulty = new List<int>();
            SearchedWords = new List<string>();
        }
        public void addTask(string[] possibleWords, int taskPoints, string rightAnswer, int difficulty, string searched)
        {
            Tasks.Add(possibleWords);
            Points.Add(taskPoints);
            RightAnswers.Add(rightAnswer);
            Difficulty.Add(difficulty);
            SearchedWords.Add(searched);
        }
    }
}
