using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    public class Answer
    { 
        public string Display { get; set;  }
    }
    public class Task
    { 
        public Answer[] Answers { get; set; }
        public int Points { get; set; }
        public int Difficulty { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer SearchedWord { get; set; }
        public Answer SelectedAnswer { get; set; }

        public Task(string[] possibleWords, int taskPoints, string rightAnswer, int difficulty, string searched)
        {
            Answers = new Answer[possibleWords.Length];
            for (int i = 0; i < Answers.Length; i++) {
                Answers[i] = new Answer();
                Answers[i].Display = possibleWords[i];
            }
            Points = taskPoints;
            Difficulty = difficulty;
            RightAnswer = new Answer();
            RightAnswer.Display = rightAnswer;
            SearchedWord = new Answer();
            SearchedWord.Display = searched;
        }
    }
    public class Test
    {
        public List<Task> Tasks { get; set; }

        public Test ()
	    {
            Tasks = new List<Task>();
        }
        public void addTask(string[] possibleWords, int taskPoints, string rightAnswer, int difficulty, string searched)
        {
            Tasks.Add(new Task(possibleWords, taskPoints, rightAnswer, difficulty, searched));
        }
    }
}
