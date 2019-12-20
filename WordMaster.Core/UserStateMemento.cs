using System;

namespace WordMaster.Core
{
    public class UserStateMemento
    {

        public UserStateMemento(UserState state) { mUserState = state; }

        public UserState GetData() { return mUserState; }

        private UserState mUserState;
    }
}
