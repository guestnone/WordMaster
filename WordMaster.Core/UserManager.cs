using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    /// <summary>
    /// Singleton manager responsible for managing user state.
    /// </summary>
    public sealed class UserManager
    {

        /// <summary>
        /// Returns the instance of a manager. Creates on first call.
        /// </summary>
        public static UserManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new UserManager();
            }

            return mInstance;
        }

        /// <summary>
        /// Get the user statt saves as a memento
        /// </summary>
        /// <param name="shalowCopy">True if copy should be linked to the original.</param>
        public UserStateMemento GetUserState(bool shalowCopy)
        {
            if (shalowCopy)
                return new UserStateMemento(mUserState);
            return new UserStateMemento(mUserState.Copy());
        }

        /// <summary>
        /// Replaces the user state with the one stores in a given memento.
        /// </summary>
        public void OverwriteUserState(UserStateMemento memento)
        {
            mUserState = memento.GetData();
        }

        public void SetProficiency(ProficiencyType type)
        {
            mUserState.mProficiencyType = type;
        }

        public void SetFirstName(string firstName)
        {
            mUserState.mFirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            mUserState.mLastName = lastName;
        }

        /// <summary>
        /// Modifies the good and bad answer statistics by addying the given values
        /// </summary>
        public void ModifyAnswerStatistics(int wrongCount, int goodCount)
        {
            if (wrongCount != -1)
            {
                mUserState.mWrongAnswerCount += wrongCount;
            }
            if (goodCount != -1)
            {
                mUserState.mGoodAnswerCount += goodCount;
            }
        }

        private UserManager()
        {
            mUserState = new UserState
            {
                mFirstName = "Unknown",
                mLastName = "User",
                mProficiencyType = ProficiencyType.Basic,
                mGoodAnswerCount = 0,
                mWrongAnswerCount = 0
            };
        }

        private UserState mUserState;

        private static UserManager mInstance = null;
    }
}
