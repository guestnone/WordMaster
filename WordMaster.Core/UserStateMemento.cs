using System;

namespace WordMaster.Core
{
    /// <summary>
    /// Class used to hold the state of a user data
    /// </summary>
    public class UserStateMemento
    {
        /// <summary>
        /// Initializes a new instance using a given User state object
        /// </summary>
        public UserStateMemento(UserState state) { mUserState = state; }

        /// <summary>
        /// Returns the internally stored object.
        /// </summary>
        public UserState GetData() { return mUserState; }

        private UserState mUserState;
    }
}
