using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    /// <summary>
    /// Class that creates Test that is passed by user
    /// </summary>
    public class TestGenerator
    {
        public TestGenerator(ITestAdapter model, WordSet wordSet)
        {
            mTestModel = model;
            mWordSet = wordSet;
            mSelector = new WordSelector(new EasyModeWordSelectionStrategy(), wordSet);
        }
        /// <summary>
        /// Setting test model which determines test structure
        /// </summary>
        /// <param name="model">Test Adapter</param>
        public void SetTestModel(ITestAdapter model) { mTestModel = model; }
        /// <summary>
        /// Method that returns generated test based on test model and strategies used individually in each task.
        /// </summary>
        /// <returns>Test</returns>
        public Test GenerateTest() {
            if (mTestModel == null)
                return null;

            Test test = new Test();
            for (int i = 0; i < 10; i++) {
                int wordCount = 0;
                mTestModel.SetWordCount(ref wordCount, ref i);
                int pointsNumber = 0;
                mTestModel.SetPointsNumber(ref pointsNumber, ref i);
                int level = 0;
                mTestModel.SetDifficulty(ref level, ref i);
                string[] words = new string[wordCount];

                Random rand = new Random();
                int choosenWord = rand.Next(wordCount);
                string rightAnswer = "";
                string searchedWord = "";
                switch (level) {
                    case 0:
                        mSelector.SetStrategy(new EasyModeWordSelectionStrategy());
                        break;
                    case 1:
                        mSelector.SetStrategy(new HardModeWordSelectionStrategy());
                        break;
                }
                for (int j = 0; j < wordCount; j++) {
                    words[j] = mSelector.getNextWord();
                    if (j == choosenWord) {
                        rightAnswer = words[j];
                    }

                }
                ICollection<string> keys = mWordSet.mWords.Keys;

                
                foreach (string w in keys) {
                    string s;
                    mWordSet.mWords.TryGetValue(w, out s);
                    if (s == rightAnswer) {
                        searchedWord = w;
                    }
                       
                }
                test.addTask(words, pointsNumber, rightAnswer, level, searchedWord);
            }
            return test;
        }

        private ITestAdapter mTestModel;
        private WordSet mWordSet;
        private WordSelector mSelector;
    }
}
