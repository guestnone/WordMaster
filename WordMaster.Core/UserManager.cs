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

        public UserStateMemento GetUserState()
        {
            return new UserStateMemento(mUserState);
        }

        public void OverwriteUserState(UserStateMemento memento)
        {
            mUserState = memento.GetData();
        }

        private UserManager()
        {
            mUserState = new UserState();
        }

        private UserState mUserState;

        private static UserManager mInstance = null;
    }
}
