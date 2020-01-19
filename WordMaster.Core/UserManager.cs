using System;
using System.Collections.Generic;
using System.Text;

namespace WordMaster.Core
{
    class UserManager
    {

        private static UserManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new UserManager();
            }

            return mInstance;
        }

        public UserStateMemento GetUserState(bool shalowCopy)
        {
            if (shalowCopy)
                return new UserStateMemento(mUserState);
            return new UserStateMemento(mUserState.Copy());
        }

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

        public void ModifyAnswerStatistics(int wrongCount, int goodCount)
        {
            if (wrongCount != -1)
            {
                mUserState.mWrongAnswerCount = wrongCount;
            }
            if (goodCount != -1)
            {
                mUserState.mGoodAnswerCount = goodCount;
            }
        }

        private UserManager()
        {
            mUserState = new UserState();
        }

        private UserState mUserState;

        private static UserManager mInstance = null;
    }
}
